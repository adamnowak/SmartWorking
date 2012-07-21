using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Materials;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class ClientDetailsViewModel : EditableControlViewModelBase<RecipePackage>
  {
    public ClientDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      MaterialListToAddViewModel = new MaterialListViewModel(MainViewModel, null, ModalDialogService, ServiceFactory);
      BuildingDetailsViewModel = new BuildingDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      BuildingListViewModel = new BuildingListViewModel(MainViewModel, BuildingDetailsViewModel, ModalDialogService, ServiceFactory);
    }

    public BuildingListViewModel BuildingListViewModel { get; private set; }
    public BuildingDetailsViewModel BuildingDetailsViewModel { get; private set; }
    public MaterialListViewModel MaterialListToAddViewModel { get; private set; }
    private List<MaterialAndContractorsPackage> AllMaterials { get; set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_ClientDetails"; }
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
        //using (IContractorsService service = ServiceFactory.GetContractorsService())
        //{
        //  service.CreateOrUpdateContractor(Item);
        //}
        return true;
      }
      return false;
    }

    

    public override void Refresh()
    {
      base.Refresh();
      LoadAllMaterials();
      if (Item != null && AllMaterials != null)
      {
        MaterialListToAddViewModel.Items.LoadItems(
          AllMaterials.Where(
            x =>
            !Item.RecipeComponentAndMaterialList.Select(y => y.MaterialAndContractors.Material.Id).Contains(x.Material.Id)));
      }
    }

    private void LoadAllMaterials()
    {
      using (IMaterialsService service = ServiceFactory.GetMaterialsService())
      {
        AllMaterials = service.GetMaterialAndContractorsPackageList(MaterialListToAddViewModel.Filter, MaterialListToAddViewModel.ListItemsFilter);
      }
    }


    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    //protected override void OnItemChanged(CarAndDriverPackage oldItem)
    //{
    //  if (Contractors.Items != null && Item != null && Item.Deliverer != null)
    //  {
    //    Contractors.SelectedItem = Contractors.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
    //    Item.Deliverer = Contractors.SelectedItem;
    //  }
    //  else
    //  {
    //    Contractors.SelectedItem = null;
    //  }

    //}
  }
}