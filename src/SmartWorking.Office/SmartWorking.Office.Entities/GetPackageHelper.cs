﻿using System;
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
        result.MaterialAndContractors = recipeComponent.Material.GetMaterialAndContractorsPackage();
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

    public static CarAndDriverPackage GetCarAndDriverPackage(this Car car)
    {
      CarAndDriverPackage result = new CarAndDriverPackage();

      if (car != null)
      {
        result.Car = car.GetPrimitive();
        if (car.Driver != null)
        {
          result.Driver = car.Driver.GetPrimitive();
        }
      }
      return result;
    }

    public static DriverAndCarsPackage GetDriverAndCarsPackage(this Driver driver)
    {
      DriverAndCarsPackage result = new DriverAndCarsPackage();

      if (driver != null)
      {
        result.Driver = driver.GetPrimitive();
        
        if (driver.Cars != null)
        {
          foreach(Car car in driver.Cars)
          {
            result.Cars.Add(car.GetPrimitive());
          }          
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
        if (material.Producer != null)
        {
          result.Producer = material.Producer.GetPrimitive();
        }
        if (material.Deliverer != null)
        {
          result.Deliverer = material.Deliverer.GetPrimitive();
        }
      }
      return result;
    }
  }
}
