using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Controls.Clients;
using SmartWorking.Office.TabsGui.Controls.Drivers;
using SmartWorking.Office.TabsGui.Controls.Orders;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class OrdersTabItemViewModel : ControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OrdersTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public OrdersTabItemViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      OrderDetailsViewModel = new OrderDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      OrderListViewModel = new OrderListViewModel(MainViewModel, OrderDetailsViewModel, ModalDialogService, ServiceFactory);
      
      ClientDetailsViewModel = new ClientDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      ClientListViewModel = new ClientListViewModel(MainViewModel, ClientDetailsViewModel, ModalDialogService, ServiceFactory);

      BuildingDetailsViewModel = new BuildingDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      BuildingListViewModel = new BuildingListViewModel(MainViewModel, BuildingDetailsViewModel, ModalDialogService, ServiceFactory);

      RecipeDetailsViewModel = new RecipeDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      RecipeListViewModel = new RecipeListViewModel(MainViewModel, RecipeDetailsViewModel, ModalDialogService, ServiceFactory);
    }

    /// <summary>
    /// Gets the car list view model.
    /// </summary>
    public OrderListViewModel OrderListViewModel { get; private set; }

    /// <summary>
    /// Gets the car details view model.
    /// </summary>
    public OrderDetailsViewModel OrderDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public ClientListViewModel ClientListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public ClientDetailsViewModel ClientDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public BuildingListViewModel BuildingListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public BuildingDetailsViewModel BuildingDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public RecipeListViewModel RecipeListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public RecipeDetailsViewModel RecipeDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_OrdersTabItem"; }
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    public override void Refresh()
    {
      OrderListViewModel.Refresh();
      OrderDetailsViewModel.Refresh();
      ClientListViewModel.Refresh();
      ClientDetailsViewModel.Refresh();
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               OrderListViewModel.IsReadOnly &&
               OrderDetailsViewModel.IsReadOnly &&
               ClientListViewModel.IsReadOnly &&
               ClientDetailsViewModel.IsReadOnly;
      }
    }
  }
}