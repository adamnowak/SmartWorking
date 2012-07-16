using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  /// <summary>
  /// Base view model for editing control.
  /// </summary>
  public abstract class EditableControlViewModelBase<T> : ControlViewModelBase, IEditableControlViewModel<T>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="EditableControlViewModelBase&lt;T&gt;"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public EditableControlViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      
    }

    #region Item
    /// <summary>
    /// The <see cref="Item" /> property's name.
    /// </summary>
    public const string ItemPropertyName = "Item";

    private T _item;

    /// <summary>
    /// Gets or sets the item.
    /// </summary>
    /// <value>
    /// The item which will be editing or displaying.
    /// </value>
    public T Item
    {
      get
      {
        return _item;
      }

      set
      {
        if (_item != null && _item.Equals(value))
        {
          return;
        }
        _item = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(ItemPropertyName);
      }
    }
    #endregion //Item
    
    #region EditItemCommand
    private ICommand _editItemCommand;
    /// <summary>
    /// Gets the edit command - command which enable item to editing.
    /// </summary>
    public ICommand EditItemCommand
    {
      get
      {
        if (_editItemCommand == null)
          _editItemCommand = new RelayCommand(EditItemCommandExecute, CanEditItemCommandExecute);
        return _editItemCommand;
      }
    }

    /// <summary>
    /// Determines whether edit command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if edit command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanEditItemCommandExecute()
    {
      return Item != null;
    }

    /// <summary>
    /// Execute edit command.
    /// </summary>
    protected virtual void EditItemCommandExecute()
    { }
    #endregion

    #region SaveItemCommand
    private ICommand _saveItemCommand;
    /// <summary>
    /// Gets the save command - command which save editing item.
    /// </summary>
    public ICommand SaveItemCommand
    {
      get
      {
        if (_saveItemCommand == null)
          _saveItemCommand = new RelayCommand(SaveItemCommandExecute, CanSaveItemCommandExecute);
        return _saveItemCommand;
      }
    }

    /// <summary>
    /// Determines whether save command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if save command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanSaveItemCommandExecute()
    {
      return true;
    }

    /// <summary>
    /// Execute save command.
    /// </summary>
    protected virtual void SaveItemCommandExecute()
    { }
    #endregion

    #region CancelChangesCommand
    private ICommand _cancelChangesCommand;
    /// <summary>
    /// Gets the cancel command - command which cancel changes during editing.
    /// </summary>
    public ICommand CancelChangesCommand
    {
      get
      {
        if (_cancelChangesCommand == null)
          _cancelChangesCommand = new RelayCommand(CancelChangesCommandExecute, CanCancelChangesCommandExecute);
        return _cancelChangesCommand;
      }
    }

    /// <summary>
    /// Determines whether cancel command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if cancel command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanCancelChangesCommandExecute()
    {
      return true;
    }

    /// <summary>
    /// Execute cancel command.
    /// </summary>
    protected virtual void CancelChangesCommandExecute()
    { }
    #endregion


  }
}