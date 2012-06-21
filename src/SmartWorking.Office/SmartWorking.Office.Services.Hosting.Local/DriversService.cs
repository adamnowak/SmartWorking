using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IRecipesService"/>.
  /// </summary>
  public class DriversService : IDriversService
  {
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
    }

    /// <summary>
    /// Gets the drivers filtered be <paramref name="driversFilter"/>.
    /// </summary>
    /// <param name="driversFilter">The drivers filter used to result filtering.</param>
    /// <returns>
    /// List of Drivers filtered by <paramref name="driversFilter"/>.
    /// </returns>
    public List<DriverPrimitive> GetDrivers(string driversFilter)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Driver> result =
          (string.IsNullOrWhiteSpace(driversFilter))
            ? ctx.Drivers.ToList()
            : ctx.Drivers.Where(x => x.Name.StartsWith(driversFilter)).ToList();
        return result.Select(x => x.GetPrimitive()).ToList(); ;
      }
    }

    /// <summary>
    /// Updates the driver.
    /// </summary>
    /// <param name="driver">The driver which will be updated.</param>
    public void UpdateDriver(DriverPrimitive driverPrimitive)
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

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    /// <param name="driver">The driver which will be deleted.</param>
    public void DeleteDriver(DriverPrimitive driverPrimitive)
    {
      throw new NotImplementedException();
    }
  }
}