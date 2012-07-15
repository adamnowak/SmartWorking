using System.Windows.Input;
using SmartWorking.Office.TabsGui.Controls.Cars;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  /// <summary>
  /// Interface for view model for editing control.
  /// </summary>
  public interface IEditableControlViewModel : IControlViewModel
  {
    
    /// <summary>
    /// Gets the editing mode of the control.
    /// </summary>
    EditingMode EditingMode { get; }
    /// <summary>
    /// Gets a value indicating whether this instance is editing.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is editing; otherwise, <c>false</c>.
    /// </value>
    bool IsEditing { get; }
    /// <summary>
    /// Gets the edit command - command which enable item to editing.
    /// </summary>
    ICommand EditCommand { get; }
    /// <summary>
    /// Gets the save command - command which save editing item.
    /// </summary>
    ICommand SaveCommand { get; }
    /// <summary>
    /// Gets the cancel command - command which cancel editing.
    /// </summary>
    ICommand CancelCommand { get; }
  }
}