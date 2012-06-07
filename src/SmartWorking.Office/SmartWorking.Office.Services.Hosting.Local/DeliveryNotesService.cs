using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IDeliveryNotesService"/>.
  /// </summary>
  public class DeliveryNotesService : IDeliveryNotesService
  {
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the <see cref="DeliveryNote"/> filtered be <paramref name="deliveryNotesFilter"/>.
    /// </summary>
    /// <param name="deliveryNotesFilter">The delivery notes filter.</param>
    /// <returns>
    /// List of <see cref="DeliveryNote"/> filtered by <paramref name="deliveryNotesFilter"/>.
    /// </returns>
    public List<Car> GetIDeliveryNotes(string deliveryNotesFilter)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be updated.</param>
    public void UpdateDeliveryNote(DeliveryNote deliveryNote)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be canceled.</param>
    public void CanceledDeliveryNote(DeliveryNote deliveryNote)
    {
      throw new NotImplementedException();
    }
  }
}