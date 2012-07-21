using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Recipes
{
  public class RecipeComponentListViewModel : ListingEditableControlViewModel<ContractorPrimitive>
  {
    public RecipeComponentListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<ContractorPrimitive> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_ContractorList"; }
    }

    protected override void  OnLoadItems()
    {
      ContractorPrimitive selectedItem = Items.SelectedItem;
      using (IContractorsService service = ServiceFactory.GetContractorsService())
      {
        //Items.LoadItems(service.GetContractors(Filter, ShowDeleted));
      }
      if (selectedItem != null)
      {
        ContractorPrimitive selectionFromItems =
          Items.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new ContractorPrimitive();
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      ContractorPrimitive clone = Items.SelectedItem;
      if (clone != null)
      {
        clone.Id = 0;        
      }
      else
      {
        clone = new ContractorPrimitive();
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }
  }
}
