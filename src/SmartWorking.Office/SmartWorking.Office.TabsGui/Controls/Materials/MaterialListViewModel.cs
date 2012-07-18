using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
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
      get { return "str_MaterialList"; }
    }

    protected override void  OnLoadItems()
    {
      MaterialAndContractorsPackage selectedItem = Items.SelectedItem;
      using (IMaterialsService service = ServiceFactory.GetMaterialsService())
      {
       // Items.LoadItems(service.GetMaterialAndContractorsPackageList(Filter, ShowDeleted));
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
      EditingViewModel.Item = new MaterialAndContractorsPackage();
      EditingViewModel.Item.Material= new MaterialPrimitive();
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
        clone = new MaterialAndContractorsPackage();
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    #region ShowDeactivated
    /// <summary>
    /// The <see cref="ShowDeactivated" /> property's name.
    /// </summary>
    public const string ShowDeactivatedPropertyName = "ShowDeactivated";

    private bool _showDeactivated;

    /// <summary>
    /// Gets the ShowDeactivated property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool ShowDeactivated
    {
      get
      {
        return _showDeactivated;
      }

      set
      {
        if (_showDeactivated == value)
        {
          return;
        }
        _showDeactivated = value;
        // Update bindings, no broadcast

        if (EditingViewModel.EditingMode == EditingMode.Display)
        {
          Refresh();
        }

        RaisePropertyChanged(ShowDeactivatedPropertyName);
      }
    }
    #endregion //ShowDeactivated
  }

  
}
