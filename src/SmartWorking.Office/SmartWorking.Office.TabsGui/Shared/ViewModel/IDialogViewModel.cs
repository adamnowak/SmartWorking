using System;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  /// <summary>
  /// Interface for dialog view model.
  /// </summary>
  public interface IDialogViewModel
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
    /// Gets a value indicating whether this <see cref="DialogViewModelBase"/> is closing.
    /// </summary>
    /// <value>
    ///   <c>true</c> if closing; otherwise, <c>false</c>.
    /// </value>
    bool Closing { get; }

    /// <summary>
    /// Raise when request about close dialog occurs.
    /// </summary>
    event EventHandler RequestClose;
  }
}