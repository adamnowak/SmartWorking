using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Recipes
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class RecipeComponentDetailsViewModel : EditableControlViewModelBase<RecipeComponentAndMaterialPackage>
  {
    public RecipeComponentDetailsViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.RecipeComponentDetailsViewModel_Name; }
    }

    

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    protected override void OnItemChanged(RecipeComponentAndMaterialPackage oldItem)
    {
      if (Item != null)
      {
        
      }

    }
  }
}