using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Factory.Local;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Controls.MainGroups;
using SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup;
using SmartWorking.Office.TabsGui.Shared.View;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class MainWindowViewModel : TabControlViewModelBase
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
      : base(modalDialogService, serviceFactory)
    {
      AdministrationGroupViewModel = new AdministrationGroupViewModel(ModalDialogService, ServiceFactory);
    }

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
