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
    public List<Driver> GetDrivers(string driversFilter)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Driver> result =
          (string.IsNullOrWhiteSpace(driversFilter))
            ? ctx.Drivers.ToList()
            : ctx.Drivers.Where(x => x.Name.StartsWith(driversFilter)).ToList();
        return result;
      }
    }

    /// <summary>
    /// Updates the car.
    /// </summary>
    /// <param name="driver">The driver which will be updated.</param>
    public void UpdateDriver(Driver driver)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    /// <param name="driver">The driver which will be deleted.</param>
    public void DeleteDriver(Driver driver)
    {
      throw new NotImplementedException();
    }
  }
}