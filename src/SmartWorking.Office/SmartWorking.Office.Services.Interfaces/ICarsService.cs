using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Car.
  /// </summary>
  [ServiceContract]
  public interface ICarsService : IDisposable
  {
    /// <summary>
    /// Gets the cars filtered be <paramref name="carsFilter"/>.
    /// </summary>
    /// <param name="carsFilter">The cars filter used to result filtering.</param>
    /// <returns>
    /// List of Car filtered by <paramref name="carsFilter"/>. 
    /// </returns>
    [OperationContract]
    //[ApplyDataContractResolver]
    [CyclicReferencesAware(true)]    
    List<Car> GetCars(string carsFilter);

    /// <summary>
    /// Updates the car.
    /// </summary>
    /// <param name="car">The car which will be updated.</param>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void UpdateCar(Car car);

    /// <summary>
    /// Deletes the car.
    /// </summary>
    /// <param name="car">The car which will be deleted.</param>
    /// <remarks>
    /// Only car which is not used can be deleted.
    /// </remarks>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void DeleteCar(Car car);
  }
}