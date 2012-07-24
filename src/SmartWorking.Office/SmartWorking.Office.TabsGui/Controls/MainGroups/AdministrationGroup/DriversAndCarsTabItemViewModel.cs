using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Controls.Drivers;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class DriversAndCarsTabItemViewModel : TabItemViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DriversAndCarsTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DriversAndCarsTabItemViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      CarDetailsViewModel = new CarDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      CarListViewModel = new CarListViewModel(MainViewModel, CarDetailsViewModel, ModalDialogService, ServiceFactory);
      DriverDetailsViewModel = new DriverDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      DriverListViewModel = new DriverListViewModel(MainViewModel, DriverDetailsViewModel, ModalDialogService, ServiceFactory);

      ViewModelProvider.RegisterChildViewModel(CarDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged);
      ViewModelProvider.RegisterChildViewModel(DriverDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged);
    }

    /// <summary>
    /// Gets the car list view model.
    /// </summary>
    public CarListViewModel CarListViewModel { get; private set; }

    /// <summary>
    /// Gets the car details view model.
    /// </summary>
    public CarDetailsViewModel CarDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public DriverListViewModel DriverListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public DriverDetailsViewModel DriverDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_DriversAndCarsTabItem"; }
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    public override void Refresh()
    {
      CarListViewModel.Refresh();
      CarDetailsViewModel.Refresh();
      DriverListViewModel.Refresh();
      DriverDetailsViewModel.Refresh();
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               CarListViewModel.IsReadOnly &&
               CarDetailsViewModel.IsReadOnly &&
               DriverListViewModel.IsReadOnly &&
               DriverDetailsViewModel.IsReadOnly;
      }
    }
  }
}