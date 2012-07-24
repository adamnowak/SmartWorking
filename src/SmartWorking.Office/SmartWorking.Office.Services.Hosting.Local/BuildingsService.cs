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

    public void CreateOrUpdateBuilding(BuildingPrimitive building)
    {
      throw new NotImplementedException();
    }

    public void DeleteBuilding(BuildingPrimitive building)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {


    }
  }
}