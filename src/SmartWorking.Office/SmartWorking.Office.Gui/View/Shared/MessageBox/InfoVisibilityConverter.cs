using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmartWorking.Office.Gui.View.Shared.MessageBox
{
  internal class InfoVisibilityConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      bool shouldBeShown = (value is string) ? !string.IsNullOrEmpty((string) value) : false;
      return (shouldBeShown) ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}