using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using SmartWorking.Office.Services.Factory.Local;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Shared.View;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class MainWindowViewModel : ControlViewModelBase
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
        
    }

    

    public CarListViewModel CarListViewModel { get; private set; }
    public CarDetailsViewModel CarDetailsViewModel { get; private set; }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    public override void Refresh()
    {
      
    }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "SmartWorking.Office"; }
    }
  }
}
