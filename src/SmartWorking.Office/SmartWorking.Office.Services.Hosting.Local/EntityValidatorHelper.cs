using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading;
using SmartWorking.Office.Entities;
using System.Linq;

namespace SmartWorking.Office.Services.Hosting.Local
{
  public static class EntityValidatorHelper
  {
    

    #region Car Client Side Validation
  
    public static bool ValidateForNewEntity(this Car toValidate, List<ValidationResult> validationResults, SmartWorkingEntities context)
    {
      bool result = true;
      var conflicted =
        context.Cars.Where(
          x =>
          x.InternalName.Trim().ToUpper() == toValidate.InternalName.Trim().ToUpper() ||
          x.RegistrationNumber.Replace(" ", string.Empty).ToUpper() == toValidate.RegistrationNumber.Replace(" ", string.Empty).ToUpper()).
          FirstOrDefault();
      if (conflicted != null)
      {
        result = false;
        if (validationResults == null)
          validationResults = new List<ValidationResult>();
        if (conflicted.InternalName.Trim().ToUpper() == toValidate.InternalName.Trim().ToUpper())
        {
          validationResults.Add(new ValidationResult("Samochód o podanym symbolu już istnieje."));
        }
        if (conflicted.RegistrationNumber.Replace(" ", string.Empty).ToUpper() == toValidate.RegistrationNumber.Replace(" ", string.Empty).ToUpper())
        {
          validationResults.Add(new ValidationResult("Samochód o podanym numerze rejestracyjnym już istnieje."));
        }
      }
      return result;
    }

    public static bool ValidateForExistingEntity(this Car toValidate, List<ValidationResult> validationResults, SmartWorkingEntities context)
    {
      bool result = true;
      var conflicted =
        context.Cars.Where(
          x =>
          x.Id != toValidate.Id &&
          (x.InternalName.Trim().ToUpper() == toValidate.InternalName.Trim().ToUpper() ||
          x.RegistrationNumber.Replace(" ", string.Empty).ToUpper() == toValidate.RegistrationNumber.Replace(" ", string.Empty).ToUpper())).
          FirstOrDefault();
      if (conflicted != null)
      {
        result = false;
        if (validationResults == null)
          validationResults = new List<ValidationResult>();
        if (conflicted.InternalName.Trim().ToUpper() == toValidate.InternalName.Trim().ToUpper())
        {
          validationResults.Add(new ValidationResult("Samochód o podanym symbolu już istnieje."));
        }
        if (conflicted.RegistrationNumber.Replace(" ", string.Empty).ToUpper() == toValidate.RegistrationNumber.Replace(" ", string.Empty).ToUpper())
        {
          validationResults.Add(new ValidationResult("Samochód o podanym numerze rejestracyjnym już istnieje."));
        }
      }
      return result;
    }

    
    #endregion //Car Client Side Validation

    



    
  }
}