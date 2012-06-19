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
              result = ctx.DeliveryNotes.Include("Building.Contractor").ToList();
            }
            else
            {
              result = ctx.DeliveryNotes.Include("Building.Contractor").Where(x => x.Canceled != DateTime.MinValue).ToList();
            }
          }
          else
          {
            if (showCanceledDeliveryNotes)
            {
              result = ctx.DeliveryNotes.Include("Building.Contractor").Where(x => (x.Building.City + " " + x.Building.Street).Contains(buildingContainsThisString)).ToList();
            }
            else
            {
              result = ctx.DeliveryNotes.Include("Building.Contractor").Where(x => x.Canceled != DateTime.MinValue && (x.Building.City + " " + x.Building.Street).Contains(buildingContainsThisString)).ToList();
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
      using (SmartWorkingEntities context = new SmartWorkingEntities())
      {
        DeliveryNote existingObject = context.DeliveryNotes.Where(x => x.Id == deliveryNote.Id).FirstOrDefault();

        //no record of this item in the DB, item being passed in has a PK
        if (existingObject == null && deliveryNote.Id > 0)
        {
          //log
          return;
        }
        
        //Item has no PK value, must be new);
        if (deliveryNote.Id <= 0)
        {
          context.DeliveryNotes.AddObject(deliveryNote.CopyWithOutReferences());
        }
        //Item was retrieved, and the item passed has a valid ID, do an update
        else
        {
          context.DeliveryNotes.ApplyCurrentValues(deliveryNote.CopyWithOutReferences());
        }

        context.SaveChanges();
      }
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