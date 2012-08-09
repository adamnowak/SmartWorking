using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.Entities;

using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IDeliveryNotesService"/>.
  /// </summary>
  public class DeliveryNotesService : IDeliveryNotesService
  {
    /// <summary>
    /// Gets the <see cref="DeliveryNote"/> filtered be <paramref name="filter"/> and <paramref name="showCanceledDeliveryNotes"/>.
    /// </summary>
    /// <param name="filter">Used to filtering result. Loaded <see cref="DeliveryNote"/> object will contain this string.</param>
    /// <param name="showCanceledDeliveryNotes">if set to <c>true</c> then loaded <see cref="DeliveryNote"/> object  will contain <see cref="DeliveryNote"/> which are deactivated; otherwise not.</param>
    /// <returns>
    /// List of <see cref="DeliveryNote"/> filtered by <paramref name="filter"/> and <paramref name="showCanceledDeliveryNotes"/>.
    /// </returns>
    public List<DeliveryNotePrimitive> GetDeliveryNotes(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<DeliveryNote> result;
          //if (string.IsNullOrWhiteSpace(filter))
          //{
          //  if (showCanceledDeliveryNotes)
          //  {
          //    result = ctx.DeliveryNotes.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").ToList();
          //  }
          //  else
          //  {
          //    result = ctx.DeliveryNotes.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => x.Canceled != DateTime.MinValue).ToList();
          //  }
          //}
          //else
          //{
          //  if (showCanceledDeliveryNotes)
          //  {
          //    result = ctx.DeliveryNotes.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => (x.Building.City + " " + x.Building.Street).Contains(filter)).ToList();
          //  }
          //  else
          //  {
          //    result = ctx.DeliveryNotes.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => x.Canceled != DateTime.MinValue && (x.Building.City + " " + x.Building.Street).Contains(filter)).ToList();
          //  }

          //}
          //return result.Select(x => x.GetPrimitive()).ToList();
          return null;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public List<DeliveryNotePackage> GetDeliveryNotePackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          //List<DeliveryNote> result;
          //if (string.IsNullOrWhiteSpace(filter))
          //{
          //  if (getCanceled)
          //  {
          //    result = ctx.DeliveryNotes.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").ToList();
          //  }
          //  else
          //  {
          //    result = ctx.DeliveryNotes.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => x.Canceled != DateTime.MinValue).ToList();
          //  }
          //}
          //else
          //{
          //  if (getCanceled)
          //  {
          //    result = ctx.DeliveryNotes.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => (x.Building.City + " " + x.Building.Street).Contains(filter)).ToList();
          //  }
          //  else
          //  {
          //    result = ctx.DeliveryNotes.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => x.Canceled != DateTime.MinValue && (x.Building.City + " " + x.Building.Street).Contains(filter)).ToList();
          //  }

          //}
          //return result.Select(x => x.GetDeliveryNotePackage()).ToList();
          return null;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public int GetNextDeliveryNumber()
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          int? maxDeliveryNumberRead = ctx.DeliveryNotes.Where(x => x.Year == DateTime.Now.Year).Max(x => x.Number);
          return maxDeliveryNumberRead.HasValue ? maxDeliveryNumberRead.Value + 1 : 1;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be updated.</param>
    public DeliveryNotePrimitive CreateOrUpdateDeliveryNote(DeliveryNotePrimitive deliveryNotePrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          DeliveryNote deliveryNote = deliveryNotePrimitive.GetEntity();



          DeliveryNote existingObject = context.DeliveryNotes.Where(x => x.Id == deliveryNote.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && deliveryNote.Id > 0)
          {
            throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
          }

          //Item has no PK value, must be new);
          if (deliveryNote.Id <= 0)
          {
            deliveryNote.DateDrawing = DateTime.Now;
            deliveryNote.Number = GetNextDeliveryNumber(); 
            context.DeliveryNotes.AddObject(deliveryNote);

          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
            context.DeliveryNotes.ApplyCurrentValues(deliveryNote);
          }

          context.SaveChanges();

          return deliveryNote;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Deletes the <see cref="DeliveryNote"/>.
    /// </summary>
    /// <param name="deliveryNote">The delivery note which will be canceled.</param>
    public void CanceledDeliveryNote(DeliveryNotePrimitive deliveryNotePrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          DeliveryNote deliveryNote = deliveryNotePrimitive.GetEntity();

          DeliveryNote existingObject = context.DeliveryNotes.Where(x => x.Id == deliveryNote.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null)
          {
            throw new Exception("Only exists delivery note can be canceled.");
          }

          deliveryNote.Canceled = DateTime.Now;
          context.DeliveryNotes.ApplyCurrentValues(deliveryNote);          

          context.SaveChanges();          
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {

    }
  }
}