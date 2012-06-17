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
      result.Id = deliveryNote.Id;  
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
      result.Id = recipeComponent.Id;
      return result;
    }

    public static Building CopyWithOutReferences(this Building building)
    {
      Building result = new Building();
      if (building.Contractor != null)
        result.Contractor_Id = building.Contractor.Id;

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
