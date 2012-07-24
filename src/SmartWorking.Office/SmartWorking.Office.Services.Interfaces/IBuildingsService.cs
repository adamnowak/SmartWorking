using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Client and his Buildings.
  /// </summary>
  [ServiceContract]
  public interface IBuildingsService : IDisposable
  {
    /// <summary>
    /// Gets the clients filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The client name filter.</param>
    /// <returns>List of clients filtered by <paramref name="filter"/>. 
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetBuildings/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<BuildingPrimitive> GetBuildings(string filter, ListItemsFilterValues listItemsFilterValue);



    /// <summary>
    /// Creates or updates the client.
    /// </summary>
    /// <param name="client">The client who will be updated.</param>
    /// <remarks>Only fields of Client object will be updated. Associated object e.g. Buildings have to be updated separately.</remarks>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CreateOrUpdateBuilding",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateBuilding(BuildingPrimitive building);

    /// <summary>
    /// Deletes the client.
    /// </summary>
    /// <param name="client">The client who will be deleted.</param>
    /// <remarks>Only client who doesn't have Building which are used in <see cref="DeliveryNote"/></remarks>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteBuilding",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteBuilding(BuildingPrimitive building);


   
  }
}