using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.DeliveryNotes
{
  public class DeliveryNoteListViewModel : ListingEditableControlViewModel<MaterialAndContractorsPackage>
  {
    public DeliveryNoteListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<MaterialAndContractorsPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_MaterialList"; }
    }

    protected override void  OnLoadItems()
    {
      MaterialAndContractorsPackage selectedItem = Items.SelectedItem;
      using (IMaterialsService service = ServiceFactory.GetMaterialsService())
      {
        Items.LoadItems(service.GetMaterialAndContractorsPackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        MaterialAndContractorsPackage selectionFromItems =
          Items.Items.Where(x => x.Material.Id == selectedItem.Material.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new MaterialAndContractorsPackage() { Material = new MaterialPrimitive() };      
      EditingViewModel.EditingMode = EditingMode.New;
      EditingMode = EditingMode.Display;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      MaterialAndContractorsPackage clone = Items.SelectedItem.GetPackageCopy();
      if (clone != null)
      {
        clone.Material.Id = 0;        
      }
      else
      {
        clone = new MaterialAndContractorsPackage() { Material = new MaterialPrimitive() };
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void DeleteItemCommandExecute()
    {
      base.DeleteItemCommandExecute();
      using (IMaterialsService service = ServiceFactory.GetMaterialsService())
      {
        service.DeleteMaterial(EditingViewModel.Item.GetMaterialPrimitiveWithReference());
      }
      Refresh();
    }
  }

  
}
