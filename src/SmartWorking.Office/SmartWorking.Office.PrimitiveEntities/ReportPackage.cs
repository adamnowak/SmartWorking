using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.PrimitiveEntities
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

  /// <summary>
  /// Represents report information.
  /// </summary>
  class ReportPackage
  {
    private List<CarPrimitive> _columntElements;
    /// <summary>
    /// Gets or sets the columnt elements.
    /// </summary>
    /// <value>
    /// The columnt elements.
    /// </value>
    public List<CarPrimitive> ColumntElements
    {
      get
      {
        if (_columntElements == null)
        {
          _columntElements = new List<CarPrimitive>();
        }
        return _columntElements;
      }
      set { _columntElements = value; }
    }

    private List<DriverPrimitive> _rowElements;
    /// <summary>
    /// Gets or sets the row elements.
    /// </summary>
    /// <value>
    /// The row elements.
    /// </value>
    public List<DriverPrimitive> RowElements
    {
      get
      {
        if (_rowElements == null)
        {
          _rowElements = new List<DriverPrimitive>();
        }
        return _rowElements;
      }
      set { _rowElements = value; }
    }

    private List<ReportRow> _values;
    /// <summary>
    /// Gets or sets the report's value.
    /// </summary>
    /// <value>
    /// The report's value.
    /// </value>
    public List<ReportRow> Values
    {
      get
      {
        if (_values == null)
        {
          _values = new List<ReportRow>(); 
        }
        return _values;
      }
      set { _values = value; }
    }
  }
}
