using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  public class ClientListViewModel : ListingEditableControlViewModel<ClientAndClientBuildingsPackage>
  {
    public ClientListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<ClientAndClientBuildingsPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return Resources.ClientListViewModel_Name; }
    }

    protected override void  OnLoadItems()
    {
      ClientAndClientBuildingsPackage selectedItem = Items.SelectedItem;
      using (IClientsService service = ServiceFactory.GetClientsService())
      {
        Items.LoadItems(service.GetClientAndBuildingsPackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        ClientAndClientBuildingsPackage selectionFromItems =
          Items.Items.Where(x => x.Client.Id == selectedItem.Client.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void OnAddItem()
    {
      base.OnAddItem();
      EditingViewModel.Item = new ClientAndClientBuildingsPackage() {Client = new ClientPrimitive()};
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void OnAddCloneItem()
    {
      base.OnAddCloneItem();
      ClientAndClientBuildingsPackage clone = Items.SelectedItem.GetPackageCopy();
      if (clone != null)
      {
        clone.Client.Id = 0;        
      }
      else
      {
        clone = new ClientAndClientBuildingsPackage() { Client = new ClientPrimitive() };
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override bool OnItemDeletedFlagChanged()
    {
      if (base.OnItemDeletedFlagChanged())
      {
        if (EditingViewModel.Item != null && EditingViewModel.Item.Client != null)
        {
          using (IClientsService service = ServiceFactory.GetClientsService())
          {
            if (EditingViewModel.Item.Client.IsDeleted)
            {
              service.UndeleteClient(EditingViewModel.Item.Client);
            }
            else
            {
              service.DeleteClient(EditingViewModel.Item.Client);
            }
          }
        }
        Refresh();
        return true;
      }
      return false;
    }
  }
}
