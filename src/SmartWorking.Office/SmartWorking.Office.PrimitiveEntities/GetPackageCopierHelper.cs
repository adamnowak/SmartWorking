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
      package.Driver = source.Driver;

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

    public static ClientAndBuildingsPackage GetPackageCopy(this ClientAndBuildingsPackage source)
    {
      ClientAndBuildingsPackage package = new ClientAndBuildingsPackage();
      if (source != null)
      {
        if (source.Client != null)
        {
          package.Client = source.Client.GetPrimitiveCopy();
          foreach (BuildingPrimitive building in source.Buildings)
          {
            source.Buildings.Add(building.GetPrimitiveCopy());
          }
        }
      }
      return package;
    }

    public static ClientBuildingPackage GetPackageCopy(this ClientBuildingPackage source)
    {
      ClientBuildingPackage package = new ClientBuildingPackage();
      package.ClientBuilding = source.ClientBuilding.GetPrimitiveCopy();
      package.Client = source.Client.GetPrimitiveCopy();
      package.Building = source.Building.GetPrimitiveCopy();
      return package;
    }

    public static OrderPackage GetPackageCopy(this OrderPackage source)
    {
      OrderPackage package = new OrderPackage();
      package.Order = source.Order.GetPrimitiveCopy();
      package.Recipe = source.Recipe.GetPrimitiveCopy();
      package.BuildingAndContractor = source.BuildingAndContractor.GetPackageCopy();
      return package;
    }
  }
}
