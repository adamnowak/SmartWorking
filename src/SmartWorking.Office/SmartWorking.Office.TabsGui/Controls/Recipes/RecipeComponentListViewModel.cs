using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Recipes
{
  public class RecipeComponentListViewModel : ListingEditableControlViewModel<RecipeComponentAndMaterialPackage>
  {
    public RecipeComponentListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<RecipeComponentAndMaterialPackage> editingViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogProvider, serviceFactory)
    {
    }

    public override string Name
    {
      get { return Resources.RecipeComponentListViewModel_Name; }
    }

     
    
  }
}
