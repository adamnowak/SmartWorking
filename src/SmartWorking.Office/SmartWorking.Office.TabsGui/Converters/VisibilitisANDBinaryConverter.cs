using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Converters
{
  /// <summary>
  /// Converters enum to bool value.  
  /// </summary>
  public class VisibilitisANDBinaryConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      foreach (object value in values)
      {
        if (value == null || value == DependencyProperty.UnsetValue || (value is Visibility && (Visibility)value != Visibility.Visible) || (value is bool && !(bool)value))
        {
          return Visibility.Collapsed;
        }
      }
      return Visibility.Visible;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}