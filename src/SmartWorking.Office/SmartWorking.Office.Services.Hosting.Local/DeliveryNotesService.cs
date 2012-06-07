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
      
    }


    /// <summary>
    /// Gets the <see cref="DeliveryNote"/> filtered be <paramref name="buildingContainsThisString"/> and <paramref name="showCanceledDeliveryNotes"/>.
    /// </summary>
    /// <param name="buildingContainsThisString">Used to filtering result. Loaded <see cref="DeliveryNote"/> object will contain this string.</param>
    /// <param name="showCanceledDeliveryNotes">if set to <c>true</c> then loaded <see cref="DeliveryNote"/> object  will contain <see cref="DeliveryNote"/> which are deactivated; otherwise not.</param>
    /// <returns>
    /// List of <see cref="DeliveryNote"/> filtered by <paramref name="buildingContainsThisString"/> and <paramref name="showCanceledDeliveryNotes"/>.
    /// </returns>
    public List<DeliveryNote> GetIDeliveryNotes(string buildingContainsThisString, bool showCanceledDeliveryNotes)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<DeliveryNote> result;
          if (string.IsNullOrWhiteSpace(buildingContainsThisString))
          {
            if (showCanceledDeliveryNotes)
            {
              result = ctx.DeliveryNotes.Include("Building").ToList();
            }
            else
            {
              result = ctx.DeliveryNotes.Include("Building").Where(x => x.Canceled != DateTime.MinValue).ToList();
            }
          }
          else
          {
            if (showCanceledDeliveryNotes)
            {
              result = ctx.DeliveryNotes.Include("Building").Where(x => (x.Building.City+ " " + x.Building.Street).Contains(buildingContainsThisString)).ToList();
            }
            else
            {
              result = ctx.DeliveryNotes.Include("Building").Where(x => x.Canceled != DateTime.MinValue && (x.Building.City + " " + x.Building.Street).Contains(buildingContainsThisString)).ToList();
            }
            
          }
        return result;
      }
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