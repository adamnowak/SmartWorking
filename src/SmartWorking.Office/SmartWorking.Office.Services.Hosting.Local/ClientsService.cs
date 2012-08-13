using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.Entities;

using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IClientsService"/>.
  /// </summary>
  public class ClientsService : IClientsService
  {
    #region IClientsService Members

    /// <summary>
    /// Gets the clients filtered by <paramref name="clientNameFilter"/>.
    /// </summary>
    /// <param name="clientNameFilter">The client name filter.</param>
    /// <returns>
    /// List of clients filtered by <paramref name="clientNameFilter"/>. Result contains Buildings of Clients.
    /// </returns>
    public List<ClientPrimitive> GetClients(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Client> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Clients.ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Clients.Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Clients.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Clients.Where(x => (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Clients.Where(x => !x.Deleted.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList()
                      : ctx.Clients.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList();

          return result.Select(x => x.GetPrimitive()).ToList();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Gets the <see cref="ClientAndClientBuildingsPackage"/> list filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The client name filter.</param>
    /// <returns>
    /// List of clients filtered by <paramref name="filter"/>.
    /// </returns>
    public List<ClientAndClientBuildingsPackage> GetClientAndBuildingsPackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Client> result =
           (string.IsNullOrWhiteSpace(filter))
             ? (listItemsFilterValue == ListItemsFilterValues.All)
                 ? ctx.Clients.Include("ClientBuildings.Building").ToList()
                 : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                     ? ctx.Clients.Include("ClientBuildings.Building").Where(x => !x.Deleted.HasValue).ToList()
                     : ctx.Clients.Include("ClientBuildings.Building").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
             : (listItemsFilterValue == ListItemsFilterValues.All)
                 ? ctx.Clients.Include("ClientBuildings.Building").Where(x => (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList()
                 : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                     ? ctx.Clients.Include("ClientBuildings.Building").Where(x => !x.Deleted.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList()
                     : ctx.Clients.Include("ClientBuildings.Building").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList();
          return result.Select(x => x.GetClientAndBuildingsPackage()).ToList();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the client.
    /// </summary>
    /// <param name="clientPrimitive">The client primitive.</param>
    public void CreateOrUpdateClient(ClientAndClientBuildingsPackage clientAndBuildingsPackage)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Client client = clientAndBuildingsPackage.Client.GetEntity();

          Client existingObject = context.Clients.Include("ClientBuildings").Where(x => x.Id == client.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && client.Id > 0)
          {
            throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
          }

          //Item has no PK value, must be new
          if (client.Id <= 0)
          {
            context.Clients.AddObject(client);
            foreach (ClientBuildingAndBuildingPackage clientBuildingPackage in clientAndBuildingsPackage.ClientBuildings)
            {
              ClientBuildingPrimitive clientBuildingPrimitive =
                clientBuildingPackage.GetClientBuildingPrimitiveWithReference();
              
              if (clientBuildingPrimitive != null)
              {
                clientBuildingPrimitive.Id = 0;
                ClientBuilding clientBuilding = clientBuildingPrimitive.GetEntity();
                clientBuilding.Client = client;
                context.ClientBuildings.AddObject(clientBuilding);
              }
            }
          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
            List<ClientBuildingPrimitive> existingClientBuildings = existingObject.ClientBuildings.Select(x => x.GetPrimitive()).ToList();
            List<ClientBuildingPrimitive> newClientBuildings = clientAndBuildingsPackage.GetClientBuildingListWithReference().ToList();
            List<ClientBuildingPrimitive> theSameElements = newClientBuildings.Where(x => existingClientBuildings.Select(y => y.Building_Id).Contains(x.Building_Id)).ToList();

            existingClientBuildings.RemoveAll(x => theSameElements.Select(y => y.Building_Id).Contains(x.Building_Id));
            newClientBuildings.RemoveAll(x => theSameElements.Select(y => y.Building_Id).Contains(x.Building_Id));

            //remove 
            if (existingClientBuildings.Count() > 0)
            {
              List<int> existingClientBuildingIds = existingClientBuildings.Select(x => x.Id).ToList();
              List<ClientBuilding> clientBuildingListToDelete =
                context.ClientBuildings.Where(x => existingClientBuildingIds.Contains(x.Id)).ToList();
              
              foreach (ClientBuilding clientBuldingToDelete in clientBuildingListToDelete)
              {
                //context.ClientBuildings.Where(x => x.Id == clientBuldingToDelete)
                context.ClientBuildings.DeleteObject(clientBuldingToDelete);
              }
            }

            //add
            foreach (ClientBuildingPrimitive clientBuildingPrimitive in newClientBuildings)
            {
              context.ClientBuildings.AddObject(clientBuildingPrimitive.GetEntity());
            }
            
            context.Clients.ApplyCurrentValues(client);            
          }

          context.SaveChanges();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Deletes the client.
    /// </summary>
    /// <param name="clientPrimitive">The client primitive.</param>
    public void DeleteClient(ClientPrimitive clientPrimitive)
    {
      try
      {
        //TODO: if is not used in any DeliveryNotes than delete.
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Client car = context.Clients.Where(x => x.Id == clientPrimitive.Id).FirstOrDefault();
          if (car != null)
          {
            car.Deleted = DateTime.Now;
            context.SaveChanges();
          }
          else
          {
            throw new Exception("This car does not exist in db.");
          }
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public void UndeleteClient(ClientPrimitive clientPrimitive)
    {
      try
      {
        //TODO: if is not used in any DeliveryNotes than delete.
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Client car = context.Clients.Where(x => x.Id == clientPrimitive.Id).FirstOrDefault();
          if (car != null)
          {
            car.Deleted = null;
            context.SaveChanges();
          }
          else
          {
            throw new Exception("This car does not exist in db.");
          }
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }


    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
    }

    #endregion
  }
}