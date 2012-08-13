using SmartWorking.Office.PrimitiveEntities.Packages;

namespace SmartWorking.Office.TabsGui.Controls.Orders
{
  public class OrderDetailsDataContextForDocument
  {
    public string Client { get; set; }
    public string Building { get; set; }
    public string DeliveryNoteNumber { get; set; }
    public string DeliveryNoteDateDrawing { get; set; }
    public string DeliveryNoteAmount { get; set; }
    public string DeliveryNoteCar { get; set; }
    public string DeliveryNoteDriver { get; set; }
    public string RecipeCode { get; set; }
    public string RecipeConcreteClass { get; set; }
    public string RecipeStrengthClass { get; set; }
    public string RecipeGranulation { get; set; }
    public string RecipeConsistency { get; set; }
    public string RecipeWaterToCement { get; set; }
    public string RecipeWater { get; set; }//???
    public string RecipeStrengthProgress { get; set; }    
    public string RecipeConcreteKgToM3 { get; set; }
    public string RecipeSuplementKgToM3 { get; set; }
    public string RecipeAdmixtureKgToM3 { get; set; }
    public string RecipeConcreteProducer { get; set; }
    public string RecipeSuplementProducer { get; set; }
    public string RecipeAdmixtureProducer { get; set; }
    public string OrderNotice { get; set; }
    public string OrderAmount { get; set; }
    public string OrderPump { get; set; }
    public string OrderSumaryDelivered { get; set; }
    public string OrderSumaryRemainToDeliver { get; set; }
    public string DeliveryNoteLoadingDate { get; set; }

    public static OrderDetailsDataContextForDocument Load(OrderPackage item, DeliveryNotePackage deliveryNotePackage)
    {
      if (item == null)
        return null;
      OrderDetailsDataContextForDocument result = new OrderDetailsDataContextForDocument();
      if (item.Client != null)
      {
        result.Client = item.Client.Name + "\nNIP: " + item.Client.NIP + "\n" + "\n\nTel. " + item.Client.Phone;
      }
      if (item.ClientBuildingPackage != null && item.ClientBuildingPackage.Building != null)
      {
        result.Building = item.ClientBuildingPackage.Building.ContactPerson + "\n" + item.ClientBuildingPackage.Building.Name
                          + "\n\nTel. " + item.ClientBuildingPackage.Building.ContactPersonPhone;
      }
      if (deliveryNotePackage != null && deliveryNotePackage.DeliveryNote != null)
      {
        result.DeliveryNoteNumber = deliveryNotePackage.DeliveryNote.Number + "/" +
                                    deliveryNotePackage.DeliveryNote.Year;
        
        result.DeliveryNoteAmount = (deliveryNotePackage.DeliveryNote.Amount != null &&
                                     deliveryNotePackage.DeliveryNote.Amount.HasValue)
                                      ? deliveryNotePackage.DeliveryNote.Amount.Value.ToString("f2") + "m3"
                                      : string.Empty;

        result.DeliveryNoteDateDrawing = (deliveryNotePackage.DeliveryNote.DateDrawing != null &&
                                          deliveryNotePackage.DeliveryNote.DateDrawing.HasValue)
                                           ? deliveryNotePackage.DeliveryNote.DateDrawing.Value.ToShortDateString()
                                           : string.Empty;

        if (deliveryNotePackage.CarAndDriver != null)
        {
          result.DeliveryNoteCar = (deliveryNotePackage.CarAndDriver.Car != null)
                                     ? deliveryNotePackage.CarAndDriver.Car.RegistrationNumber
                                     : string.Empty;
          result.DeliveryNoteDriver = (deliveryNotePackage.CarAndDriver.Driver != null)
                                     ? deliveryNotePackage.CarAndDriver.Driver.Name
                                     : string.Empty;
        }
      }

      if (item.Recipe != null)
      {
        result.RecipeCode = item.Recipe.Code;
        result.RecipeConcreteClass = item.Recipe.ConcreteClass;
        result.RecipeGranulation = item.Recipe.Granulation;
        result.RecipeStrengthClass = item.Recipe.StrengthClass;
        result.RecipeStrengthProgress = item.Recipe.StrengthProgress.ToString();
        

      }

      if (item.Order != null)
      {
        result.OrderAmount = (item.Order.Amount.ToString());
        result.OrderNotice = item.Order.Notice;
        result.OrderPump = (item.Order.Pump.HasValue && item.Order.Pump.Value != 0) ? "Tak" : "Nie";
      }
      return result;
    }
  }
}