using System;
using System.Globalization;
using System.Windows.Data;
using SmartWorking.Office.Gui.ViewModel;

namespace SmartWorking.Office.Gui.View
{
  public class ViewModeToTextConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is DialogMode)
      {
        switch ((DialogMode) value)
        {
          case DialogMode.Create:
            return "Utwórz";
          case DialogMode.Update:
            return "Zapisz";
          case DialogMode.Chose:
            return "Wybierz";
          case DialogMode.ChoseSubItem:
            return "Wybierz";
        }
      }
      return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}