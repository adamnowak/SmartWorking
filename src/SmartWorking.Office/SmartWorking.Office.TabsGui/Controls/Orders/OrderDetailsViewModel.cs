using System;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Buildings;
using SmartWorking.Office.TabsGui.Controls.Clients;
using SmartWorking.Office.TabsGui.Controls.DeliveryNotes;
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
      ClientDetailsViewModel = new ClientDetailsViewModel(MainViewModel, null, ModalDialogService, ServiceFactory);
      ClientListViewModel = new ClientListViewModel(MainViewModel, ClientDetailsViewModel, ModalDialogService, ServiceFactory);

      ClientListViewModel.Items.SelectedItemChanged += new System.EventHandler<SelectedItemChangedEventArgs<ClientAndClientBuildingsPackage>>(Items_SelectedItemChanged);

      ClientBuildingDetailsViewModel = new ClientBuildingDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      ClientBuildingListViewModel = new ClientBuildingListViewModel(MainViewModel, ClientBuildingDetailsViewModel, ModalDialogService, ServiceFactory);

      RecipeDetailsViewModel = new RecipeDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      RecipeListViewModel = new RecipeListViewModel(MainViewModel, RecipeDetailsViewModel, ModalDialogService, ServiceFactory);

      DeliveryNoteDetailsViewModel = new DeliveryNoteDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      DeliveryNoteListViewModel = new DeliveryNoteListViewModel(MainViewModel, DeliveryNoteDetailsViewModel,
                                                                ModalDialogService, ServiceFactory);
    }

    


    void Items_SelectedItemChanged(object sender, SelectedItemChangedEventArgs<ClientAndClientBuildingsPackage> e)
    {
      if (e.NewValue != null)
      {
        ClientBuildingListViewModel.Items.LoadItems(e.NewValue.ClientBuildings);
      }
      else
      {
        ClientBuildingListViewModel.Items.LoadItems(null);
      }
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
    public ClientBuildingListViewModel ClientBuildingListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public ClientBuildingDetailsViewModel ClientBuildingDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public RecipeListViewModel RecipeListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public RecipeDetailsViewModel RecipeDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the delivery note details view model.
    /// </summary>
    public DeliveryNoteDetailsViewModel DeliveryNoteDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the delivery note list view model.
    /// </summary>
    public DeliveryNoteListViewModel DeliveryNoteListViewModel { get; private set; }

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
      Item.ClientBuildingPackage = ClientBuildingDetailsViewModel.Item;
      if (RecipeDetailsViewModel.Item != null)
      {
        Item.Recipe = RecipeDetailsViewModel.Item.Recipe;
      }
      if (base.OnSaveItem())
      {
        using (IOrdersService service = ServiceFactory.GetOrdersService())
        {
          service.CreateOrUpdateOrder(Item.GetOrderPrimitiveWithReference());
        }
        return true;
      }
      return false;
    }

    protected override bool OnRefresh()
    {
      //ClientDetailsViewModel.Refresh();
      ClientListViewModel.Refresh();
      
      //BuildingDetailsViewModel.Refresh();
      //BuildingListViewModel.Refresh();
      
      //RecipeDetailsViewModel.Refresh();
      RecipeListViewModel.Refresh();

      return base.OnRefresh(); 
    }

  

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    protected override void OnItemChanged(OrderPackage oldItem)
    {

      ClientListViewModel.Items.SelectedItem = null;
      ClientBuildingListViewModel.Items.SelectedItem = null;
      RecipeListViewModel.Items.SelectedItem = null;
      DeliveryNoteListViewModel.Items.SelectedItem = null;

      if (Item != null)
      {
        if (Item.Client != null)
        {
          ClientListViewModel.Items.SelectedItem = ClientListViewModel.Items.Items.Where(x => x.Client.Id == Item.Client.Id).FirstOrDefault();
        }

        if (Item.ClientBuildingPackage != null && Item.ClientBuildingPackage.ClientBuilding != null)
        {
          ClientBuildingListViewModel.Items.SelectedItem = ClientBuildingListViewModel.Items.Items.Where(x => x.ClientBuilding.Id == Item.ClientBuildingPackage.ClientBuilding.Id).FirstOrDefault();
        }

        if (Item.Recipe != null)
        {
          RecipeListViewModel.Items.SelectedItem = RecipeListViewModel.Items.Items.Where(x => x.Recipe.Id == Item.Recipe.Id).FirstOrDefault();
        }

        if (Item.DeliveryNotePackageList != null)
        {
          DeliveryNoteListViewModel.Items.LoadItems(Item.DeliveryNotePackageList);
        }
      }
      

      

      //if (Producers.Items != null && Item != null && Item.Deliverer != null)
      //{
      //  Producers.SelectedItem = Producers.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
      //  Item.Deliverer = Producers.SelectedItem;
      //}
      //else
      //{
      //  Producers.SelectedItem = null;
      //}

    }
  }

}