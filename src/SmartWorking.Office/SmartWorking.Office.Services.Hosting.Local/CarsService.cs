using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="ICarsService"/>.
  /// </summary>
  public class CarsService : ICarsService
  {
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the cars filtered be <paramref name="carsFilter"/>.
    /// </summary>
    /// <param name="carsFilter">The cars filter used to result filtering.</param>
    /// <returns>
    /// List of Car filtered by <paramref name="carsFilter"/>.
    /// </returns>
    public List<Car> GetCars(string carsFilter)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the car.
    /// </summary>
    /// <param name="car">The car which will be updated.</param>
    public void UpdateCar(Car car)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the car.
    /// </summary>
    /// <param name="car">The car which will be deleted.</param>
    public void DeleteCar(Car car)
    {
      throw new NotImplementedException();
    }
  }
}