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
  /// Implementation of <see cref="IRecipesService"/>.
  /// </summary>
  public class DriversService : IDriversService
  {
    
    /// <summary>
    /// Gets the drivers filtered be <paramref name="driversFilter"/>.
    /// </summary>
    /// <param name="driversFilter">The drivers filter used to result filtering.</param>
    /// <returns>
    /// List of Drivers filtered by <paramref name="driversFilter"/>.
    /// </returns>
    public List<DriverPrimitive> GetDrivers(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Driver> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
               ? ctx.Drivers.Where(x => x.Name.StartsWith(filter)).ToList()
                  : ctx.Drivers.Where(x => !x.Deleted.HasValue && x.Name.StartsWith(filter)).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Drivers.Where(x => x.Name.StartsWith(filter)).ToList()
                  : ctx.Drivers.Where(x => !x.Deleted.HasValue && x.Name.StartsWith(filter)).ToList();            
          return result.Select(x => x.GetPrimitive()).ToList(); 
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public List<DriverAndCarsPackage> GetDriverAndCarsPackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Driver> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Drivers.Include("Cars").ToList()
                  : ctx.Drivers.Include("Cars").Where(x => !x.Deleted.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Drivers.Include("Cars").Where(x => x.Name.StartsWith(filter)).ToList()
                  : ctx.Drivers.Include("Cars").Where(x => !x.Deleted.HasValue && x.Name.StartsWith(filter)).ToList();
          return result.Select(x => x.GetDriverAndCarsPackage()).ToList();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the driver.
    /// </summary>
    /// <param name="driver">The driver which will be updated.</param>
    public void UpdateDriver(DriverPrimitive driverPrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Driver driver = driverPrimitive.GetEntity();

          Driver existingObject = context.Drivers.Where(x => x.Id == driver.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && driver.Id > 0)
          {
            //TODO:
            return;
          }
          //Item has no PK value, must be new
          else if (driver.Id <= 0)
          {
            context.Drivers.AddObject(driver);
          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
            context.Drivers.ApplyCurrentValues(driver);
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
    /// Deletes the recipe.
    /// </summary>
    /// <param name="driver">The driver which will be deleted.</param>
    public void DeleteDriver(DriverPrimitive driverPrimitive)
    {
      try
      {
        //TODO: if is not used in any DeliveryNotes than delete.
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Driver driver = context.Drivers.Where(x => x.Id == driverPrimitive.Id).FirstOrDefault();
          if (driver != null)
          {
            driver.Deleted = DateTime.Now;
            context.SaveChanges();
          }
          else
          {
            throw new Exception("This driver does not exist in db.");
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
  }
}