using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Entities
{
  public static class GetPackageHelper
  {
    public static ClientAndBuildingsPackage GetClientAndBuildingsPackage(this Client client)
    {
      ClientAndBuildingsPackage result = new ClientAndBuildingsPackage();
      if (client != null)
        result.Client = client.GetPrimitive();
      foreach (Building building in client.Buildings)
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
        //if (deliveryNote.Recipe != null)
        //{
        //  result.Recipe = deliveryNote.Recipe.GetPrimitive();
        //}
        //if (deliveryNote.Building != null)
        //{
        //  result.BuildingAndContractor = deliveryNote.Building.GetBuildingAndContractorPackage();
        //}
      }
      return result;
    }

    public static BuildingAndClientPackage GetBuildingAndContractorPackage(this Building building)
    {
      BuildingAndClientPackage result = new BuildingAndClientPackage();

      if (building != null)
      {
        result.Building = building.GetPrimitive();
        //if (building.Contractor != null)
        //{
        //  result.Contractor = building.Contractor.GetPrimitive();
        //}
      }
      return result;
    }

    public static DriverAndCarPackage GetDriverAndCarPackage(this Driver driver)
    {
      DriverAndCarPackage result = new DriverAndCarPackage();

      if (driver != null)
      {
        result.Driver = driver.GetPrimitive();
        if (driver.Car != null)
        {
          result.Car = driver.Car.GetPrimitive();
        }
      }
      return result;
    }

    public static MaterialAndContractorsPackage GetMaterialAndContractorsPackage(this Material material)
    {
      MaterialAndContractorsPackage result = new MaterialAndContractorsPackage();
      if (material != null)
      {
        result.Material = material.GetPrimitive();
        if (material.Contractor != null)
        {
          result.Producer = material.Contractor.GetPrimitive();
        }
      }
      return result;
    }
  }
}
