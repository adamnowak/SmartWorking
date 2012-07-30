using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Materials
{
  public class MaterialListViewModel : ListingEditableControlViewModel<MaterialAndContractorsPackage>
  {
    public MaterialListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<MaterialAndContractorsPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return Resources.MaterialListViewModel_Name; }
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

    protected override bool OnItemDeletedFlagChanged()
    { 
      if (base.OnItemDeletedFlagChanged())
      {
        if (EditingViewModel.Item != null && EditingViewModel.Item.Material != null)
        {
          using (IMaterialsService service = ServiceFactory.GetMaterialsService())
          {
            if (EditingViewModel.Item.Material.IsDeleted)
            {
              service.UndeleteMaterial(EditingViewModel.Item.GetMaterialPrimitiveWithReference());
            }
            else
            {
              service.DeleteMaterial(EditingViewModel.Item.GetMaterialPrimitiveWithReference());
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
