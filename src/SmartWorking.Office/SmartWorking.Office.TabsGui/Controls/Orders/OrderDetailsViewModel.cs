using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Clients;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Orders
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class OrderDetailsViewModel : EditableControlViewModelBase<OrderPackage>
  {
    public OrderDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      ClientDetailsViewModel = new ClientDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      ClientListViewModel = new ClientListViewModel(MainViewModel, ClientDetailsViewModel, ModalDialogService, ServiceFactory);

      BuildingDetailsViewModel = new BuildingDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      BuildingListViewModel = new BuildingListViewModel(MainViewModel, BuildingDetailsViewModel, ModalDialogService, ServiceFactory);

      RecipeDetailsViewModel = new RecipeDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      RecipeListViewModel = new RecipeListViewModel(MainViewModel, RecipeDetailsViewModel, ModalDialogService, ServiceFactory);

      
    }

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
      get { return "str_OrderDetails"; }
    }

    protected override void EditItemCommandExecute()
    {
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSaveItem()
    {
      if (base.OnSaveItem())
      {
        using (IOrdersService service = ServiceFactory.GetOrdersService())
        {
          service.CreateOrUpdateOrderPackage(Item);
        }
        return true;
      }
      return false;
    }

    public override void Refresh()
    {
      //ClientDetailsViewModel.Refresh();
      ClientListViewModel.Refresh();
      
      //BuildingDetailsViewModel.Refresh();
      BuildingListViewModel.Refresh();
      
      //RecipeDetailsViewModel.Refresh();
      RecipeListViewModel.Refresh();

      base.Refresh();
    }

  

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    //protected override void OnItemChanged(CarAndDriverPackage oldItem)
    //{
    //  if (Producers.Items != null && Item != null && Item.Deliverer != null)
    //  {
    //    Producers.SelectedItem = Producers.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
    //    Item.Deliverer = Producers.SelectedItem;
    //  }
    //  else
    //  {
    //    Producers.SelectedItem = null;
    //  }

    //}
  }
}