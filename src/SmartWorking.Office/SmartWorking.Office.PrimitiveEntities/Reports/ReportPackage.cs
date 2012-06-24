using System.Collections.Generic;

namespace SmartWorking.Office.PrimitiveEntities.Reports
{
  /// <summary>
  /// Represents report information.
  /// </summary>
  public class ReportPackage<TColumnElements, TRowElements> 
    where TColumnElements : IPrimitive
    where TRowElements : IPrimitive 
  {
    private List<TColumnElements> _columntElements;
    /// <summary>
    /// Gets or sets the columnt elements.
    /// </summary>
    /// <value>
    /// The columnt elements.
    /// </value>
    public List<TColumnElements> ColumntElements
    {
      get
      {
        if (_columntElements == null)
        {
          _columntElements = new List<TColumnElements>();
        }
        return _columntElements;
      }
      set { _columntElements = value; }
    }

    private List<TRowElements> _rowElements;
    /// <summary>
    /// Gets or sets the row elements.
    /// </summary>
    /// <value>
    /// The row elements.
    /// </value>
    public List<TRowElements> RowElements
    {
      get
      {
        if (_rowElements == null)
        {
          _rowElements = new List<TRowElements>();
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
