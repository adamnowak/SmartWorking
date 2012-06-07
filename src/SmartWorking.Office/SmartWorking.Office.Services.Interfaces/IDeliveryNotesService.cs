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
    /// Gets the <see cref="DeliveryNote"/> filtered be <paramref name="deliveryNotesFilter"/>.
    /// </summary>
    /// <param name="deliveryNotesFilter">The delivery notes filter.</param>
    /// <returns>
    /// List of <see cref="DeliveryNote"/> filtered by <paramref name="deliveryNotesFilter"/>.
    /// </returns>
    [OperationContract]
    List<Car> GetIDeliveryNotes(string deliveryNotesFilter);

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