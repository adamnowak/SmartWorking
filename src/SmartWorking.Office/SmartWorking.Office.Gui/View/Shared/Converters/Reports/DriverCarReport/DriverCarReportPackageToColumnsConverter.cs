using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Gui.View.Shared.Converters.Reports.DriverCarReport
{
  public class DriverCarReportPackageToColumnsConverter 
    : ReportPackageToColumnsConverter<DriverPrimitive, CarPrimitive>
  {
    protected override string GetHeaderXDescription()
    {
      return "Kierowcy / Samochody";
    }

    protected override string GetColumnName(CarPrimitive columnElement)
    {
      return columnElement.Name;
    }
  }
}