using SmartWorking.Office.PrimitiveEntities.Enums;
using SmartWorking.Office.PrimitiveEntities.Packages;

namespace SmartWorking.Office.TabsGui.Controls.DeliveryNotes
{
  public class DeliveryNoteDataContextForDocument
  {
    public string Client { get; set; }
    public string Building { get; set; }
    public string DeliveryNoteNumber { get; set; }
    public string DeliveryNoteDateDrawing { get; set; }
    public string DeliveryNoteAmount { get; set; }
    public string DeliveryNoteCar { get; set; }
    public string DeliveryNoteDriver { get; set; }
    public string DeliveryNoteLoadingDate { get; set; }
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
    

    public static DeliveryNoteDataContextForDocument Load(DeliveryNotePackageForDocument deliveryNotePackageForDocument)
    {
      if (deliveryNotePackageForDocument == null)
        return null;
      DeliveryNoteDataContextForDocument result = new DeliveryNoteDataContextForDocument();
      if (deliveryNotePackageForDocument.Client != null)
      {
        result.Client = deliveryNotePackageForDocument.Client.Name + "\nNIP: " + deliveryNotePackageForDocument.Client.NIP + "\n" + "\n\nTel. " + deliveryNotePackageForDocument.Client.Phone;
      }
      if (deliveryNotePackageForDocument.Building != null)
      {
        result.Building = deliveryNotePackageForDocument.Building.ContactPerson + "\n" + deliveryNotePackageForDocument.Building.Name
                          + "\n\nTel. " + deliveryNotePackageForDocument.Building.ContactPersonPhone;
      }
      if (deliveryNotePackageForDocument.DeliveryNote != null )
      {
        result.DeliveryNoteNumber = deliveryNotePackageForDocument.DeliveryNote.Number + "/" +
                                    deliveryNotePackageForDocument.DeliveryNote.Year;

        result.DeliveryNoteAmount = (deliveryNotePackageForDocument.DeliveryNote.Amount != null &&
                                     deliveryNotePackageForDocument.DeliveryNote.Amount.HasValue)
                                      ? deliveryNotePackageForDocument.DeliveryNote.Amount.Value.ToString("f2") + "m3"
                                      : string.Empty;

        result.DeliveryNoteDateDrawing = (deliveryNotePackageForDocument.DeliveryNote.DateDrawing != null &&
                                          deliveryNotePackageForDocument.DeliveryNote.DateDrawing.HasValue)
                                           ? deliveryNotePackageForDocument.DeliveryNote.DateDrawing.Value.ToShortDateString()
                                           : string.Empty;
        result.DeliveryNoteLoadingDate = (deliveryNotePackageForDocument.DeliveryNote.DateDrawing != null &&
                                          deliveryNotePackageForDocument.DeliveryNote.DateDrawing.HasValue)
                                           ? deliveryNotePackageForDocument.DeliveryNote.DateDrawing.Value.Date.ToShortDateString() + "\n" +
                                              deliveryNotePackageForDocument.DeliveryNote.DateDrawing.Value.ToShortTimeString()
                                           : string.Empty;
        if (deliveryNotePackageForDocument.Car != null)
        {
          result.DeliveryNoteCar = deliveryNotePackageForDocument.Car.RegistrationNumber;
        }
        if (deliveryNotePackageForDocument.Driver != null)
        {
          result.DeliveryNoteDriver = deliveryNotePackageForDocument.Driver.Name;
        }
      }

      if (deliveryNotePackageForDocument.RecipePackage != null && deliveryNotePackageForDocument.RecipePackage.Recipe != null)
      {
        result.RecipeCode = deliveryNotePackageForDocument.RecipePackage.Recipe.Code;
        result.RecipeConcreteClass = deliveryNotePackageForDocument.RecipePackage.Recipe.ConcreteClass;
        result.RecipeGranulation = deliveryNotePackageForDocument.RecipePackage.Recipe.Granulation;
        result.RecipeStrengthClass = deliveryNotePackageForDocument.RecipePackage.Recipe.StrengthClass;
        result.RecipeStrengthProgress = deliveryNotePackageForDocument.RecipePackage.Recipe.StrengthProgress.ToString();
        if (deliveryNotePackageForDocument.RecipePackage.RecipeComponentAndMaterialList != null)
        {
          foreach (var recipeComponent in deliveryNotePackageForDocument.RecipePackage.RecipeComponentAndMaterialList)
          {
            if (recipeComponent != null && recipeComponent.MaterialAndContractors != null &&
              recipeComponent.MaterialAndContractors.Material != null && recipeComponent.MaterialAndContractors.Material.MaterialType.HasValue 
              &&  recipeComponent.MaterialAndContractors.Material.MaterialType.Value == (int)MaterialTypeEnum.Concrete)
            {
              result.RecipeConcreteKgToM3 = recipeComponent.MaterialAndContractors.Material.Name;
            }
          }
        }

      }

      if (deliveryNotePackageForDocument.Order != null)
      {
        result.OrderAmount = (deliveryNotePackageForDocument.Order.Amount.ToString());
        result.OrderNotice = deliveryNotePackageForDocument.Order.Notice;
        result.OrderPump = (deliveryNotePackageForDocument.Order.Pump.HasValue && deliveryNotePackageForDocument.Order.Pump.Value != 0) ? "Tak" : "Nie";
      }
      return result;
    }
  }
}