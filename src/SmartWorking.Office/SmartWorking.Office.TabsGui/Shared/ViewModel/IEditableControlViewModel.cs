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