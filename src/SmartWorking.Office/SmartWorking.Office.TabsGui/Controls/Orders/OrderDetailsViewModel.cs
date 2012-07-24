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
      ClientDetailsViewModel = new ClientDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      ClientListViewModel = new ClientListViewModel(MainViewModel, ClientDetailsViewModel, ModalDialogService, ServiceFactory);

      ClientListViewModel.Items.SelectedItemChanged += new System.EventHandler<SelectedItemChangedEventArgs<ClientAndBuildingsPackage>>(Items_SelectedItemChanged);

      BuildingDetailsViewModel = new BuildingDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      BuildingListViewModel = new BuildingListViewModel(MainViewModel, BuildingDetailsViewModel, ModalDialogService, ServiceFactory);

      RecipeDetailsViewModel = new RecipeDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      RecipeListViewModel = new RecipeListViewModel(MainViewModel, RecipeDetailsViewModel, ModalDialogService, ServiceFactory);

      DeliveryNoteDetailsViewModel = new DeliveryNoteDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      DeliveryNoteListViewModel = new DeliveryNoteListViewModel(MainViewModel, DeliveryNoteDetailsViewModel,
                                                                ModalDialogService, ServiceFactory);
    }

    


    void Items_SelectedItemChanged(object sender, SelectedItemChangedEventArgs<ClientAndBuildingsPackage> e)
    {
      if (e.NewValue != null)
      {
        BuildingListViewModel.Items.LoadItems(e.NewValue.Buildings);
      }
      else
      {
        BuildingListViewModel.Items.Items.Clear();
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
      if (Item != null && Item.ClientBuildingPackage != null && Item.ClientBuildingPackage.Client != null)
      {
        ClientListViewModel.Items.SelectedItem = ClientListViewModel.Items.Items.Where(x => x.Client.Id == Item.ClientBuildingPackage.Client.Id).FirstOrDefault();
      }
      else
      {
        ClientListViewModel.Items.SelectedItem = null;
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