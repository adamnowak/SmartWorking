using System;
using System.Collections.Generic;
using System.Windows.Data;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.TabsGui.Converters
{
  public class DeliveryNotePackageListToAmountDeliveryConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
      double result = 0;
      //if (targetType != typeof(bool))
      //  throw new InvalidOperationException("The target must be a boolean");
      if (value != null && value is ICollection<DeliveryNotePackage>)
      {
        ICollection<DeliveryNotePackage> deliveryNotePackageList = value as ICollection<DeliveryNotePackage>;
        foreach (DeliveryNotePackage deliveryNotePackage in deliveryNotePackageList)
        {
          if (deliveryNotePackage != null && deliveryNotePackage.DeliveryNote != null && deliveryNotePackage.DeliveryNote.Amount.HasValue)
          {
            result += deliveryNotePackage.DeliveryNote.Amount.Value;
          }  
        }
      }
      return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
      throw new NotSupportedException();
    }

    #endregion
  }
}
