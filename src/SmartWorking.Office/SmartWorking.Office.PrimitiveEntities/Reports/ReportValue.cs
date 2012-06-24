using System;

namespace SmartWorking.Office.PrimitiveEntities.Reports
{
  /// <summary>
  /// Represents one value in report.
  /// </summary>
  public class ReportValue
  {
    /// <summary>
    /// Gets or sets the column element id.
    /// </summary>
    /// <value>
    /// The columnn element id.
    /// </value>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the no of transports.
    /// </summary>
    /// <value>
    /// The no of transports.
    /// </value>
    public int NoOfTransports { get; set; }
    /// <summary>
    /// Gets or sets the column element amount.
    /// </summary>
    /// <value>
    /// The column element amount.
    /// </value>
    public Nullable<double> Amount { get; set; }
  }
}