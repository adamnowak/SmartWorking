using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;

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
    [WebInvoke(Method = "GET", UriTemplate = "/GetDeliveryNotes/?filter={filter}&getCanceled={getCanceled}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<DeliveryNotePrimitive> GetDeliveryNotes(string filter, bool getCanceled);

    /// <summary>
    /// Gets the <see cref="DeliveryNote"/> filtered be <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </summary>
    /// <param name="filter">Used to filtering result. Loaded <see cref="DeliveryNote"/> object will contain this string.</param>
    /// <param name="getCanceled">if set to <c>true</c> [get canceled].</param>
    /// <returns>
    /// List of <see cref="DeliveryNote"/> filtered by <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetDeliveryNotePackages/?filter={filter}&getCanceled={getCanceled}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<DeliveryNotePackage> GetDeliveryNotePackages(string filter, bool getCanceled);

    /// <summary>
    /// Updates the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be updated.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateDeliveryNote",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UpdateDeliveryNote(DeliveryNotePrimitive deliveryNote);

    /// <summary>
    /// Deletes the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be canceled.</param>
    /// <remarks>
    /// <see cref="DeliveryNote"/> cannot be deleted.
    /// </remarks>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CanceledDeliveryNote",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CanceledDeliveryNote(DeliveryNotePrimitive deliveryNote);
  }
}