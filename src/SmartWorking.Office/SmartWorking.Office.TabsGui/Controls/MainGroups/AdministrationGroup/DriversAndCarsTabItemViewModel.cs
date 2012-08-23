using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Controls.Drivers;
using SmartWorking.Office.TabsGui.Properties;
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
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DriversAndCarsTabItemViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      CarDetailsViewModel = new CarDetailsViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      CarListViewModel = new CarListViewModel(MainViewModel, CarDetailsViewModel, ModalDialogProvider, ServiceFactory);
      DriverDetailsViewModel = new DriverDetailsViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      DriverListViewModel = new DriverListViewModel(MainViewModel, DriverDetailsViewModel, ModalDialogProvider, ServiceFactory);

      ViewModelProvider.RegisterChildViewModel(CarDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged |  ViewModelProviderAction.SaveInvoked);
      ViewModelProvider.RegisterChildViewModel(DriverDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged | ViewModelProviderAction.SaveInvoked);

      ViewModelProvider.RegisterChildViewModel(CarListViewModel, ViewModelProviderAction.DeleteInvoked);
      ViewModelProvider.RegisterChildViewModel(DriverListViewModel, ViewModelProviderAction.DeleteInvoked);

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
        if (e.ViewModel == DriverListViewModel)
        {
          CarDetailsViewModel.Refresh();
        }
        if (e.ViewModel == CarListViewModel)
        {
          DriverListViewModel.Refresh();
        }
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
      get { return Resources.DriversAndCarsTabItemViewModel_Name; }
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

    public override void Save()
    {
      base.Save();
      if (CarListViewModel != null && !CarListViewModel.IsReadOnly) CarListViewModel.Save();
      if (CarDetailsViewModel != null && !CarDetailsViewModel.IsReadOnly) CarDetailsViewModel.Save();
      if (DriverListViewModel != null && !DriverListViewModel.IsReadOnly) DriverListViewModel.Save();
      if (DriverDetailsViewModel != null && !DriverDetailsViewModel.IsReadOnly) DriverDetailsViewModel.Save();
    }

    public override void Cancel()
    {
      base.Cancel();
      if (CarListViewModel != null && !CarListViewModel.IsReadOnly) CarListViewModel.Cancel();
      if (CarDetailsViewModel != null && !CarDetailsViewModel.IsReadOnly) CarDetailsViewModel.Cancel();
      if (DriverListViewModel != null && !DriverListViewModel.IsReadOnly) DriverListViewModel.Cancel();
      if (DriverDetailsViewModel != null && !DriverDetailsViewModel.IsReadOnly) DriverDetailsViewModel.Cancel();
    }
  }
}