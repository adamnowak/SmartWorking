using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public abstract class TabControlViewModelBase : ControlViewModelBase, ITabControlViewModel
  {
    public TabControlViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    protected TabItem GetTabItem(SelectionChangedEventArgs selectionChangedEventArgs, bool bOldTabItem = true)
    {
      if (bOldTabItem)
      {
        if (selectionChangedEventArgs.RemovedItems != null && selectionChangedEventArgs.RemovedItems.Count > 0)
        {
          return selectionChangedEventArgs.RemovedItems[0] as TabItem;
        }
      }
      else
      {
        if (selectionChangedEventArgs.AddedItems != null && selectionChangedEventArgs.AddedItems.Count > 0)
        {
          return selectionChangedEventArgs.AddedItems[0] as TabItem;
        }
      }
      return null;
    }

    protected IControlViewModel GetControlViewModel(SelectionChangedEventArgs selectionChangedEventArgs, bool bOldTabItem = true)
    {
      TabItem tabItem = GetTabItem(selectionChangedEventArgs, bOldTabItem);
      if (tabItem != null)
      {
        return GetControlViewModel(tabItem);
      }
      return null;
    }

    protected IControlViewModel GetControlViewModel(TabItem tabItem)
    {
      if (tabItem.DataContext != null)
      {
        return tabItem.DataContext as IControlViewModel;
      }

      return null;
    }

    public override void Refresh()
    {
      if (SelectedTab != null)
      {
        IControlViewModel controlViewModel = GetControlViewModel(SelectedTab);
        if (controlViewModel != null && controlViewModel != this)
        {
          controlViewModel.Refresh();
        }
      }
    }


    #region SelectedTab
    /// <summary>
    /// The <see cref="SelectedTab" /> property's name.
    /// </summary>
    public const string SelectedTabPropertyName = "SelectedTab";

    private TabItem _selectedTab;

    /// <summary>
    /// Gets the SelectedTab property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public TabItem SelectedTab
    {
      get
      {
        return _selectedTab;
      }

      set
      {
        TabItem oldValue = _selectedTab;
        if (_selectedTab == value)
        {
          return;
        }
        _selectedTab = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(SelectedTabPropertyName);

        //workaround
        WorkaroundOnSelectedTab(oldValue);
      }
    }

    protected virtual void WorkaroundOnSelectedTab(TabItem oldValue)
    {
      //if (oldValue == null)
      //{
      //  TabChanged(new SelectionChangedEventArgs(TabControl.SelectionChangedEvent, new List<TabItem>(), new List<TabItem> { _selectedTab }));
      //}
    }

    #endregion //SelectedTab

    #region TabChangedCommand
    private ICommand _tabChangedCommand;

    /// <summary>
    /// Gets the tab change command.
    /// </summary>
    public ICommand TabChangedCommand
    {
      get
      {
        if (_tabChangedCommand == null)
          _tabChangedCommand = new RelayCommand<object>(TabChanged);
        return _tabChangedCommand;
      }
    }



    /// <summary>
    /// Executes tab changed command.
    /// </summary>
    protected void TabChanged(object o)
    {
      SelectionChangedEventArgs selectionChangedEventArgs = o as SelectionChangedEventArgs;
      if (selectionChangedEventArgs != null)
      {
        TabControl tabControl = selectionChangedEventArgs.Source as TabControl;
        if (tabControl != null)
        {
          IControlViewModel oldControlViewModel = GetControlViewModel(selectionChangedEventArgs);
          if (oldControlViewModel != null && !oldControlViewModel.IsReadOnly)
          {
            //if (ShowMessage() == save)
            {
              //come to previouse
              //selectionChangedEventArgs.Handled = true;
              //return;
            }
          }
          
        }
        IControlViewModel newControlViewModel = GetControlViewModel(selectionChangedEventArgs, false);
        if (newControlViewModel != null)
        {
          newControlViewModel.Refresh();
        }
        selectionChangedEventArgs.Handled = true;
      }
    }

    

    
    #endregion //TabChangedCommand

    
  }
}
