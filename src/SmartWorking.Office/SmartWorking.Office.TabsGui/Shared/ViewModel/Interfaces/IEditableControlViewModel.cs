using System;
using System.Windows.Input;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  public interface IEditableControlViewModel : IControlViewModel
  {
    /// <summary>
    /// Gets the edit command - command which enable item to editing.
    /// </summary>
    ICommand EditItemCommand { get; }

    /// <summary>
    /// Occurs when item was saved.
    /// </summary>
    event EventHandler ItemEdited;

    /// <summary>
    /// Gets the save command - command which save editing item.
    /// </summary>
    ICommand SaveItemCommand { get; }

    /// <summary>
    /// Occurs when item was saved.
    /// </summary>
    event EventHandler ItemSaved;

    /// <summary>
    /// Gets the cancel command - command which cancel editing.
    /// </summary>
    ICommand CancelChangesCommand { get; }

    /// <summary>
    /// Occurs when cancel changes.
    /// </summary>
    event EventHandler ChangesCanceled;

  }

  /// <summary>
  /// Interface for view model for editing control.
  /// </summary>
  public interface IEditableControlViewModel<T> : IEditableControlViewModel
  {

    /// <summary>
    /// Gets or sets the item.
    /// </summary>
    /// <value>
    /// The item which will be editing or displaying.
    /// </value>
    T Item { get; set; }

  }

   
}