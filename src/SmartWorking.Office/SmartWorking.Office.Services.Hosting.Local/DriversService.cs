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
    public List<DriverPrimitive> GetDrivers(string filter)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Driver> result =
            (string.IsNullOrWhiteSpace(filter))
              ? ctx.Drivers.ToList()
              : ctx.Drivers.Where(x => x.Name.StartsWith(filter)).ToList();
          return result.Select(x => x.GetPrimitive()).ToList(); ;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public List<DriverAndCarPackage> GetDriverAndCarPackageList(string filter)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Driver> result =
            (string.IsNullOrWhiteSpace(filter))
              ? ctx.Drivers.Include("Car").ToList()
              : ctx.Drivers.Include("Car").Where(x => x.Name.StartsWith(filter)).ToList();
          return result.Select(x => x.GetDriverAndCarPackage()).ToList(); ;
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
  }
}