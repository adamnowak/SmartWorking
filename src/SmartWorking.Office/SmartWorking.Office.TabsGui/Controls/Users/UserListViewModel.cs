using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Users
{
  public class UserListViewModel : ListingEditableControlViewModel<UserAndRolesPackage>
  {
    public UserListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<UserAndRolesPackage> editingViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogProvider, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "UserList"; }
    }

    protected override void OnLoadItems()
    {
      UserAndRolesPackage selectedItem = Items.SelectedItem;
      using (IUsersService service = ServiceFactory.GetUsersService())
      {
        Items.LoadItems(service.GetUserAndRolesPackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        UserAndRolesPackage selectionFromItems =
          Items.Items.Where(x => x.User.Id == selectedItem.User.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }



    protected override void OnAddItem()
    {
      base.OnAddItem();
      EditingViewModel.Item = new UserAndRolesPackage() { User = new UserPrimitive() };
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void OnAddCloneItem()
    {
      base.OnAddCloneItem();
      UserAndRolesPackage clone = Items.SelectedItem.GetPackageCopy();
      if (clone != null)
      {
        clone.User.Id = 0;
      }
      else
      {
        clone = new UserAndRolesPackage() { User = new UserPrimitive() };
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override bool OnItemDeletedFlagChanged()
    {
      if (base.OnItemDeletedFlagChanged())
      {

        if (EditingViewModel.Item != null)
        {
          //using (IBuildingsService service = ServiceFactory.GetBuildingsService())
          //{
          //  if (EditingViewModel.Item.IsDeleted)
          //  {
          //    service.UndeleteBuilding(EditingViewModel.Item);
          //  }
          //  else
          //  {
          //    service.DeleteBuilding(EditingViewModel.Item);
          //  }
          //}
        }
        Refresh();
        return true;
      }
      return false;
    }
  }
}
