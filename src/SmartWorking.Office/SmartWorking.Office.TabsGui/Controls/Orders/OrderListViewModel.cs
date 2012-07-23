using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Orders
{
  public class OrderListViewModel : ListingEditableControlViewModel<OrderPackage>
  {
    public OrderListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<OrderPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_OrderList"; }
    }

    protected override void  OnLoadItems()
    {

      OrderPackage selectedItem = Items.SelectedItem;
      using (IOrdersService service = ServiceFactory.GetOrdersService())
      {
        Items.LoadItems(service.GetOrderPackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        OrderPackage selectionFromItems =
          Items.Items.Where(x => x.Order.Id == selectedItem.Order.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new OrderPackage() {Order = new OrderPrimitive()};
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      OrderPackage clone = Items.SelectedItem;
      if (clone != null)
      {
        clone.Order.Id = 0;        
      }
      else
      {
        clone = new OrderPackage() {Order = new OrderPrimitive()};
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void DeleteItemCommandExecute()
    {
      base.DeleteItemCommandExecute();
      using (IContractorsService service = ServiceFactory.GetContractorsService())
      {
        //service.DeleteContractor(EditingViewModel.Item.);
      }
      Refresh();
    }

  }
}
