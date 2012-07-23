using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Car.
  /// </summary>
  [ServiceContract]
  public interface ICarsService : IDisposable
  {
    /// <summary>
    /// Gets the cars filtered be <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The cars filter used to result filtering.</param>
    /// <returns>
    /// List of Car filtered by <paramref name="filter"/>. 
    /// </returns>
    /// http://localhost:60322/CarsService.svc/json/GetCars/?filter=
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetCars/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    List<CarPrimitive> GetCars(string filter, ListItemsFilterValues listItemsFilterValue);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetCarAndDriverPackageList/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    List<CarAndDriverPackage> GetCarAndDriverPackageList(string filter, ListItemsFilterValues listItemsFilterValue);

    /// <summary>
    /// Updates the car.
    /// </summary>
    /// <param name="car">The car which will be updated.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateCar",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateCar(CarPrimitive car);

    /// <summary>
    /// Deletes the car.
    /// </summary>
    /// <param name="car">The car which will be deleted.</param>
    /// <remarks>
    /// Only car which is not used can be deleted.
    /// </remarks>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteCar",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteCar(CarPrimitive car);
  }
}