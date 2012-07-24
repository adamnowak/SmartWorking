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

      ViewModelProvider.RegisterChildViewModel(CarDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged | ViewModelProviderAction.DeleteInvoked | ViewModelProviderAction.SaveInvoked);
      ViewModelProvider.RegisterChildViewModel(DriverDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged | ViewModelProviderAction.DeleteInvoked | ViewModelProviderAction.SaveInvoked);

      ViewModelProvider.ChildrenViewModelDeleteInvoked += new System.EventHandler<ViewModelProviderActionEventArgs>(ViewModelProvider_ChildrenViewModelDeleteInvoked);
      ViewModelProvider.ChildrenViewModelSaveInvoked += new System.EventHandler<ViewModelProviderActionEventArgs>(ViewModelProvider_ChildrenViewModelSaveInvoked);
    }

    void ViewModelProvider_ChildrenViewModelSaveInvoked(object sender, ViewModelProviderActionEventArgs e)
    {
      if (e != null && e.ViewModel != null)
      {
        if (e.ViewModel == DriverDetailsViewModel)
        {
          CarDetailsViewModel.Refresh();
        }
        if (e.ViewModel == CarDetailsViewModel)
        {
          DriverListViewModel.Refresh();
        }
      }
    }

    void ViewModelProvider_ChildrenViewModelDeleteInvoked(object sender, ViewModelProviderActionEventArgs e)
    {
      if (e != null && e.ViewModel != null)
      {

      }
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
    protected override bool OnRefresh()
    {
      CarListViewModel.Refresh();
      CarDetailsViewModel.Refresh();
      DriverListViewModel.Refresh();
      DriverDetailsViewModel.Refresh();
      return true;
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               (CarListViewModel != null ? CarListViewModel.IsReadOnly : true) &&
               (CarDetailsViewModel != null ? CarDetailsViewModel.IsReadOnly : true) &&
               (DriverListViewModel != null ? DriverListViewModel.IsReadOnly : true) &&
               (DriverDetailsViewModel != null ? DriverDetailsViewModel.IsReadOnly : true);
      }
    }
  }
}