using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  public class ClientListViewModel : ListingEditableControlViewModel<ClientAndBuildingsPackage>
  {
    public ClientListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<ClientAndBuildingsPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_ClientList"; }
    }

    protected override void  OnLoadItems()
    {
      ClientAndBuildingsPackage selectedItem = Items.SelectedItem;
      using (IClientsService service = ServiceFactory.GetClientsService())
      {
        Items.LoadItems(service.GetClientAndBuildingsPackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        ClientAndBuildingsPackage selectionFromItems =
          Items.Items.Where(x => x.Client.Id == selectedItem.Client.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new ClientAndBuildingsPackage() {Client = new ClientPrimitive()};
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      ClientAndBuildingsPackage clone = Items.SelectedItem;
      if (clone != null)
      {
        clone.Client.Id = 0;        
      }
      else
      {
        clone = new ClientAndBuildingsPackage() { Client = new ClientPrimitive() };
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }
  }
}
