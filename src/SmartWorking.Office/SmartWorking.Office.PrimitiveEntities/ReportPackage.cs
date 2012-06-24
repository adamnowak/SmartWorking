using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartWorking.Office.PrimitiveEntities
{
  public class ReportValue
  {
    public int Id { get; set; }
    public int NoOfTransport { get; set; }
    public Nullable<double> Amount { get; set; }
  }

  public class ReportRow
  {
    public int Id { get; set; }

    private List<ReportValue> _values;

    public List<ReportValue> Values
    {
      get
      {
        if (_values == null)
        {
          _values = new List<ReportValue>();
        }
        return _values;
      }
      set { _values = value; }
    }
  }

  class ReportPackage
  {
    private List<ReportRow> _report;
    public List<ReportRow> Report
    {
      get
      {
        if (_report == null)
        {
          _report = new List<ReportRow>(); 
        }
        return _report;
      }
      set { _report = value; }
    }
  }
}
