using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Reports;

namespace SmartWorking.Office.Gui.View.Shared.Converters
{
  public class ReportPackageToColumnsConverter :IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var columns = new ObservableCollection<DataGridColumn>();
      ReportPackage<DriverPrimitive, CarPrimitive> reportPackage = value as ReportPackage<DriverPrimitive, CarPrimitive>;      
      if (reportPackage != null)
      {
        Binding bindingHeaderX = new Binding { Path = new PropertyPath("HeaderX") };
        DataGridTextColumn columnHeaderX = new DataGridTextColumn { Header = "Kierowcy\\Samochody", Binding = bindingHeaderX };
        columns.Add(columnHeaderX);
        foreach (var columnElement in reportPackage.ColumntElements)
        {
          Binding binding = new Binding { Path = new PropertyPath("Column_" + columnElement.Id) };
          DataGridTextColumn column = new DataGridTextColumn { Header = columnElement.Name, Binding = binding };
          columns.Add(column);          
        }
        Binding bindingSume = new Binding { Path = new PropertyPath("Sume") };
        DataGridTextColumn columnSume = new DataGridTextColumn { Header = "Suma", Binding = bindingSume };
        columns.Add(columnSume);
      }
      return columns;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
