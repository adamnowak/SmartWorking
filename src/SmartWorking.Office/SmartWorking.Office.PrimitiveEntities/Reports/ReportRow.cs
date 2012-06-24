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

    private List<ReportValue> _reportValues;

    /// <summary>
    /// Gets or sets the values in row.
    /// </summary>
    /// <value>
    /// The values in row.
    /// </value>
    public List<ReportValue> ReportValues
    {
      get
      {
        if (_reportValues == null)
        {
          _reportValues = new List<ReportValue>();
        }
        return _reportValues;
      }
      set { _reportValues = value; }
    }
  }
}