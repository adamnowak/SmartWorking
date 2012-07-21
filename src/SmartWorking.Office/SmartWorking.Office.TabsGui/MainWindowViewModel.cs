using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
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
using SmartWorking.Office.TabsGui.Shared.View;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

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
      AdministrationGroupViewModel = new AdministrationGroupViewModel(this, ModalDialogService, ServiceFactory);
      AccessLevel = AccessLevels.AdministratorLevel;//.WOSLevel;
    }
    

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

    private bool _isDebugMode = true;

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
        // Update bindings, no broadcast
        RaisePropertyChanged(IsDebugModePropertyName);
      }
    }
    #endregion //IsDebugMode



    public AdministrationGroupViewModel AdministrationGroupViewModel { get; private set; }

    

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "str_SmartWorking.Office"; }
    }



  }
}
