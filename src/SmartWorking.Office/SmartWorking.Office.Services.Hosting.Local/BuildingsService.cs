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
  public class BuildingsService : IBuildingsService
  {
    

    public List<BuildingPrimitive> GetBuildings(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Building> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Buildings.ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Buildings.Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Buildings.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Buildings.Where(x => x.ContactPerson.StartsWith(filter)).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Buildings.Where(x => !x.Deleted.HasValue && x.ContactPerson.StartsWith(filter)).ToList()
                      : ctx.Buildings.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && x.ContactPerson.StartsWith(filter)).ToList();
          return result.Select(x => x.GetPrimitive()).ToList(); ;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public void CreateOrUpdateBuilding(BuildingPrimitive buildingPrimitive)
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
            throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
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

    public void DeleteBuilding(BuildingPrimitive buildingPrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Building building = context.Buildings.Where(x => x.Id == buildingPrimitive.Id).FirstOrDefault();
          if (building != null)
          {
            building.Deleted = DateTime.Now;
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

    public void Dispose()
    {


    }
  }
}