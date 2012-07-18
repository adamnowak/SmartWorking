using System;
using System.ServiceModel;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

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
    public EditableControlViewModelBase(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    public override void Refresh() {}

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
        T oldValue = _item;
        _item = value;
        OnItemChanged(oldValue);

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
      return IsReadOnly && Item != null;
    }

    /// <summary>
    /// Execute edit command.
    /// </summary>
    protected virtual void EditItemCommandExecute()
    {
      EditingMode = Shared.ViewModel.EditingMode.Edit;
    }
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
      return !IsReadOnly && Item != null;
    }

    /// <summary>
    /// Execute save command.
    /// </summary>
    protected virtual void SaveItemCommandExecute()
    {
      string errorCaption = "str_SaveItem" + Name;
      try
      {
        if (OnSaveItem())
        {
          if (ItemSaved != null)
          {
            ItemSaved(null, null);
          }
        }
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
      }
      
    }

    /// <summary>
    /// Called when [save item].
    /// </summary>
    /// <returns></returns>
    protected virtual bool OnSaveItem()
    {
      EditingMode = EditingMode.Display;
      return true;
    }

    /// <summary>
    /// Occurs when item saved.
    /// </summary>
    public event EventHandler ItemSaved;
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
      return !IsReadOnly && Item != null;
    }

    /// <summary>
    /// Execute cancel command.
    /// </summary>
    private void CancelChangesCommandExecute()
    {
      if (OnCancelChanges())
      {
        if (ChangesCanceled != null)
        {
          ChangesCanceled(null, null);
        }
      }
    }

    /// <summary>
    /// Called when [cancel changes].
    /// </summary>
    /// <returns>true if ChangesCanceled event should be fired.</returns>
    protected virtual bool OnCancelChanges()
    {
      EditingMode = EditingMode.Display;
      return true;
    }

    /// <summary>
    /// Occurs when canceled changes.
    /// </summary>
    public event EventHandler ChangesCanceled;

    protected virtual void OnItemChanged(T oldItem)
    {
      
    }

    #endregion
  }
}