using System.Collections.Generic;

namespace SmartWorking.Office.PrimitiveEntities.Reports
{
  /// <summary>
  /// Represents one report row.
  /// </summary>
  public class ReportRow
  {
    /// <summary>
    /// Gets or sets the row element id.
    /// </summary>
    /// <value>
    /// The row element id.
    /// </value>
    public int Id { get; set; }

    private List<ReportValue> _values;

    /// <summary>
    /// Gets or sets the values in row.
    /// </summary>
    /// <value>
    /// The values in row.
    /// </value>
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
}