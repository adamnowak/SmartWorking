using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on <see cref="DeliveryNote"/>.
  /// </summary>
  [ServiceContract]
  public interface IDeliveryNotesService : IDisposable
  {
    /// <summary>
    /// Gets the <see cref="DeliveryNote"/> filtered be <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </summary>
    /// <param name="filter">Used to filtering result. Loaded <see cref="DeliveryNote"/> object will contain this string.</param>
    /// <param name="showCanceled">if set to <c>true</c> then loaded <see cref="DeliveryNote"/> object  will contain <see cref="DeliveryNote"/> which are deactivated; otherwise not.</param>        
    /// <returns>
    /// List of <see cref="DeliveryNote"/> filtered by <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDeliveryNotes/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<DeliveryNotePrimitive> GetDeliveryNotes(string filter, ListItemsFilterValues listItemsFilterValue);

    /// <summary>
    /// Gets the <see cref="DeliveryNote"/> filtered be <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </summary>
    /// <param name="filter">Used to filtering result. Loaded <see cref="DeliveryNote"/> object will contain this string.</param>
    /// <param name="getCanceled">if set to <c>true</c> [get canceled].</param>
    /// <returns>
    /// List of <see cref="DeliveryNote"/> filtered by <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDeliveryNotePackageList/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<DeliveryNotePackage> GetDeliveryNotePackageList(string filter, ListItemsFilterValues listItemsFilterValue);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetNextDeliveryNumber",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    int GetNextDeliveryNumber();

    /// <summary>
    /// Updates the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be updated.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateDeliveryNote",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    DeliveryNotePrimitive CreateOrUpdateDeliveryNote(DeliveryNotePrimitive deliveryNote);


    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/DeactiveDeliveryNote",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeactiveDeliveryNote(DeliveryNotePrimitive deliveryNote);


    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/ActiveDeliveryNote",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void ActiveDeliveryNote(DeliveryNotePrimitive deliveryNote);
  }
}