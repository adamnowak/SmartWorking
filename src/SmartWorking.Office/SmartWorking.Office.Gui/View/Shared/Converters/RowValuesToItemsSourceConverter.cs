using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Reports;


namespace SmartWorking.Office.Gui.View.Shared.Converters
{
  public class DriverCarRowValueDynamicWrapper : DynamicObject
  {
    public DriverPrimitive Driver { get; set; }
    public ReportRow ReportRow { get; set; }

    public DriverCarRowValueDynamicWrapper(DriverPrimitive driver, ReportRow reportRow)
    {
      Driver = driver;
      ReportRow = reportRow;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
      result = null;
      if (binder.Name.StartsWith("HeaderX"))
      {
        result = (Driver != null) ? (Driver.Name) : "Nieznany:)";
      }
      if (binder.Name.StartsWith("Sume"))
      {
        result = ReportRow.ReportValues.Sum(x => x.NoOfTransports).ToString() + " tran. / " + ReportRow.ReportValues.Sum(x => x.Amount).ToString() + " m3";
      }
      if (binder.Name.StartsWith("Column_"))
      {
        int columnNo = -1;
        int.TryParse(binder.Name.Substring(7), out columnNo);
        if (columnNo > 0)
        {
          ReportValue reportValue = ReportRow.ReportValues.Where(x => x.Id == columnNo).FirstOrDefault();
          result = (reportValue != null)
                     ? reportValue.NoOfTransports.ToString() + " tran. / " + reportValue.Amount + " m3"
                     : string.Empty;
        }
      }
      return true;
    }

    
  }

  public class RowValuesToItemsSourceConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var rows = new ObservableCollection<DriverCarRowValueDynamicWrapper>();
      ReportPackage<DriverPrimitive, CarPrimitive> reportPackage = value as ReportPackage<DriverPrimitive, CarPrimitive>;
      if (reportPackage != null)
      {
        foreach (ReportRow reportRow in reportPackage.RowValues)
        {
          DriverPrimitive driverPrimitive = reportPackage.RowElements.Where(x => x.Id == reportRow.Id).FirstOrDefault();
          rows.Add(new DriverCarRowValueDynamicWrapper(driverPrimitive, reportRow));
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
