using System;
using System.Windows.Input;
using SmartWorking.Office.Gui.ViewModel;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  /// <summary>
  /// Interface for dialog view model.
  /// </summary>
  public interface IModalDialogViewModel
  {
    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    string Title { get; }

    ICommand CancelCommand { get; }

    ///// <summary>
    ///// Gets a value indicating whether main operation on dialog was canceled.
    ///// </summary>
    ///// <value>
    ///// 	<c>true</c> if  main operation on dialog was canceled; otherwise, <c>false</c>.
    ///// </value>
    //bool IsCanceled { get; }

    ///// <summary>
    ///// Gets a value indicating whether this <see cref="DialogViewModelBase"/> is closing.
    ///// </summary>
    ///// <value>
    /////   <c>true</c> if closing; otherwise, <c>false</c>.
    ///// </value>
    //bool Closing { get; }

    ///// <summary>
    ///// Raise when request about close dialog occurs.
    ///// </summary>
    //event EventHandler RequestClose;
  }
}