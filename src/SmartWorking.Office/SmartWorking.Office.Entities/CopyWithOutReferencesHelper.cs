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
      else
        result.Car_Id = deliveryNote.Car_Id;

      if (deliveryNote.Driver != null)
        result.Driver_Id = deliveryNote.Driver.Id;
      else
        result.Driver_Id = deliveryNote.Driver_Id;

      if (deliveryNote.Recipe != null)
        result.Recipe_Id = deliveryNote.Recipe.Id;
      else
        result.Recipe_Id = deliveryNote.Recipe_Id;

      if (deliveryNote.Building != null)
        result.Building_Id = deliveryNote.Building.Id;
      else
        result.Building_Id = deliveryNote.Building_Id;

      result.Amount = deliveryNote.Amount;
      result.Canceled = deliveryNote.Canceled;
      result.DateDrawing = deliveryNote.DateDrawing;
      result.DateOfArrival = deliveryNote.DateOfArrival;
      result.Drawer = deliveryNote.Drawer;
      result.Id = deliveryNote.Id;  
      return result;
    }

    public static RecipeComponent CopyWithOutReferences(this RecipeComponent recipeComponent)
    {
      RecipeComponent result = new RecipeComponent();
      if (recipeComponent.Material != null)
        result.Material_Id = recipeComponent.Material.Id;
      else
        result.Material_Id = recipeComponent.Material_Id;

      if (recipeComponent.Recipe != null)
        result.Recipe_Id = recipeComponent.Recipe.Id;
      else
        result.Recipe_Id = recipeComponent.Recipe_Id;

      result.Amount = recipeComponent.Amount;
      result.Id = recipeComponent.Id;
      return result;
    }

    public static Building CopyWithOutReferences(this Building building)
    {
      Building result = new Building();
      if (building.Contractor != null)
        result.Contractor_Id = building.Contractor.Id;
      else
        result.Contractor_Id = building.Contractor_Id;

      result.City = building.City;
      result.HouseNo = building.HouseNo;
      result.Street = building.Street;

      result.Id = building.Id;
      return result;
    }

    public static Contractor CopyWithOutReferences(this Contractor contractor)
    {
      Contractor result = new Contractor();

      result.FullName = contractor.FullName;

      result.Name = contractor.Name;
      result.Phone = contractor.Phone;
      result.Surname = contractor.Surname;

      result.Id = contractor.Id;
      return result;
    }
  }
}
