using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;

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
    /// <returns>List of contractors filtered by <paramref name="filter"/>. 
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetContractors/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    List<ContractorPrimitive> GetContractors(string filter, ListItemsFilterValues listItemsFilterValue);

    /// <summary>
    /// Creates or updates the contractor.
    /// </summary>
    /// <param name="contractor">The contractor who will be updated.</param>
    /// <remarks>Only fields of Contractor object will be updated. Associated object e.g. Buildings have to be updated separately.</remarks>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CreateOrUpdateContractor",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateContractor(ContractorPrimitive contractor);

    /// <summary>
    /// Deletes the contractor.
    /// </summary>
    /// <param name="contractor">The contractor who will be deleted.</param>
    /// <remarks>Only contractor who doesn't have Building which are used in <see cref="DeliveryNote"/></remarks>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteContractor",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteContractor(ContractorPrimitive contractor);

    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/UndeleteContractor",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UndeleteContractor(ContractorPrimitive contractor);
  }
}