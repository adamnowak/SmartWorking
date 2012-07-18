using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
        if (deliveryNote.Car != null)
        {
          result.Car_Id = deliveryNote.Car.Id;
        }
        if (deliveryNote.Driver != null)
        {
          result.Driver_Id = deliveryNote.Driver.Id;
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
      if (materialAndContractorsPackage.Producer != null)
      {
        result.Producer_Id = materialAndContractorsPackage.Producer.Id;
      }
      return result;
    }

    public static BuildingPrimitive GetBuildingPrimitiveWithReference(this BuildingAndClientPackage buildingAndClientPackage)
    {
      if (buildingAndClientPackage == null || buildingAndClientPackage.Building == null)
        return null;
      BuildingPrimitive result = buildingAndClientPackage.Building;
      if (buildingAndClientPackage.Client != null)
      {
        result.Client_Id = buildingAndClientPackage.Client.Id;
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
      return result;
    }
  }
}
