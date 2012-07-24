using System.Windows.Controls;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class SaleGroupViewModel : TabControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public SaleGroupViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      ClientsAndBuildingsTabItemViewModel = new ClientsAndBuildingsTabItemViewModel(mainViewModel, ModalDialogService, ServiceFactory);
      OrdersTabItemViewModel = new OrdersTabItemViewModel(mainViewModel, ModalDialogService, ServiceFactory);
      DeliveryNotesTabItemViewModel = new DeliveryNotesTabItemViewModel(mainViewModel, ModalDialogService, ServiceFactory);
    }

    /// <summary>
    /// Gets the drivers and cars tab item view model.
    /// </summary>
    public ClientsAndBuildingsTabItemViewModel ClientsAndBuildingsTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the materials and contractors tab item view model.
    /// </summary>
    public OrdersTabItemViewModel OrdersTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the recipes tab item view model.
    /// </summary>
    public DeliveryNotesTabItemViewModel DeliveryNotesTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "str_SaleGroup"; }
    }

    

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&               
          (ClientsAndBuildingsTabItemViewModel != null ? ClientsAndBuildingsTabItemViewModel.IsReadOnly : true);
      }
    }

  }
}
