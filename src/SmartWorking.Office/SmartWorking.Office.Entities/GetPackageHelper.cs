﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;

namespace SmartWorking.Office.Entities
{
  public static class GetPackageHelper
  {
    public static ClientBuildingAndBuildingPackage GetClientBuildingAndBuildingPackage(this ClientBuilding clientBuilding)
    {
      ClientBuildingAndBuildingPackage result = new ClientBuildingAndBuildingPackage();
      if (clientBuilding != null)
      {
        result.ClientBuilding = clientBuilding.GetPrimitive();
        if (clientBuilding.Building != null)
        {
          result.Building = clientBuilding.Building.GetPrimitive();
        }
      }
      return result;
    }

    public static ClientAndClientBuildingsPackage GetClientAndBuildingsPackage(this Client client)
    {
      ClientAndClientBuildingsPackage result = new ClientAndClientBuildingsPackage();
      if (client != null)
      {
        result.Client = client.GetPrimitive();
        if (client.ClientBuildings != null)
        {
          foreach (ClientBuilding clientBuilding in client.ClientBuildings)
          {
            if (clientBuilding != null && clientBuilding.Building != null)
              result.ClientBuildings.Add(clientBuilding.GetClientBuildingAndBuildingPackage());
          }
        }
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
          result.CarAndDriver = new CarAndDriverPackage();
          result.CarAndDriver.Car = deliveryNote.Car.GetPrimitive();
          if (deliveryNote.Car.Driver != null)
          {
            result.CarAndDriver.Driver = deliveryNote.Car.Driver.GetPrimitive();
          }
        }
        if (deliveryNote.Driver != null)
        {
          result.Driver = deliveryNote.Driver.GetPrimitive();
        }
        if (deliveryNote.Order != null)
        {
          result.Order = deliveryNote.Order.GetPrimitive();
        }
        //if (deliveryNote.Building != null)
        //{
        //  result.BuildingAndContractor = deliveryNote.Building.GetBuildingAndContractorPackage();
        //}
      }
      return result;
    }

    public static DeliveryNoteReportPackage GetDeliveryNoteReportPackage(this DeliveryNote deliveryNote)
    {
      DeliveryNoteReportPackage result = new DeliveryNoteReportPackage();

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
        if (deliveryNote.Order != null)
        {
          result.Order = deliveryNote.Order.GetPrimitive();
          if (deliveryNote.Order.ClientBuilding != null)
          {
            if (deliveryNote.Order.ClientBuilding.Client != null)
            {
              result.Client = deliveryNote.Order.ClientBuilding.Client.GetPrimitive();
            }
            if (deliveryNote.Order.ClientBuilding.Building != null)
            {
              result.Building = deliveryNote.Order.ClientBuilding.Building.GetPrimitive();
            }
          }
          if (deliveryNote.Order.Recipe != null)
          {
            result.Recipe = deliveryNote.Order.Recipe.GetPrimitive();
          }
        }
        
      }
      return result;
    }

    public static ClientBuildingAndBuildingPackage GetBuildingAndContractorPackage(this Building building)
    {
      ClientBuildingAndBuildingPackage result = new ClientBuildingAndBuildingPackage();

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

    public static OrderPackage GetOrderPackage(this Order order)
    {
      OrderPackage result = new OrderPackage();
      if (order != null)
      {
        result.Order = order.GetPrimitive();
        if (order.Recipe != null)
        {
          result.Recipe = order.Recipe.GetPrimitive();
        }
        if (order.ClientBuilding != null)
        {
          result.ClientBuildingPackage = new ClientBuildingAndBuildingPackage();
          result.ClientBuildingPackage.ClientBuilding = order.ClientBuilding.GetPrimitive();
          if (order.ClientBuilding.Building != null)
          {
            result.ClientBuildingPackage.Building = order.ClientBuilding.Building.GetPrimitive();
          }
          if (order.ClientBuilding.Client != null)
          {
            result.Client = order.ClientBuilding.Client.GetPrimitive();
          }
        }

        if (order.DeliveryNotes != null)
        {
          foreach (DeliveryNote deliveryNote in order.DeliveryNotes)
          {
            result.DeliveryNotePackageList.Add(deliveryNote.GetDeliveryNotePackage());  
          }
          
        }
        
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

    public static UserAndRolesPackage GetUserAndRolesPackage(this User user)
    {
      UserAndRolesPackage result = new UserAndRolesPackage();
      if (user != null)
      {
        result.User = user.GetPrimitive();
        if (user.Roles != null)
        {
          foreach (Role role in user.Roles)
          {
            result.Roles.Add(role.GetPrimitive());
          }
        }
      }
      return result;
    }
  }
}
