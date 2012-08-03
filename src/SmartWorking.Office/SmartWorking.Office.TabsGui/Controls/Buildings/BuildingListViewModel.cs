using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Buildings
{
  public class BuildingListViewModel : ListingEditableControlViewModel<BuildingPrimitive>
  {
    public BuildingListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<BuildingPrimitive> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return Resources.BuildingListViewModel_Name; }
    }

    protected override void  OnLoadItems()
    {
      BuildingPrimitive selectedItem = Items.SelectedItem;
      using (IBuildingsService service = ServiceFactory.GetBuildingsService())
      {
        Items.LoadItems(service.GetBuildings(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        BuildingPrimitive selectionFromItems =
          Items.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void OnAddItem()
    {
      base.OnAddItem();
      EditingViewModel.Item = new BuildingPrimitive();
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void OnAddCloneItem()
    {
      base.OnAddCloneItem();
      BuildingPrimitive clone = Items.SelectedItem.GetPrimitiveCopy();
      if (clone != null)
      {
        clone.Id = 0;        
      }
      else
      {
        clone = new BuildingPrimitive();
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
          using (IBuildingsService service = ServiceFactory.GetBuildingsService())
          {
            if (EditingViewModel.Item.IsDeleted)
            {
              service.UndeleteBuilding(EditingViewModel.Item);
            }
            else
            {
              service.DeleteBuilding(EditingViewModel.Item);
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
