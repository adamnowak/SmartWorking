using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  /// <summary>
  /// Base view model for control which listing items for editing.
  /// </summary>
  public abstract  class  ListingEditableControlViewModel<T> : ControlViewModelBase, IListingEditableControlViewModel<T>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ListingEditableControlViewModel{T}"/> class.
    /// </summary>
    /// <param name="editingViewModel">The editing view model.</param>
    public ListingEditableControlViewModel(IEditableControlViewModel<T> editingViewModel,
      IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      Items = new SelectableViewModelBase<T>();
      EditingViewModel = editingViewModel;
      Items.SelectedItemChanged +=
        (o, e) =>
        Dispatcher.CurrentDispatcher.BeginInvoke(new System.EventHandler<SelectedItemChangedEventArgs<T>>(Items_SelectedItemChanged), o, e);
    }

    void Items_SelectedItemChanged(object sender, SelectedItemChangedEventArgs<T> e)
    {
      //IListingEditableControlViewModel<T> listingEditableControlViewModel =
      //  sender as IListingEditableControlViewModel<T>;

      if (EditingViewModel != null && e != null)
      {
        EditingViewModel.Item = e.NewValue;
      }
    }

    /// <summary>
    /// Gets the items which will be listed.
    /// </summary>
    public SelectableViewModelBase<T> Items { get; private set; }

    /// <summary>
    /// Gets the editing view model which is used to editing or create new item.
    /// </summary>
    public IEditableControlViewModel<T> EditingViewModel { get; private set; }

    #region AddItemCommand
    private ICommand _addItemCommand;
    /// <summary>
    /// Gets the add command which enables to add new item (using details control).
    /// </summary>
    public ICommand AddItemCommand
    {
      get
      {
        if (_addItemCommand == null)
          _addItemCommand = new RelayCommand(AddItemCommandExecute, CanAddItemCommandExecute);
        return _addItemCommand;
      }
    }

    /// <summary>
    /// Determines whether add command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if add command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanAddItemCommandExecute()
    {
      return true;
    }

    /// <summary>
    /// Execute add command.
    /// </summary>
    protected virtual void AddItemCommandExecute()
    {}
    #endregion

    #region AddCloneItemCommand
    private ICommand _addCloneItemCommand;
    /// <summary>
    /// Gets the addClone command which enables to addClone new item (using details control).
    /// </summary>
    public ICommand AddCloneItemCommand
    {
      get
      {
        if (_addCloneItemCommand == null)
          _addCloneItemCommand = new RelayCommand(AddCloneItemCommandExecute, CanAddCloneItemCommandExecute);
        return _addCloneItemCommand;
      }
    }

    /// <summary>
    /// Determines whether addClone command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if addClone command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanAddCloneItemCommandExecute()
    {
      return true;
    }

    /// <summary>
    /// Execute addClone command.
    /// </summary>
    protected virtual void AddCloneItemCommandExecute()
    { }
    #endregion

    #region DeleteItemCommand
    private ICommand _deleteItemCommand;
    /// <summary>
    /// Gets the delete command which enables to delete existing item.
    /// </summary>
    public ICommand DeleteItemCommand
    {
      get
      {
        if (_deleteItemCommand == null)
          _deleteItemCommand = new RelayCommand(DeleteItemCommandExecute, CanDeleteItemCommandExecute);
        return _deleteItemCommand;
      }
    }
    /// <summary>
    /// Determines whether delete command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if delete command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanDeleteItemCommandExecute()
    {
      return false;
    }

    /// <summary>
    /// Execute delete command.
    /// </summary>
    protected virtual void DeleteItemCommandExecute()
    { }
    #endregion  
  }
}