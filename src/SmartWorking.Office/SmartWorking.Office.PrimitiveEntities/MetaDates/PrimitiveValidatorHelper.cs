using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading;

namespace SmartWorking.Office.PrimitiveEntities.MetaDates
{
  public static class PrimitiveValidatorHelper
  {
    static PrimitiveValidatorHelper()
    {
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(BuildingPrimitive), typeof(BuildingMetaData)), typeof(BuildingPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(CarPrimitive), typeof(CarMetaData)), typeof(CarPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ClientBuildingPrimitive), typeof(ClientBuildingMetaData)), typeof(ClientBuildingPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ClientPrimitive), typeof(ClientMetaData)), typeof(ClientPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(ContractorPrimitive), typeof(ContractorMetaData)), typeof(ContractorPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(DeliveryNotePrimitive), typeof(DeliveryNoteMetaData)), typeof(DeliveryNotePrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(DriverPrimitive), typeof(DriverMetaData)), typeof(DriverPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(MaterialPrimitive), typeof(MaterialMetaData)), typeof(MaterialPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(OrderPrimitive), typeof(OrderMetaData)), typeof(OrderPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(RecipeComponentPrimitive), typeof(RecipeComponentMetaData)), typeof(RecipeComponentPrimitive));
      TypeDescriptor.AddProviderTransparent(
            new AssociatedMetadataTypeTypeDescriptionProvider(typeof(RecipePrimitive), typeof(RecipeMetaData)), typeof(RecipePrimitive));
    }

    #region Car Client Side Validation
    private static bool ValidateClientSide(this CarPrimitive primitiveToValidate, List<ValidationResult> validationResults, CultureInfo cultureInfo)
    {
      bool result = true;
      if (primitiveToValidate.InternalName == null || primitiveToValidate.InternalName.Trim().Length <= 0)
      {
        validationResults.Add(new ValidationResult("Symbol musi być ustawiony."));
        result = false;
      }
      if (primitiveToValidate.RegistrationNumber == null ||primitiveToValidate.RegistrationNumber.Trim().Length <= 0)
      {
        validationResults.Add(new ValidationResult("Numer rejestracyjny musi być ustawiony."));
        result = false;
      }
      
      if (primitiveToValidate.Capacity == null || !primitiveToValidate.Capacity.HasValue)
      {
        validationResults.Add(new ValidationResult("Ładowność musi być ustawiona."));
        result = false;
      }
      else
      {
        if (primitiveToValidate.Capacity == null || primitiveToValidate.Capacity.Value <= 0)
        {
          validationResults.Add(new ValidationResult("Ładowność musi być dodatnia."));
          result = false;
        }
      }

      if (primitiveToValidate.CarType == null || !primitiveToValidate.CarType.HasValue)
      {
        validationResults.Add(new ValidationResult("Typ samochodu musi być ustawiony."));
        result = false;
      }

      if (primitiveToValidate.TransportType == null || !primitiveToValidate.TransportType.HasValue)
      {
        validationResults.Add(new ValidationResult("Rodzaj transportu musi być ustawiony."));
        result = false;
      }
      return result;
    }

    public static List<ValidationResult> ValidateClientSide(this CarPrimitive primitiveToValidate, CultureInfo cultureInfo)
    {
      if (primitiveToValidate == null)
        return null;
      List<ValidationResult> res = new List<ValidationResult>();
      bool valid = Validator.TryValidateObject(primitiveToValidate, new ValidationContext(primitiveToValidate, null, null), res, true);
      valid = valid && primitiveToValidate.ValidateClientSide(res, cultureInfo);
      return res;
    }

    public static List<ValidationResult> ValidateClientSide(this CarPrimitive primitiveToValidate)
    {
      return ValidateClientSide(primitiveToValidate, Thread.CurrentThread.CurrentUICulture);
    }
    #endregion //Car Client Side Validation


    #region DeliveryNote Client Side Validation
    private static bool ValidateClientSide(this DeliveryNotePrimitive primitiveToValidate, List<ValidationResult> validationResults, CultureInfo cultureInfo)
    {
      bool result = true;
      //if (primitiveToValidate.InternalName == null || primitiveToValidate.InternalName.Trim().Length <= 0)
      //{
      //  validationResults.Add(new ValidationResult("Symbol musi być ustawiony."));
      //  result = false;
      //}
      //if (primitiveToValidate.RegistrationNumber == null || primitiveToValidate.RegistrationNumber.Trim().Length <= 0)
      //{
      //  validationResults.Add(new ValidationResult("Numer rejestracyjny musi być ustawiony."));
      //  result = false;
      //}

      //if (primitiveToValidate.Capacity == null || !primitiveToValidate.Capacity.HasValue)
      //{
      //  validationResults.Add(new ValidationResult("Ładowność musi być ustawiona."));
      //  result = false;
      //}
      //else
      //{
      //  if (primitiveToValidate.Capacity == null || primitiveToValidate.Capacity.Value <= 0)
      //  {
      //    validationResults.Add(new ValidationResult("Ładowność musi być dodatnia."));
      //    result = false;
      //  }
      //}

      //if (primitiveToValidate.CarType == null || !primitiveToValidate.CarType.HasValue)
      //{
      //  validationResults.Add(new ValidationResult("Typ samochodu musi być ustawiony."));
      //  result = false;
      //}

      //if (primitiveToValidate.TransportType == null || !primitiveToValidate.TransportType.HasValue)
      //{
      //  validationResults.Add(new ValidationResult("Rodzaj transportu musi być ustawiony."));
      //  result = false;
      //}
      return result;
    }

    public static List<ValidationResult> ValidateClientSide(this DeliveryNotePrimitive primitiveToValidate, CultureInfo cultureInfo)
    {
      if (primitiveToValidate == null)
        return null;
      List<ValidationResult> res = new List<ValidationResult>();
      bool valid = Validator.TryValidateObject(primitiveToValidate, new ValidationContext(primitiveToValidate, null, null), res, true);
      valid = valid && primitiveToValidate.ValidateClientSide(res, cultureInfo);
      return res;
    }

    public static List<ValidationResult> ValidateClientSide(this DeliveryNotePrimitive primitiveToValidate)
    {
      return primitiveToValidate.ValidateClientSide(Thread.CurrentThread.CurrentUICulture);
    }
    #endregion //Car Client Side Validation


    
  }
}