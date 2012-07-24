using System.Windows.Input;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  public interface IListingEditableControlViewModel : IControlViewModel
  {
    /// <summary>
    /// Gets the add command which enables to add new item (using details control).
    /// </summary>
    ICommand AddItemCommand { get; }

    /// <summary>
    /// Gets the add clone command which enables to add item the same item as selected one (using details control).
    /// </summary>
    ICommand AddCloneItemCommand { get; }

    /// <summary>
    /// Gets the delete command which enables to delete existing item.
    /// </summary>
    ICommand DeleteItemCommand { get; }

    /// <summary>
    /// Gets the filter used to filterfing items.
    /// </summary>
    string Filter { get; }

    /// <summary>
    /// Gets the list items filter.
    /// </summary>
    ListItemsFilterValues ListItemsFilter { get; }
  }

  /// <summary>
  /// Interface for view model for listing control.
  /// </summary>
  public interface IListingEditableControlViewModel<T> : IListingEditableControlViewModel
  {
    /// <summary>
    /// Gets the editing view model which is used to editing or create new item.
    /// </summary>
    IEditableControlViewModel<T> EditingViewModel { get; }

    /// <summary>
    /// Gets the items which will be listed.
    /// </summary>s
    SelectableViewModelBase<T> Items { get; }
  }
  
  
}