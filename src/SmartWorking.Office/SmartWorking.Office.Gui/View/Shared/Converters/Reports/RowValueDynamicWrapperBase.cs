using System.Dynamic;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Reports;

namespace SmartWorking.Office.Gui.View.Shared.Converters.Reports
{
  public abstract class RowValueDynamicWrapperBase<TPrimitive> : DynamicObject 
    where TPrimitive : IPrimitive
  {
    public TPrimitive PrimitiveForRowHeader { get; set; }
    public ReportRow ReportRow { get; set; }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
      result = null;
      if (binder.Name.StartsWith("HeaderX"))
      {
        result = (PrimitiveForRowHeader != null) ? GetDescription(PrimitiveForRowHeader) : "Nieznany:)";
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

    protected abstract string GetDescription(TPrimitive primitiveForRowHeader);
  }
}