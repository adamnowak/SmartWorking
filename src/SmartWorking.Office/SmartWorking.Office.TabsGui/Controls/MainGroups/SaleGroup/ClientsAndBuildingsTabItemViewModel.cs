using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Buildings;
using SmartWorking.Office.TabsGui.Controls.Clients;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class ClientsAndBuildingsTabItemViewModel : TabItemViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ProducersAndMaterialsTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ClientsAndBuildingsTabItemViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      BuildingDetailsViewModel = new BuildingDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      BuildingListViewModel = new BuildingListViewModel(MainViewModel, BuildingDetailsViewModel, ModalDialogService, ServiceFactory);

      ClientDetailsViewModel = new ClientDetailsViewModel(MainViewModel, BuildingListViewModel, ModalDialogService, ServiceFactory);
      ClientListViewModel = new ClientListViewModel(MainViewModel, ClientDetailsViewModel, ModalDialogService, ServiceFactory);
      

      ViewModelProvider.RegisterChildViewModel(ClientDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged);
      ViewModelProvider.RegisterChildViewModel(BuildingDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged);
    }

    /// <summary>
    /// Gets the car list view model.
    /// </summary>
    public ClientListViewModel ClientListViewModel { get; private set; }

    /// <summary>
    /// Gets the car details view model.
    /// </summary>
    public ClientDetailsViewModel ClientDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the recipe component details view model.
    /// </summary>
    public BuildingDetailsViewModel BuildingDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the recipe component list view model.
    /// </summary>
    public BuildingListViewModel BuildingListViewModel { get; private set; }



    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.ClientsAndBuildingsTabItemViewModel_Name; }
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    protected override bool OnRefresh()
    {
      ClientListViewModel.Refresh();
      //ClientDetailsViewModel.Refresh();
      BuildingListViewModel.Refresh();
      //BuildingDetailsViewModel.Refresh();
      return true;
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               (ClientListViewModel != null ? ClientListViewModel.IsReadOnly : true) &&
               (ClientDetailsViewModel != null ? ClientDetailsViewModel.IsReadOnly : true) &&
               (BuildingListViewModel != null ? BuildingListViewModel.IsReadOnly : true) &&
               (BuildingDetailsViewModel != null ? BuildingDetailsViewModel.IsReadOnly : true);
      }
    }
  }
}