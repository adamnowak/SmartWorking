﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Entities
{
  public static class GetEntityWithReferenceHelper
  {
    public static DeliveryNotePrimitive GetDeliveryNotePrimitiveWithReference(this DeliveryNotePackage deliveryNote)
    {
      if (deliveryNote == null)
        return null;
      DeliveryNotePrimitive result = deliveryNote.DeliveryNote;

      if (result != null)
      {        
        if (deliveryNote.Car != null)
        {
          result.Car_Id = deliveryNote.Car.Id;
        }
        if (deliveryNote.Driver != null)
        {
          result.Driver_Id = deliveryNote.Driver.Id;
        }
        if (deliveryNote.Recipe != null)
        {
          result.Recipe_Id = deliveryNote.Recipe.Id;
        }
        if (deliveryNote.BuildingAndContractor != null && deliveryNote.BuildingAndContractor.Building != null)
        {
          result.Building_Id = deliveryNote.BuildingAndContractor.Building.Id;
        }
      }
      return result;
    }
  }
}