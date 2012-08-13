using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;

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
    [WebInvoke(Method = "GET", UriTemplate = "/GetClients/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<ClientPrimitive> GetClients(string filter, ListItemsFilterValues listItemsFilterValue);

    /// <summary>
    /// Gets the <see cref="ClientAndClientBuildingsPackage"/> list filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The client name filter.</param>
    /// <returns>
    /// List of clients filtered by <paramref name="filter"/>. 
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetClientAndBuildingsPackageList/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<ClientAndClientBuildingsPackage> GetClientAndBuildingsPackageList(string filter, ListItemsFilterValues listItemsFilterValue);

    /// <summary>
    /// Creates or updates the client.
    /// </summary>
    /// <param name="client">The client who will be updated.</param>
    /// <remarks>Only fields of Client object will be updated. Associated object e.g. Buildings have to be updated separately.</remarks>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CreateOrUpdateClient",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateClient(ClientAndClientBuildingsPackage client);

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

    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/UndeleteClient",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UndeleteClient(ClientPrimitive client);
  }
}