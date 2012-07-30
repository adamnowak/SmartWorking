using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Recipes
{
  public class RecipeComponentListViewModel : ListingEditableControlViewModel<RecipeComponentAndMaterialPackage>
  {
    public RecipeComponentListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<RecipeComponentAndMaterialPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return Resources.RecipeComponentListViewModel_Name; }
    }

     
    
  }
}
