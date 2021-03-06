﻿using System;
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
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{  
  /// <summary>
  /// View model for tab control.
  /// </summary>
  public abstract class TabItemViewModelBase : ControlViewModelBase, ITabItemViewModel 
  {
    public override void Save()
    {
     
    }

    public override void Cancel()
    {
      
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TabControlViewModelBase"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public TabItemViewModelBase(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
    }

    #region RefreshCommand
    private ICommand _refreshCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand RefreshCommand
    {
      get
      {
        if (_refreshCommand == null)
          _refreshCommand = new RelayCommand(Refresh, CanRefresh);
        return _refreshCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanRefresh()
    {
      return true;
    }

    
    #endregion //RefreshCommand
    
  }
}
