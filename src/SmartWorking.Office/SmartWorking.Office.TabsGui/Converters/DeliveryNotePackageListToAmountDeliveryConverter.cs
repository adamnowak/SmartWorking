using System;
using System.Windows.Data;

namespace SmartWorking.Office.TabsGui.Converters
{
  public class DeliveryNotePackageListToAmountDeliveryConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
      //if (targetType != typeof(bool))
      //  throw new InvalidOperationException("The target must be a boolean");

      return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
      throw new NotSupportedException();
    }

    #endregion
  }
}
