using System.Windows.Input;
using SmartWorking.Office.TabsGui.Controls.Cars;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  /// <summary>
  /// Interface for view model for listing control.
  /// </summary>
  public interface IListingEditableControlViewModel : IControlViewModel
  {
    /// <summary>
    /// Gets the editing view model which is used to editing or create new item.
    /// </summary>
    IEditableControlViewModel EditingViewModel { get; }

    /// <summary>
    /// Gets the add command which enables to add new item (using details control).
    /// </summary>
    ICommand AddCommand { get; }

    /// <summary>
    /// Gets the delete command which enables to delete existing item.
    /// </summary>
    ICommand DeleteCommand { get; }
  }
}