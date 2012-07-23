using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;
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
    public List<ClientPrimitive> GetClients(string clientNameFilter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Client> result =
            (string.IsNullOrWhiteSpace(clientNameFilter))
              ? ctx.Clients.ToList()
              : ctx.Clients.Where(x => x.Name.StartsWith(clientNameFilter)).ToList();
          return result.Select(x => x.GetPrimitive()).ToList();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Gets the <see cref="ClientAndBuildingsPackage"/> list filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The client name filter.</param>
    /// <returns>
    /// List of clients filtered by <paramref name="filter"/>.
    /// </returns>
    public List<ClientAndBuildingsPackage> GetClientAndBuildingsPackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Client> result =
            (string.IsNullOrWhiteSpace(filter))
              ? ctx.Clients.Include("ClientBuildings.Building").ToList()
              : ctx.Clients.Include("ClientBuildings.Building").Where(x => x.Name.StartsWith(filter)).ToList();
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
    public void CreateOrUpdateClient(ClientPrimitive clientPrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Client client = clientPrimitive.GetEntity();

          Client existingObject = context.Clients.Where(x => x.Id == client.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && client.Id > 0)
          {
            throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
          }
          //Item has no PK value, must be new
          else if (client.Id <= 0)
          {
            context.Clients.AddObject(client);
          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
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
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the building.
    /// </summary>
    /// <param name="buildingPrimitive">The building primitive.</param>
    public void UpdateBuilding(BuildingPrimitive buildingPrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Building building = buildingPrimitive.GetEntity();
          Building existingObject = context.Buildings.Where(x => x.Id == building.Id).FirstOrDefault();


          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && building.Id > 0)
          {
            //log //TODO: client have to be in database before
            return;
          }
          //Item has no PK value, must be new
          else if (building.Id <= 0)
          {
            context.Buildings.AddObject(building);
          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
            context.Buildings.ApplyCurrentValues(building);
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
    /// Deletes the building.
    /// </summary>
    /// <param name="building">The building which will be deleted.</param>
    public void DeleteBuilding(BuildingPrimitive buildingPrimitive)
    {
      try
      {
        throw new NotImplementedException();
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