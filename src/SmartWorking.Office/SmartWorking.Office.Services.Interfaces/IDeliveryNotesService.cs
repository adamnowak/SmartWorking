using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on <see cref="DeliveryNote"/>.
  /// </summary>
  [ServiceContract]
  public interface IDeliveryNotesService : IDisposable
  {
    /// <summary>
    /// Gets the <see cref="DeliveryNote"/> filtered be <paramref name="buildingContainsThisString"/> and <paramref name="showCanceledDeliveryNotes"/>.
    /// </summary>
    /// <param name="buildingContainsThisString">Used to filtering result. Loaded <see cref="DeliveryNote"/> object will contain this string.</param>
    /// <param name="showCanceledDeliveryNotes">if set to <c>true</c> then loaded <see cref="DeliveryNote"/> object  will contain <see cref="DeliveryNote"/> which are deactivated; otherwise not.</param>        
    /// <returns>
    /// List of <see cref="DeliveryNote"/> filtered by <paramref name="buildingContainsThisString"/> and <paramref name="showCanceledDeliveryNotes"/>.
    /// </returns>
    [OperationContract]
    List<DeliveryNote> GetIDeliveryNotes(string buildingContainsThisString, bool showCanceledDeliveryNotes);

    /// <summary>
    /// Updates the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be updated.</param>
    [OperationContract]
    void UpdateDeliveryNote(DeliveryNote deliveryNote);

    /// <summary>
    /// Deletes the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be canceled.</param>
    /// <remarks>
    /// <see cref="DeliveryNote"/> cannot be deleted.
    /// </remarks>
    [OperationContract]
    void CanceledDeliveryNote(DeliveryNote deliveryNote);
  }
}