using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Contractor and his Buildings.
  /// </summary>
  [ServiceContract]
  public interface IContractorsService : IDisposable
  {
    /// <summary>
    /// Gets the contractors filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The contractor name filter.</param>
    /// <returns>List of contractors filtered by <paramref name="filter"/>. Result contains Buildings of Contractors.</returns>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    [WebInvoke(Method = "GET", UriTemplate = "/GetContractors/?filter={filter}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<Contractor> GetContractors(string filter);

    /// <summary>
    /// Creates or updates the contractor.
    /// </summary>
    /// <param name="contractor">The contractor who will be updated.</param>
    /// <remarks>Only fields of Contractor object will be updated. Associated object e.g. Buildings have to be updated separately.</remarks>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    [WebInvoke(Method = "POST", UriTemplate = "/CreateOrUpdateContractor",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateContractor(Contractor contractor);

    /// <summary>
    /// Deletes the contractor.
    /// </summary>
    /// <param name="contractor">The contractor who will be deleted.</param>
    /// <remarks>Only contractor who doesn't have Building which are used in <see cref="DeliveryNote"/></remarks>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteContractor",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteContractor(Contractor contractor);


    /// <summary>
    /// Updates the building.
    /// </summary>
    /// <param name="building">The building which will be updated.</param>
    /// <remarks>Only fields of Building will be updated. Associated object e.g. Contractor have to be updated separately.</remarks>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateBuilding",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UpdateBuilding(Building building);

    /// <summary>
    /// Deletes the building.
    /// </summary>
    /// <param name="building">The building which will be deleted.</param>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteBuilding",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteBuilding(Building building);
  }
}