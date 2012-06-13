using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartWorking.Office.Entities
{
  public static class CopyWithOutReferencesHelper
  {
    public static DeliveryNote CopyWithOutReferences(this DeliveryNote deliveryNote)
    {
      DeliveryNote result = new DeliveryNote();
      if (deliveryNote.Car != null)
        result.Car_Id = deliveryNote.Car.Id;
      if (deliveryNote.Driver != null)
        result.Driver_Id = deliveryNote.Driver.Id;
      if (deliveryNote.Recipe != null)
        result.Recipe_Id = deliveryNote.Recipe.Id;
      if (deliveryNote.Building != null)
        result.Building_Id = deliveryNote.Building.Id;

      result.Amount = deliveryNote.Amount;
      result.Canceled = deliveryNote.Canceled;
      result.DateDrawing = deliveryNote.DateDrawing;
      result.DateOfArrival = deliveryNote.DateOfArrival;
      result.Drawer = deliveryNote.Drawer;      
      return result;
    }

    public static RecipeComponent CopyWithOutReferences(this RecipeComponent recipeComponent)
    {
      RecipeComponent result = new RecipeComponent();
      if (recipeComponent.Material != null)
        result.Material_Id = recipeComponent.Material.Id;
      if (recipeComponent.Recipe != null)
        result.Recipe_Id = recipeComponent.Recipe.Id;
      result.Amount = recipeComponent.Amount;
      return result;
    }
    
  }
}
