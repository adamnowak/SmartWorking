using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Materials
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class MaterialDetailsViewModel : EditableControlViewModelBase<MaterialAndContractorsPackage>
  {
    public MaterialDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      Contractors = new SelectableViewModelBase<ContractorPrimitive>();
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_CarDetails"; }
    }

    protected override void EditItemCommandExecute()
    {
      LoadContractors();
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSaveItem()
    {
      Item.Deliverer = Contractors.SelectedItem;
      if (base.OnSaveItem())
      {
        using (IMaterialsService service = ServiceFactory.GetMaterialsService())
        {
          service.UpdateMaterial(Item.GetMaterialPrimitiveWithReference());
        }
        return true;
      }
      return false;
    }

    public SelectableViewModelBase<ContractorPrimitive> Contractors { get; private set; }

    public override void Refresh()
    {
      LoadContractors();
      base.Refresh();
    }

    private void LoadContractors()
    {
      using (IContractorsService service = ServiceFactory.GetContractorsService())
      {
        Contractors.LoadItems(service.GetContractors(string.Empty));
      }
    }

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    //protected override void OnItemChanged(MaterialAndContractorsPackage oldItem)
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