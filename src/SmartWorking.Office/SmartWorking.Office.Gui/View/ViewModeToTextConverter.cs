using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using SmartWorking.Office.Gui.ViewModel;

namespace SmartWorking.Office.Gui.View
{
  public class ViewModeToTextConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is ViewMode)
      {
        switch ((ViewMode)value)
        {
          case ViewMode.Create:
            return "Utwórz";
          case ViewMode.Update:
            return "Zapisz";
          case ViewMode.Selecte:
            return "Wybierz";
        }
      }
      return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
