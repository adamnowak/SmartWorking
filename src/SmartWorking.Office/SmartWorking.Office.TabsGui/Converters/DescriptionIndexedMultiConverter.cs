﻿using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Converters
{
  public class DescriptionIndexedMultiConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {      
      if (values.Count() != 2 || !(values[0] is int))
        return null;
      int id = (int) values[0];
      if (id >= 0 && values[1] is IEnumerable)
      {
        foreach (object value in values[1] as IEnumerable)
        {
          IDescriptionIndexted descriptionIndexted = value as IDescriptionIndexted;
          if (descriptionIndexted != null && descriptionIndexted.Id == id)
          {
            return descriptionIndexted.Description;
          }
        }  
      }
      return null;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
