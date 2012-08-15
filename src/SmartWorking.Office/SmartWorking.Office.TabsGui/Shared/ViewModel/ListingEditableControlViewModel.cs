using System;
using System.ServiceModel;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

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
    public ListingEditableControlViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<T> editingViewModel,
      IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      ListItemsFilter = ListItemsFilterValues.OnlyActive;
      Items = new SelectableViewModelBase<T>();
      EditingViewModel = editingViewModel;
      Items.SelectedItemChanged +=
        (o, e) =>
        Dispatcher.CurrentDispatcher.BeginInvoke(new System.EventHandler<SelectedItemChangedEventArgs<T>>(Items_SelectedItemChanged), o, e);
      if (EditingViewModel != null)
      {
        EditingViewModel.Item = Items.SelectedItem;
        EditingViewModel.ChangesCanceled += new System.EventHandler(EditingViewModel_ChangesCanceled);
        EditingViewModel.ItemSaved += new System.EventHandler(EditingViewModel_ItemSaved);
      }
    }

    public override void Save()
    {
      EditingViewModel.Save();
    }

    public override void Cancel()
    {
      EditingViewModel.Cancel();
    }

    /// <summary>
    /// Handles the ItemSaved event of the EditingViewModel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void EditingViewModel_ItemSaved(object sender, System.EventArgs e)
    {
      Refresh();
    }

    /// <summary>
    /// Handles the ChangesCanceled event of the EditingViewModel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    void EditingViewModel_ChangesCanceled(object sender, System.EventArgs e)
    {
      if (EditingViewModel != null)
      {
        EditingViewModel.Item = Items.SelectedItem;
      }
    }

    /// <summary>
    /// Handles the SelectedItemChanged event of the Items control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SmartWorking.Office.TabsGui.Shared.ViewModel.SelectedItemChangedEventArgs&lt;T&gt;"/> instance containing the event data.</param>
    void Items_SelectedItemChanged(object sender, SelectedItemChangedEventArgs<T> e)
    {
      if (EditingViewModel != null)
      {
        if (EditingViewModel != null && EditingViewModel.IsReadOnly && e != null)
        {
          EditingViewModel.Item = e.NewValue;
        }
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

    #region Filter
    /// <summary>
    /// The <see cref="Filter" /> property's name.
    /// </summary>
    public const string FilterPropertyName = "Filter";

    private string _filter;

    /// <summary>
    /// Gets the Filter property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string Filter
    {
      get
      {
        return _filter;
      }

      set
      {
        if (_filter == value)
        {
          return;
        }
        _filter = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(FilterPropertyName);

        OnFilterChanged();
      }
    }

    protected virtual void OnFilterChanged()
    {
      Refresh();
    }

    #endregion //Filter

    #region ListItemsFilter
    /// <summary>
    /// The <see cref="ListItemsFilter" /> property's name.
    /// </summary>
    public const string ListItemsFilterPropertyName = "ListItemsFilter";

    private ListItemsFilterValues _istItemsFilterType;

    /// <summary>
    /// Gets the ListItemsFilter property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public ListItemsFilterValues ListItemsFilter
    {
      get
      {
        return _istItemsFilterType;
      }

      set
      {
        if (_istItemsFilterType == value)
        {
          return;
        }
        _istItemsFilterType = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(ListItemsFilterPropertyName);
        OnListItemsFilterChanged();
      }
    }

    protected virtual void OnListItemsFilterChanged()
    {
      Refresh();
    }
    #endregion //ListItemsFilter


    /// <summary>
    /// Loads the items.
    /// </summary>
    protected virtual void LoadItems()
    {
      string errorCaption = Name;
      try
      {
        OnLoadItems();
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
    /// Called when load items.
    /// </summary>
    protected virtual void OnLoadItems()
    {
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    protected override bool OnRefresh()
    {
      LoadItems();
      return true;
    }

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

    private void AddItemCommandExecute()
    {
      string errorCaption = "str_AddItem" + Name;
      try
      {
        OnAddItem();
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
    /// Determines whether add command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if add command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanAddItemCommandExecute()
    {
      return EditingViewModel.IsReadOnly;
    }

    /// <summary>
    /// Execute add command.
    /// </summary>
    protected virtual void OnAddItem()
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

    private void AddCloneItemCommandExecute()
    {
      string errorCaption = "str_AddCloneItem" + Name;
      try
      {
        OnAddCloneItem();
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
    /// Determines whether addClone command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if addClone command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanAddCloneItemCommandExecute()
    {
      return EditingViewModel.IsReadOnly && Items.SelectedItem != null;
    }

    /// <summary>
    /// Execute addClone command.
    /// </summary>
    protected virtual void OnAddCloneItem()
    { }
    #endregion

    #region ChangeItemDeletedFlagCommand
    private ICommand _changeItemDeletedFlagCommand;
    /// <summary>
    /// Gets the delete command which enables to delete existing item.
    /// </summary>
    public ICommand ChangeItemDeletedFlagCommand
    {
      get
      {
        if (_changeItemDeletedFlagCommand == null)
          _changeItemDeletedFlagCommand = new RelayCommand(ChangeItemDeletedFlagCommandExecute, CanChangeItemDeletedFlagCommandExecute);
        return _changeItemDeletedFlagCommand;
      }
    }

    public event EventHandler ItemDeletedFlagChanged;

    /// <summary>
    /// Determines whether delete command can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if delete command can be execute; otherwise, <c>false</c>.
    /// </returns>
    protected virtual bool CanChangeItemDeletedFlagCommandExecute()
    {
      return EditingViewModel.IsReadOnly && Items.SelectedItem != null;
    }

    /// <summary>
    /// Execute delete command.
    /// </summary>
    protected void ChangeItemDeletedFlagCommandExecute()
    {
      string errorCaption = "str_SaveItem" + Name;
      try
      {
        if (OnItemDeletedFlagChanged())
        {
          if (ItemDeletedFlagChanged != null)
          {
            ItemDeletedFlagChanged(this, EventArgs.Empty);
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

    protected virtual bool OnItemDeletedFlagChanged()
    {
      return true;
    }

    #endregion  

    #region ApplyFilterCommand
    private ICommand _applyFilterCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand ApplyFilterCommand
    {
      get
      {
        if (_applyFilterCommand == null)
          _applyFilterCommand = new RelayCommand(ApplyFilter, CanApplyFilter);
        return _applyFilterCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanApplyFilter()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void ApplyFilter()
    {
      Refresh();
    }
    #endregion //ApplyFilterCommand
  }
}