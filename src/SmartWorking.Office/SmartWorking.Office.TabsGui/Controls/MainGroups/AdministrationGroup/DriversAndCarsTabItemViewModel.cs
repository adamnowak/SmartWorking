using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Controls.Drivers;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class DriversAndCarsTabItemViewModel : ControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DriversAndCarsTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DriversAndCarsTabItemViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      CarDetailsViewModel = new CarDetailsViewModel(ModalDialogService, ServiceFactory);
      CarListViewModel = new CarListViewModel(CarDetailsViewModel, ModalDialogService, ServiceFactory);
      DriverDetailsViewModel = new DriverDetailsViewModel(ModalDialogService, ServiceFactory);
      DriverListViewModel = new DriverListViewModel(DriverDetailsViewModel, ModalDialogService, ServiceFactory);
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