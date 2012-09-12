using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.PrimitiveEntities.Packages;


namespace SmartWorking.Office.PrimitiveEntities
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
        if (deliveryNote.CarAndDriver != null && deliveryNote.CarAndDriver.Car != null)
        {
          result.Car_Id = deliveryNote.CarAndDriver.Car.Id;
        }
        if (deliveryNote.Driver != null)
        {
          result.Driver_Id = deliveryNote.Driver.Id;
        }
        if (deliveryNote.Order != null)
        {
          result.Order_Id = deliveryNote.Order.Id;
        }
        //if (deliveryNote.Recipe != null)
        //{
        //  result.Recipe_Id = deliveryNote.Recipe.Id;
        //}
        //if (deliveryNote.BuildingAndContractor != null && deliveryNote.BuildingAndContractor.Building != null)
        //{
        //  result.Building_Id = deliveryNote.BuildingAndContractor.Building.Id;
        //}
      }
      return result;
    }

    public static CarPrimitive GetCarPrimitiveWithReference(this CarAndDriverPackage carAndDriverPackage)
    {
      if (carAndDriverPackage == null || carAndDriverPackage.Car == null)
        return null;
      CarPrimitive result = carAndDriverPackage.Car;
      if (carAndDriverPackage.Driver != null)
      {
        result.Driver_Id = carAndDriverPackage.Driver.Id;
      }
      else
      {
        result.Driver_Id = null;
      }
      return result;
    }

    public static MaterialPrimitive GetMaterialPrimitiveWithReference(this MaterialAndContractorsPackage materialAndContractorsPackage)
    {
      if (materialAndContractorsPackage == null || materialAndContractorsPackage.Material == null)
        return null;
      MaterialPrimitive result = materialAndContractorsPackage.Material;
      if (materialAndContractorsPackage.Deliverer != null)
      {
        result.Deliverer_Id = materialAndContractorsPackage.Deliverer.Id;
      }
      else
      {
        result.Deliverer_Id = null;
      }
      if (materialAndContractorsPackage.Producer != null)
      {
        result.Producer_Id = materialAndContractorsPackage.Producer.Id;
      }
      else
      {
        result.Producer_Id = null;
      }
      return result;
    }

    public static ClientBuildingPrimitive GetClientBuildingPrimitiveWithReference(this ClientBuildingAndBuildingPackage clientBuildingPackage)
    {
      if (clientBuildingPackage == null || clientBuildingPackage.ClientBuilding == null)
        return null;
      ClientBuildingPrimitive result = clientBuildingPackage.ClientBuilding;
      //if (clientBuildingPackage.Client != null)
      //{
      //  result.Client_Id = clientBuildingPackage.Client.Id;
      //}
      if (clientBuildingPackage.Building != null)
      {
        result.Building_Id = clientBuildingPackage.Building.Id;
      }
      return result;
    }

    public static OrderPrimitive GetOrderPrimitiveWithReference(this OrderPackage orderPackage)
    {
      if (orderPackage == null || orderPackage.Order == null)
        return null;
      OrderPrimitive result = orderPackage.Order;
      
      if (orderPackage.Recipe != null)
      {
        result.Recipe_Id = orderPackage.Recipe.Id;
      }
      else
      {
        result.Recipe_Id = null;
      }

      if (orderPackage.ClientBuildingPackage != null && orderPackage.ClientBuildingPackage.ClientBuilding != null)
      {
        result.ClientBuilding_Id = orderPackage.ClientBuildingPackage.ClientBuilding.Id;
      }
      else
      {
        result.ClientBuilding_Id = null;
      }


      return result;
    }

    public static RecipeComponentPrimitive GetRecipeComponentPrimitiveWithReference(this RecipeComponentAndMaterialPackage recipeComponentAndMaterialPackage)
    {
      if (recipeComponentAndMaterialPackage == null || recipeComponentAndMaterialPackage.RecipeComponent == null)
        return null;
      RecipeComponentPrimitive result = recipeComponentAndMaterialPackage.RecipeComponent;
      if (recipeComponentAndMaterialPackage.MaterialAndContractors != null && recipeComponentAndMaterialPackage.MaterialAndContractors.Material != null)
      {
        result.Material_Id = recipeComponentAndMaterialPackage.MaterialAndContractors.Material.Id;
      }
      
      return result;
    }

    public static List<ClientBuildingPrimitive> GetClientBuildingListWithReference(this ClientAndClientBuildingsPackage clientAndClientBuildingsPackage)
    {
      List<ClientBuildingPrimitive> result = clientAndClientBuildingsPackage.ClientBuildings.Select(x => x.GetClientBuildingPrimitiveWithReference()).ToList();
      if (clientAndClientBuildingsPackage.Client != null)
      {
        foreach (ClientBuildingPrimitive item in result)
        {
          item.Client_Id = clientAndClientBuildingsPackage.Client.Id;
        }
      }
      return result;
    }

    public static List<RecipeComponentPrimitive> GetRecipeComponentListWithReference(this RecipePackage recipePackage)
    {
      List<RecipeComponentPrimitive> result = recipePackage.RecipeComponentAndMaterialList.Select(x => x.GetRecipeComponentPrimitiveWithReference()).ToList();
      if (recipePackage.Recipe != null)
      {
        foreach (RecipeComponentPrimitive item in result)
        {
          item.Recipe_Id = recipePackage.Recipe.Id;
        }
      }
      return result;
    }
    //public static ClientBuildingPrimitive GetClientBuildingPrimitiveWithReference(this ClientBuildingPackage clientAndBuildingsPackage)
    //{
    //  if (clientAndBuildingsPackage == null || clientAndBuildingsPackage.ClientBuilding == null)
    //    return null;
    //  ClientBuildingPrimitive result = clientAndBuildingsPackage.ClientBuilding;
    //  if (clientAndBuildingsPackage.Building != null)
    //  {
    //    result.Building_Id = clientAndBuildingsPackage.Building.Id;
    //  }
    //  else
    //  {
    //    result.Building_Id = null;        
    //  }

    //  return result;
    //}

    //GetClientBuildingListWithReference

    //public static List<RolePrimitive> GetRoleListWithReference(this UserAndRolesPackage userAndRolesPackage)
    //{
    //  List<RolePrimitive> result = userAndRolesPackage.Roles.Select(x => x.GetRecipeComponentPrimitiveWithReference()).ToList();
    //  if (userAndRolesPackage.Roles != null)
    //  {
    //    foreach (RolePrimitive item in result)
    //    {
    //      item. = recipePackage.Recipe.Id;
    //    }
    //  }
    //  return result;
    //}
  }
}
