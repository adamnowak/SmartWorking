namespace SmartWorking.Office.Services.Interfaces
{
  public enum ListItemsFilterValues
  {
    /// <summary>
    /// The list contains only active items.
    /// </summary>
    OnlyActive,
    /// <summary>
    /// The list contains active and deactive items (not deleted).
    /// </summary>
    IncludeDeactive,
    /// <summary>
    /// The list contains all items (also deleted).
    /// </summary>
    All
  }
}
