﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
#if IIS_USED
using SmartWorking.Office.Services.Factory.IIS;
#else
using SmartWorking.Office.Gui.ViewModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.MetaDates;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Factory.Local;
#endif
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Controls.MainGroups;
using SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup;
using SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup;
using SmartWorking.Office.TabsGui.Shared.View;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.MessageBox;
using SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs;
using WPFLocalizeExtension.Engine;

namespace SmartWorking.Office.TabsGui
{

  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class MainWindowViewModel : TabControlViewModelBase, IMainViewModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public MainWindowViewModel()
      : base(null, null, null)
    {
      ServiceFactory =
#if IIS_USED
      new ServiceFactoryIIS();
#else
 new ServiceFactoryLocal();
#endif

      ModalDialogProvider = new ModalDialogProvider(ServiceFactory);
      MainViewModel = this;
      //ModalDialogProvider.MainViewModel = MainViewModel;
      SaleGroupViewModel = new SaleGroupViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      AdministrationGroupViewModel = new AdministrationGroupViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      SettingsGroupViewModel = new SettingsGroupViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      ReportsGroupViewModel = new ReportsGroupViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      IsBlockedAccessLevel = false;

      LocalizeDictionary.Instance.Culture = new CultureInfo("pl-PL");
      Configuration = new SmartWorkingConfiguration();
      Configuration.PreviewDeliveryNote = true;
      Configuration.PagesToPrint = 1;

      AccessLevel = AccessLevels.None;
      IsDebugMode = false;
      IsBlockedAccessLevel = true;

#if CONFIG_NAME_Debug
      AccessLevel = AccessLevels.AdministratorLevel;
      IsDebugMode = true;
      IsBlockedAccessLevel = false;
    
#endif
    }


    #region LoadedCommand
    private ICommand _loadedCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand LoadedCommand
    {
      get
      {
        if (_loadedCommand == null)
          _loadedCommand = new RelayCommand(Loaded, CanLoaded);
        return _loadedCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanLoaded()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void Loaded()
    {
#if !CONFIG_NAME_Debug
      ModalDialogProvider.ShowLogginDialog(this);
#endif      
    }
    #endregion //LoadedCommand


    #region LoggoutCommand
    private ICommand _logoutCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand LoggoutCommand
    {
      get
      {
        if (_logoutCommand == null)
          _logoutCommand = new RelayCommand(Loggout, CanLoggout);
        return _logoutCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanLoggout()
    {
      return AccessLevel != AccessLevels.None;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void Loggout()
    {
      string errorCaption = "TODO!";
      try
      {
        AccessLevel = AccessLevels.None;
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }
    #endregion //LoggoutCommand
    /// <summary>
    /// Gets a value indicating whether this instance is blocked access level.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is blocked access level; otherwise, <c>false</c>.
    /// </value>
    public bool IsBlockedAccessLevel { get; private set; }

    #region AccessLevel
    /// <summary>
    /// The <see cref="AccessLevel" /> property's name.
    /// </summary>
    public const string AccessLevelPropertyName = "AccessLevel";

    private AccessLevel _accessLevel;

    /// <summary>
    /// Gets the AccessLevel property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public AccessLevel AccessLevel
    {
      get
      {
        return _accessLevel;
      }

      set
      {
        if (_accessLevel == value)
        {
          return;
        }

        _accessLevel = value;

        if (AccessLevel == AccessLevels.None)
        {
          ModalDialogProvider.ShowLogginDialog(this);
        }

        // Update bindings, no broadcast
        RaisePropertyChanged(AccessLevelPropertyName);
      }
    }
    #endregion //AccessLevel

    #region IsDebugMode
    /// <summary>
    /// The <see cref="IsDebugMode" /> property's name.
    /// </summary>
    public const string IsDebugModePropertyName = "IsDebugMode";

    private bool _isDebugMode;

    /// <summary>
    /// Gets the IsDebugMode property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool IsDebugMode
    {
      get
      {
        return _isDebugMode;
      }

      set
      {
        if (_isDebugMode == value)
        {
          return;
        }
        _isDebugMode = value;
        if (_isDebugMode)
        {
          var ci = new CultureInfo("en-US");
          LocalizeDictionary.Instance.Culture = ci;

          Thread.CurrentThread.CurrentCulture = ci;
          Thread.CurrentThread.CurrentUICulture = ci;
          //FrameworkElement.LanguageProperty.OverrideMetadata(
          //     typeof(FrameworkElement),
          //     new FrameworkPropertyMetadata(
          //         XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
        else
        {
          var ci = new CultureInfo("pl-PL");
          LocalizeDictionary.Instance.Culture = ci;

          Thread.CurrentThread.CurrentCulture = ci;
          Thread.CurrentThread.CurrentUICulture = ci;
          //FrameworkElement.LanguageProperty.OverrideMetadata(
          //     typeof(FrameworkElement),
          //     new FrameworkPropertyMetadata(
          //         XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        // Update bindings, no broadcast
        RaisePropertyChanged(IsDebugModePropertyName);
      }
    }
    #endregion //IsDebugMode

    public SaleGroupViewModel SaleGroupViewModel { get; private set; }

    public AdministrationGroupViewModel AdministrationGroupViewModel { get; private set; }

    public SettingsGroupViewModel SettingsGroupViewModel { get; private set; }

    public ReportsGroupViewModel ReportsGroupViewModel { get; private set; }

    #region StatusText
    /// <summary>
    /// The <see cref="StatusText" /> property's name.
    /// </summary>
    public const string StatusTextPropertyName = "StatusText";

    private string _statusText;

    /// <summary>
    /// Gets the StatusText property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string StatusText
    {
      get
      {
        return _statusText;
      }

      set
      {
        if (_statusText == value)
        {
          return;
        }
        _statusText = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(StatusTextPropertyName);
      }
    }
    #endregion //StatusText

    #region StatusTextColor
    /// <summary>
    /// The <see cref="StatusTextColor" /> property's name.
    /// </summary>
    public const string StatusTextColorPropertyName = "StatusTextColor";

    private Color _statusTextColor;

    /// <summary>
    /// Gets the StatusTextColor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Color StatusTextColor
    {
      get
      {
        return _statusTextColor;
      }

      set
      {
        if (_statusTextColor == value)
        {
          return;
        }
        _statusTextColor = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(StatusTextColorPropertyName);
      }
    }

    public bool SetAccessByUserPassword(string userId, string password)
    {
      if (password == null || string.IsNullOrEmpty(userId))
        return false;
      if (password == "Belchatow12" && userId.ToLower() == "szef")
      {
        AccessLevel = AccessLevels.AdministratorLevel;
      }
      else if (password == "PBasia" && userId.ToLower() == "basia")
      {
        AccessLevel = AccessLevels.WOSLevel;
      }
      else if (userId.ToLower() == "operator")
      {
        AccessLevel = AccessLevels.OperatorLevel;
      }
      else
      {
        return false;
      }
      return true;
    }



    #endregion //StatusTextColor

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "str_SmartWorking.Office"; }
    }

    public SmartWorkingConfiguration Configuration { get; private set; }



  }
}
