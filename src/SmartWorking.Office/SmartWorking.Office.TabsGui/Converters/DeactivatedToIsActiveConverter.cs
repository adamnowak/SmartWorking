using System;
using System.Windows.Data;

namespace SmartWorking.Office.TabsGui.Converters
{
  public class DeactivatedToIsActiveConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType,
        object parameter, System.Globalization.CultureInfo culture)
    {
      DateTime? dateTime = value as DateTime?;
      if (dateTime != null)
      {
        if (dateTime.HasValue)
        {
          return false;
        }
      }
      return true;

      //if (value != null && value is int)
      //{
      //  var val = (int)value;
      //  return (val == 0) ? false : true;
      //}
      //return true;

    }

    public object ConvertBack(object value, Type targetType,
        object parameter, System.Globalization.CultureInfo culture)
    {
      if (value != null && value is bool)
      {
        var val = (bool)value;
        if (val) 
        {
          return null;
        }
        else
        {
          return DateTime.Now; 
        }
      }
      return null;
    }

    #endregion  
  }
}
