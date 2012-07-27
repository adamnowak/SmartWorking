using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmartWorking.Office.TabsGui.Converters
{
  /// <summary>
  /// Converters enum to bool value.  
  /// </summary>
  public class NotSetToBoolConverter : IValueConverter
  {
    #region IValueConverter Members

    /// <summary>
    /// Converts <paramref name="value"/> to <paramref name="parameter"/> and returns result of equality.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>
    /// A converted value. If the method returns null, the valid null value is used.
    /// </returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {      
      if (value == null || value == DependencyProperty.UnsetValue)
      {
        if (parameter is bool)
        {
          return (bool) parameter;
        }
        return false;
      }
      return true;
    }

    /// <summary>
    /// Converts <paramref name="value"/> to <paramref name="parameter"/> and returns result of equality.
    /// </summary>
    /// <param name="value">The value that is produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>
    /// A converted value. If the method returns null, the valid null value is used.
    /// </returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}