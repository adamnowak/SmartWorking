using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class DriversAndCarsTabItemViewModel : ControlViewModelBase
  {
    public DriversAndCarsTabItemViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      CarDetailsViewModel = new CarDetailsViewModel(ModalDialogService, ServiceFactory);
      CarListViewModel = new CarListViewModel(CarDetailsViewModel, ModalDialogService, ServiceFactory);
    }

    public CarListViewModel CarListViewModel { get; private set; }
    public CarDetailsViewModel CarDetailsViewModel { get; private set; }

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
    }
  }
}