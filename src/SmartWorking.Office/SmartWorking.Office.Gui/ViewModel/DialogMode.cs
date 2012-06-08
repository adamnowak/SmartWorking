namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Mode which dialog is created.
  /// </summary>
  public enum DialogMode
  {
    /// <summary>
    /// Manage items
    /// </summary>
    Manage,
    /// <summary>
    /// Create new item
    /// </summary>
    Create,
    /// <summary>
    /// Update existed item
    /// </summary>
    Update,
    /// <summary>
    /// Chose item
    /// </summary>
    Chose,
    /// <summary>
    /// Chose sub item
    /// </summary>
    /// <remarks>E.G. selecting Building on Contractor dialog.</remarks>
    ChoseSubItem
  }
}