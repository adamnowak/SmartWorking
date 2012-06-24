using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Reports;

namespace SmartWorking.Office.Gui.View.Shared.Converters.Reports
{
  public abstract class ReportPackageToColumnsConverter<TRowElement, TColumnElement> 
    : IValueConverter
    where TRowElement : IPrimitive
    where TColumnElement : IPrimitive
  {
    protected abstract string GetHeaderXDescription();

    protected abstract string GetColumnName(TColumnElement columnElement);

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var columns = new ObservableCollection<DataGridColumn>();
      ReportPackage<TRowElement, TColumnElement> reportPackage = value as ReportPackage<TRowElement, TColumnElement>;      
      if (reportPackage != null)
      {
        Binding bindingHeaderX = new Binding { Path = new PropertyPath("HeaderX") };
        DataGridTextColumn columnHeaderX = new DataGridTextColumn { Header = GetHeaderXDescription(), Binding = bindingHeaderX };
        columns.Add(columnHeaderX);
        foreach (var columnElement in reportPackage.ColumntElements)
        {
          Binding binding = new Binding { Path = new PropertyPath("Column_" + columnElement.Id) };
          DataGridTextColumn column = new DataGridTextColumn { Header = GetColumnName(columnElement), Binding = binding };
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
