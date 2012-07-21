using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class BuildingDetailsViewModel : EditableControlViewModelBase<ContractorPrimitive>
  {
    public BuildingDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      Contractors = new SelectableViewModelBase<ContractorPrimitive>();
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_BuildingDetails"; }
    }

    protected override void EditItemCommandExecute()
    {
      LoadContractors();
      Item = Item.GetPrimitiveCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSaveItem()
    {
      if (base.OnSaveItem())
      {
        using (IContractorsService service = ServiceFactory.GetContractorsService())
        {
          service.CreateOrUpdateContractor(Item);
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
        Contractors.LoadItems(service.GetContractors(string.Empty, ListItemsFilterValues.OnlyActive));
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