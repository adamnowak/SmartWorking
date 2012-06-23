using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Entities
{
  public static class GetPackageHelper
  {
    public static ContractorAndBuildingsPackage GetContractorAndBuildingsPackage(this Contractor contractor)
    {
      ContractorAndBuildingsPackage result = new ContractorAndBuildingsPackage();
      if (contractor != null)
        result.Contractor = contractor.GetPrimitive();
      foreach (Building building in contractor.Buildings)
      {
        if (building != null)
          result.Buildings.Add(building.GetPrimitive());
      }
      return result;
    }

    public static RecipeComponentAndMaterialPackage GetRecipeComponentAndMaterialPackage(this RecipeComponent recipeComponent)
    {
      RecipeComponentAndMaterialPackage result = new RecipeComponentAndMaterialPackage();
      if (recipeComponent != null)
        result.RecipeComponent = recipeComponent.GetPrimitive();
      if (recipeComponent.Material != null)
        result.Material = recipeComponent.Material.GetPrimitive();
      return result;
    }

    public static RecipePackage GetRecipesPackage(this Recipe recipe)
    {
      RecipePackage result = new RecipePackage();
      if (recipe != null)
        result.Recipe = recipe.GetPrimitive();
      foreach (RecipeComponent recipeComponent in recipe.RecipeComponents)
      {
        if (recipeComponent != null)
          result.RecipeComponentAndMaterialList.Add(recipeComponent.GetRecipeComponentAndMaterialPackage());
      }
      
      return result;
    }

    public static DeliveryNotePackage GetDeliveryNotePackage(this DeliveryNote deliveryNote)
    {
      DeliveryNotePackage result = new DeliveryNotePackage();

      if (deliveryNote != null)
      {
        result.DeliveryNote = deliveryNote.GetPrimitive();
        if (deliveryNote.Car != null)
        {
          result.Car = deliveryNote.Car.GetPrimitive();
        }
        if (deliveryNote.Driver != null)
        {
          result.Driver = deliveryNote.Driver.GetPrimitive();
        }
        if (deliveryNote.Recipe != null)
        {
          result.Recipe = deliveryNote.Recipe.GetPrimitive();
        }
        if (deliveryNote.Building != null)
        {
          result.BuildingAndContractor = deliveryNote.Building.GetBuildingAndContractorPackage();
        }
      }
      return result;
    }

    public static BuildingAndContractorPackage GetBuildingAndContractorPackage(this Building building)
    {
      BuildingAndContractorPackage result = new BuildingAndContractorPackage();

      if (building != null)
      {
        result.Building = building.GetPrimitive();
        if (building.Contractor != null)
        {
          result.Contractor = building.Contractor.GetPrimitive();
        }
      }
      return result;
    }
  }
}
