using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  /// <summary>
  /// Base view model for control which listing items for editing.
  /// </summary>
  public abstract  class  ListingEditableControlViewModel<T> : ControlViewModelBase, IListingEditableControlViewModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ListingEditableControlViewModel{T}"/> class.
    /// </summary>
    /// <param name="editingViewModel">The editing view model.</param>
    public ListingEditableControlViewModel(IEditableControlViewModel editingViewModel,
      IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      Items = new SelectableViewModelBase<T>();
      EditingViewModel = editingViewModel;
    }

    /// <summary>
    /// Gets the items which will be listed.
    /// </summary>
    public SelectableViewModelBase<T> Items { get; private set; }

    /// <summary>
    /// Gets the editing view model which is used to editing or create new item.
    /// </summary>
    public IEditableControlViewModel EditingViewModel { get; private set; }

    #region AddCommand
    private ICommand _addCommand;
    /// <summary>
    /// Gets the add command which enables to add new item (using details control).
    /// </summary>
    public ICommand AddCommand
    {
      get
      {
        if (_addCommand == null)
          _addCommand = new RelayCommand(AddCommandExecute, CanAddCommandExecute);
        return _addCommand;
      }
    }

    /// <summary>
    /// Determines whether add command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if add command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanAddCommandExecute()
    {
      return true;
    }

    /// <summary>
    /// Execute add command.
    /// </summary>
    protected virtual void AddCommandExecute()
    {}
    #endregion

    #region DeleteCommand
    private ICommand _deleteCommand;
    /// <summary>
    /// Gets the delete command which enables to delete existing item.
    /// </summary>
    public ICommand DeleteCommand
    {
      get
      {
        if (_deleteCommand == null)
          _deleteCommand = new RelayCommand(DeleteCommandExecute, CanDeleteCommandExecute);
        return _deleteCommand;
      }
    }
    /// <summary>
    /// Determines whether delete command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if delete command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanDeleteCommandExecute()
    {
      return false;
    }

    /// <summary>
    /// Execute delete command.
    /// </summary>
    protected virtual void DeleteCommandExecute()
    { }
    #endregion

    
  }
}