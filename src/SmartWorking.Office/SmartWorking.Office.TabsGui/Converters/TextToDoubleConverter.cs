using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmartWorking.Office.TabsGui.Converters
{
  public class TextToDoubleConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
      //if (targetType != typeof(bool))
      //  throw new InvalidOperationException("The target must be a boolean");
      if (value != null)
      {
        return value.ToString();
      }
      return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
      if (value != null && !string.IsNullOrEmpty(value.ToString()))
      {
        string toConvert = value.ToString().Replace(',', '.');
        double dValue = 0;
        if (double.TryParse(toConvert, NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out dValue))
        {
          return dValue;
        }
        else
        {
        
          //return Binding.DoNothing;
          return DependencyProperty.UnsetValue;
        }
      }
      return null;
    }

    #endregion
  }
}
