using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Input;
using System.Windows.Media;
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
  public abstract class EditableControlViewModelBase<T> : ControlViewModelBase, IEditableControlViewModel<T>, ICustomNotifyDataErrorInfo
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="EditableControlViewModelBase&lt;T&gt;"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public EditableControlViewModelBase(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      
    }

    public override void Save()
    {
      SaveItemCommandExecute();
    }

    public override void Cancel()
    {
      CancelChangesCommandExecute();
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

    public event EventHandler ItemEdited;

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
      if (!IsReadOnly && Item != null)
      {
        Validate();
        return !HasErrors;
      }
      return false;
    }

    /// <summary>
    /// Execute save command.
    /// </summary>
    protected virtual void SaveItemCommandExecute()
    {
      string errorCaption = "str_SaveItem" + Name;
      try
      {
        BeforeSavingItem();
        if (OnSavingItem())
        {
          if (ItemSaved != null)
          {
            ItemSaved(this, EventArgs.Empty);
          }
          OnSavedItem();
        }
        
      }
      catch (FaultException<List<ValidationResult>> lvr)
      {
        ShowError(errorCaption, lvr);
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
    /// Do everything what should be done before save operation (sets properties... )
    /// </summary>
    public virtual void BeforeSavingItem()
    {
      
    }

    /// <summary>
    /// Called when item was saved correctly.
    /// </summary>
    protected virtual void OnSavedItem()
    {
      EditingMode = EditingMode.Display;
    }

    /// <summary>
    /// Called when [save item].
    /// </summary>
    /// <returns></returns>
    protected virtual bool OnSavingItem()
    {
      Validate();
      if (!HasErrors)
      {
        return true;
      }
      return false;
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
          ChangesCanceled(this, EventArgs.Empty);
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

    public void OnSelectedItemChanged(T newValue)
    {
      throw new NotImplementedException();
    }

    protected virtual void OnItemChanged(T oldItem)
    {
      
    }

    #endregion

    public bool HasErrors
    {
      get { return errors != null && errors.Count > 0; }
    }

    private IList<ValidationResult> errors = new List<ValidationResult>();
    public IList<ValidationResult> Errors
    {
      get { return errors; }
      protected set
      {
        errors = value;

        if (HasErrors)
        {
          MainViewModel.StatusText = errors[0].ErrorMessage;
          MainViewModel.StatusTextColor = Colors.Red;
        }
        else
        {
          MainViewModel.StatusText = string.Empty;
        }
        // Update bindings, no broadcast
        RaisePropertyChanged("Errors");
        RaisePropertyChanged("HasErrors");
      }
    }

    public virtual void Validate()
    {

    }
  }
}