using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SmartWorking.Office.Gui.View.Shared.MessageBox
{
  class MessageBoxImageConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      switch (value is MessageBoxImage ? (MessageBoxImage) value : MessageBoxImage.None)
      {
        case MessageBoxImage.Error:
          return (BitmapImage)Application.Current.FindResource("ErrorImageSource");
        case MessageBoxImage.Question:
          return (BitmapImage)Application.Current.FindResource("QuestionImageSource");
        case MessageBoxImage.Warning:
          return (BitmapImage)Application.Current.FindResource("WarningImageSource");
      }
      return (BitmapImage)Application.Current.FindResource("InformationImageSource");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }

  class ButtonVisibilityConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string sParameter = (parameter is string ? (string) parameter : string.Empty);
      switch (value is MessageBoxButton ? (MessageBoxButton)value : MessageBoxButton.OK)
      {
        case MessageBoxButton.OK:
          {
            if (sParameter == "Ok")
              return Visibility.Visible;
          }
          break;
        case MessageBoxButton.OKCancel:
          {
            if (sParameter == "Ok" || sParameter == "Cancel")
              return Visibility.Visible;
          }
          break;
        case MessageBoxButton.YesNo:
          {
            if (sParameter == "Yes" || sParameter == "No")
              return Visibility.Visible;
          }
          break;
        case MessageBoxButton.YesNoCancel:
          {
            if (sParameter == "Yes" || sParameter == "No" || sParameter == "Cancel")
              return Visibility.Visible;
          }
          break;
      }
      return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
