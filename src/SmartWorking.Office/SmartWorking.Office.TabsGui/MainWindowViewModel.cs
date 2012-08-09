﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
#if IIS_USED
using SmartWorking.Office.Services.Factory.IIS;
#else
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
    public MainWindowViewModel():
      this(new ModalDialogService(),
#if IIS_USED
      new ServiceFactoryIIS()
#else
           new ServiceFactoryLocal()
#endif
      )
    {
      //TODO: improve, should be IoC      
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public MainWindowViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(null, modalDialogService, serviceFactory)
    {
      SaleGroupViewModel = new SaleGroupViewModel(this, ModalDialogService, ServiceFactory);
      AdministrationGroupViewModel = new AdministrationGroupViewModel(this, ModalDialogService, ServiceFactory);
      SettingsGroupViewModel = new SettingsGroupViewModel(this, ModalDialogService, ServiceFactory);
      ReportsGroupViewModel = new ReportsGroupViewModel(this, ModalDialogService, ServiceFactory);
      IsBlockedAccessLevel = false; 
      MainViewModel = this;
      AccessLevel = AccessLevels.AdministratorLevel;//.WOSLevel;
      IsDebugMode = false;
      LocalizeDictionary.Instance.Culture = new CultureInfo("pl-PL");
      SmartWorkingConfiguration.Instance.PreviewDeliveryNote = true;
#if CONFIG_NAME_DebugLocalSylwek
      AccessLevel = AccessLevels.OperatorLevel;
      IsDebugMode = false;
      IsBlockedAccessLevel = true;
#endif
    }

   


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

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "str_SmartWorking.Office"; }
    }



  }
}
