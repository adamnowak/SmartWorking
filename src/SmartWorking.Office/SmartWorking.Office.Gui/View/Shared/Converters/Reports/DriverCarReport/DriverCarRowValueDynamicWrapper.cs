using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Gui.View.Shared.Converters.Reports.DriverCarReport
{
  public class DriverCarRowValueDynamicWrapper : RowValueDynamicWrapperBase<DriverPrimitive>
  {
    protected override string GetDescription(DriverPrimitive primitiveForRowHeader)
    {
      return PrimitiveForRowHeader.Name;
    }
  }
}