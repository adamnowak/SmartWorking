using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
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
    /// Gets the drivers filtered be <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The drivers filter used to result filtering.</param>
    /// <returns>
    /// List of Drivers filtered by <paramref name="filter"/>.
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDrivers/?filter={filter}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<DriverPrimitive> GetDrivers(string filter);

    /// <summary>
    /// Updates the car.
    /// </summary>
    /// <param name="driver">The driver which will be updated.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateDriver",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UpdateDriver(DriverPrimitive driver);

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    /// <param name="driver">The driver which will be deleted.</param>
    /// <remarks>
    /// Only driver which is not used can be deleted.
    /// </remarks>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteDriver",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteDriver(DriverPrimitive driver);
  }
}