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
  public interface IClientsService : IDisposable
  {
    /// <summary>
    /// Gets the clients filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The client name filter.</param>
    /// <returns>List of clients filtered by <paramref name="filter"/>. 
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetClients/?filter={filter}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<ClientPrimitive> GetClients(string filter);

    /// <summary>
    /// Gets the <see cref="ClientAndBuildingsPackage"/> list filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The client name filter.</param>
    /// <returns>
    /// List of clients filtered by <paramref name="filter"/>. 
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetClientAndBuildingsPackageList/?filter={filter}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<ClientAndBuildingsPackage> GetClientAndBuildingsPackageList(string filter);

    /// <summary>
    /// Creates or updates the client.
    /// </summary>
    /// <param name="client">The client who will be updated.</param>
    /// <remarks>Only fields of Client object will be updated. Associated object e.g. Buildings have to be updated separately.</remarks>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CreateOrUpdateClient",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateClient(ClientPrimitive client);

    /// <summary>
    /// Deletes the client.
    /// </summary>
    /// <param name="client">The client who will be deleted.</param>
    /// <remarks>Only client who doesn't have Building which are used in <see cref="DeliveryNote"/></remarks>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteClient",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteClient(ClientPrimitive client);


    /// <summary>
    /// Updates the building.
    /// </summary>
    /// <param name="building">The building which will be updated.</param>
    /// <remarks>Only fields of Building will be updated. Associated object e.g. Client have to be updated separately.</remarks>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateBuilding",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UpdateBuilding(BuildingPrimitive building);

    /// <summary>
    /// Deletes the building.
    /// </summary>
    /// <param name="building">The building which will be deleted.</param>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteBuilding",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteBuilding(BuildingPrimitive building);
  }
}