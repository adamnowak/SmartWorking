using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Reports;

namespace SmartWorking.Office.Gui.View.Shared.Converters.Reports
{
  public abstract class RowValuesToItemsSourceConverterBase<TRowValueDynamicWrapper, TRowElement, TColumnElement>
    : IValueConverter
    where TRowValueDynamicWrapper : RowValueDynamicWrapperBase<TRowElement>, new()
    where TRowElement : IPrimitive
    where TColumnElement : IPrimitive
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var rows = new ObservableCollection<TRowValueDynamicWrapper>();
      ReportPackage<TRowElement, TColumnElement> reportPackage = value as ReportPackage<TRowElement, TColumnElement>;
      if (reportPackage != null)
      {
        foreach (ReportRow reportRow in reportPackage.RowValues)
        {
          TRowElement primitiveForRowHeader = reportPackage.RowElements.Where(x => x.Id == reportRow.Id).FirstOrDefault();
          TRowValueDynamicWrapper wrapper = new TRowValueDynamicWrapper();
          wrapper.PrimitiveForRowHeader = primitiveForRowHeader;
          wrapper.ReportRow = reportRow;
          rows.Add(wrapper);
        }
      }
      return rows;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}