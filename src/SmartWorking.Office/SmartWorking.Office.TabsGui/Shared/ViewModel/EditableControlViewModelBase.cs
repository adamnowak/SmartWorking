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
  public abstract class EditableControlViewModelBase<T> : ControlViewModelBase, IEditableControlViewModel
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

    /// <summary>
    /// Gets or sets the item.
    /// </summary>
    /// <value>
    /// The item which will be editing or displaying.
    /// </value>
    public T Item { get; set; }

    

    

    #region EditCommand
    private ICommand _editCommand;
    /// <summary>
    /// Gets the edit command - command which enable item to editing.
    /// </summary>
    public ICommand EditCommand
    {
      get
      {
        if (_editCommand == null)
          _editCommand = new RelayCommand(EditCommandExecute, CanEditCommandExecute);
        return _editCommand;
      }
    }

    /// <summary>
    /// Determines whether edit command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if edit command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanEditCommandExecute()
    {
      return true;
    }

    /// <summary>
    /// Execute edit command.
    /// </summary>
    protected virtual void EditCommandExecute()
    { }
    #endregion

    #region SaveCommand
    private ICommand _saveCommand;
    /// <summary>
    /// Gets the save command - command which save editing item.
    /// </summary>
    public ICommand SaveCommand
    {
      get
      {
        if (_saveCommand == null)
          _saveCommand = new RelayCommand(SaveCommandExecute, CanSaveCommandExecute);
        return _saveCommand;
      }
    }

    /// <summary>
    /// Determines whether save command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if save command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanSaveCommandExecute()
    {
      return true;
    }

    /// <summary>
    /// Execute save command.
    /// </summary>
    protected virtual void SaveCommandExecute()
    { }
    #endregion

    #region CancelCommand
    private ICommand _cancelCommand;
    /// <summary>
    /// Gets the cancel command - command which cancel editing.
    /// </summary>
    public ICommand CancelCommand
    {
      get
      {
        if (_cancelCommand == null)
          _cancelCommand = new RelayCommand(CancelCommandExecute, CanCancelCommandExecute);
        return _cancelCommand;
      }
    }

    /// <summary>
    /// Determines whether cancel command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if cancel command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanCancelCommandExecute()
    {
      return true;
    }

    /// <summary>
    /// Execute cancel command.
    /// </summary>
    protected virtual void CancelCommandExecute()
    { }
    #endregion

    
  }
}