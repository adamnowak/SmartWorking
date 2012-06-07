namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Mode which dialog is created.
  /// </summary>
  public enum DialogMode
  {
    /// <summary>
    /// Managing items
    /// </summary>
    Managing,
    /// <summary>
    /// Create new item
    /// </summary>
    Create,
    /// <summary>
    /// Update existed item
    /// </summary>
    Update,
    /// <summary>
    /// Selecting item
    /// </summary>
    Selecting,
    /// <summary>
    /// Selecting sub item
    /// </summary>
    /// <remarks>E.G. selecting Building on Contractor dialog.</remarks>
    SelectingSubItem
  }
}