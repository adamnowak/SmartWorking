using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Users
{
  public class RoleListViewModel : ListingEditableControlViewModel<RolePrimitive>
  {
    public RoleListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<RolePrimitive> editingViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogProvider, serviceFactory)
    {
    }

    public override string Name
    {
      get { return Resources.BuildingListViewModel_Name; }
    }

    protected override void  OnLoadItems()
    {
      RolePrimitive selectedItem = Items.SelectedItem;
      using (IUsersService service = ServiceFactory.GetUsersService())
      {
        Items.LoadItems(service.GetRoles(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        RolePrimitive selectionFromItems =
          Items.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void OnAddItem()
    {
      base.OnAddItem();
      EditingViewModel.Item = new RolePrimitive();
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void OnAddCloneItem()
    {
      base.OnAddCloneItem();
      RolePrimitive clone = Items.SelectedItem.GetPrimitiveCopy();
      if (clone != null)
      {
        clone.Id = 0;        
      }
      else
      {
        clone = new RolePrimitive();
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    //protected override bool OnItemDeletedFlagChanged()
    //{
    //  if (base.OnItemDeletedFlagChanged())
    //  {

    //    if (EditingViewModel.Item != null)
    //    {
    //      using (IBuildingsService service = ServiceFactory.GetBuildingsService())
    //      {
    //        if (EditingViewModel.Item.IsDeleted)
    //        {
    //          service.UndeleteBuilding(EditingViewModel.Item);
    //        }
    //        else
    //        {
    //          service.DeleteBuilding(EditingViewModel.Item);
    //        }
    //      }
    //    }
    //    Refresh();
    //    return true;
    //  }
    //  return false;
    //}
  }
}
