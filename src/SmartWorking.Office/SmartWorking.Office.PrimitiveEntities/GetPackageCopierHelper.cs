using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public static class GetPackageCopierHelper
  {
    public static CarAndDriverPackage GetPackageCopy(this CarAndDriverPackage source)
    {
      CarAndDriverPackage package = new CarAndDriverPackage();
      package.Driver = source.Driver.GetPrimitiveCopy();
      package.Car = source.Car.GetPrimitiveCopy();
      return package;
    }

    public static DriverAndCarsPackage GetPackageCopy(this DriverAndCarsPackage source)
    {
      DriverAndCarsPackage package = new DriverAndCarsPackage();
      package.Driver = source.Driver.GetPrimitiveCopy();

      foreach (CarPrimitive carPrimitive in source.Cars)
      {
        package.Cars.Add(carPrimitive.GetPrimitiveCopy());  
      }
      return package;
    }
    public static MaterialAndContractorsPackage GetPackageCopy(this MaterialAndContractorsPackage source)
    {
      MaterialAndContractorsPackage package = new MaterialAndContractorsPackage();
      package.Material = source.Material.GetPrimitiveCopy();
      package.Deliverer = source.Deliverer.GetPrimitiveCopy();
      package.Producer = source.Producer.GetPrimitiveCopy();
      return package;
    }

    public static RecipeComponentAndMaterialPackage GetPackageCopy(this RecipeComponentAndMaterialPackage source)
    {
      RecipeComponentAndMaterialPackage package = new RecipeComponentAndMaterialPackage();
      package.RecipeComponent = source.RecipeComponent.GetPrimitiveCopy();
      package.MaterialAndContractors = source.MaterialAndContractors.GetPackageCopy();
      return package;
    }

    public static RecipePackage GetPackageCopy(this RecipePackage source)
    {
      RecipePackage package = new RecipePackage();
      package.Recipe = source.Recipe.GetPrimitiveCopy();
      foreach (RecipeComponentAndMaterialPackage recipeComponentAndMaterialPackage in source.RecipeComponentAndMaterialList)
      {
        package.RecipeComponentAndMaterialList.Add(recipeComponentAndMaterialPackage.GetPackageCopy());
      }
      return package;
    }

    public static ClientAndClientBuildingsPackage GetPackageCopy(this ClientAndClientBuildingsPackage source)
    {
      ClientAndClientBuildingsPackage result = new ClientAndClientBuildingsPackage();
      if (source != null)
      {
        if (source.Client != null)
        {
          result.Client = source.Client.GetPrimitiveCopy();
          foreach (ClientBuildingAndBuildingPackage clientBuildingAndBuildingPackage in source.ClientBuildings)
          {
            result.ClientBuildings.Add(clientBuildingAndBuildingPackage.GetPackageCopy());
          }
        }
      }
      return result;
    }

    public static ClientBuildingAndBuildingPackage GetPackageCopy(this ClientBuildingAndBuildingPackage source)
    {
      if (source == null)
        return null;

      ClientBuildingAndBuildingPackage package = new ClientBuildingAndBuildingPackage();
      if (source.ClientBuilding != null)
      {
        package.ClientBuilding = source.ClientBuilding.GetPrimitiveCopy();
        
      }
      //package.Client = source.Client.GetPrimitiveCopy();
      if (source.Building != null)
      {
        package.Building = source.Building.GetPrimitiveCopy();
      }
      return package;
    }

    public static OrderPackage GetPackageCopy(this OrderPackage source)
    {
      if (source == null || source.Order == null)
        return null;
      OrderPackage package = new OrderPackage();

      package.Order = source.Order.GetPrimitiveCopy();
      if (source.Recipe != null)
      {
        package.Recipe = source.Recipe.GetPrimitiveCopy();
      }

      if (source.ClientBuildingPackage != null)
      {
        package.ClientBuildingPackage = source.ClientBuildingPackage.GetPackageCopy();
      }

      if (source.Client != null)
      {
        package.Client = source.Client.GetPrimitiveCopy();
      }
      return package;
    }
  }
}
