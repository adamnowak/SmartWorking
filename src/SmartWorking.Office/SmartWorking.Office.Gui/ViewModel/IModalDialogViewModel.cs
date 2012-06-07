using System;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Interface for modal dialog view model.
  /// </summary>
  public interface IModalDialogViewModel
  {
    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    string Title { get; }
    /// <summary>
    /// Gets a value indicating whether main operation on dialog was canceled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if  main operation on dialog was canceled; otherwise, <c>false</c>.
    /// </value>
    bool IsCanceled { get; }
    /// <summary>
    /// Raise when request about close dialog occurs.
    /// </summary>
    event EventHandler RequestClose;
  }
}