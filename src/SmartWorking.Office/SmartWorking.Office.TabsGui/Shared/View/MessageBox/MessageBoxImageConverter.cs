using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmartWorking.Office.TabsGui.Shared.View.MessageBox
{
  internal class MessageBoxImageConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      switch (value is MessageBoxImage ? (MessageBoxImage) value : MessageBoxImage.None)
      {
        case MessageBoxImage.Error:
          return Application.Current.FindResource("ErrorImageSource");
        case MessageBoxImage.Question:
          return Application.Current.FindResource("QuestionImageSource");
        case MessageBoxImage.Warning:
          return Application.Current.FindResource("WarningImageSource");
      }
      return Application.Current.FindResource("InformationImageSource");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }

  internal class ButtonVisibilityConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string sParameter = (parameter is string ? (string) parameter : string.Empty);
      switch (value is MessageBoxButton ? (MessageBoxButton) value : MessageBoxButton.OK)
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

    #endregion
  }
}