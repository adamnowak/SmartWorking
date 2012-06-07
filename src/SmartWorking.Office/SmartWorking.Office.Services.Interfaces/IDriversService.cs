using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Drivers.
  /// </summary>
  [ServiceContract]
  public interface IDriversService : IDisposable
  {
    /// <summary>
    /// Gets the drivers filtered be <paramref name="driversFilter"/>.
    /// </summary>
    /// <param name="driversFilter">The drivers filter used to result filtering.</param>
    /// <returns>
    /// List of Drivers filtered by <paramref name="driversFilter"/>.
    /// </returns>
    [OperationContract]
    List<Driver> GetDrivers(string driversFilter);

    /// <summary>
    /// Updates the car.
    /// </summary>
    /// <param name="driver">The driver which will be updated.</param>
    [OperationContract]
    void UpdateDriver(Driver driver);

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    /// <param name="driver">The driver which will be deleted.</param>
    /// <remarks>
    /// Only driver which is not used can be deleted.
    /// </remarks>
    [OperationContract]
    void DeleteDriver(Driver driver);
  }
}