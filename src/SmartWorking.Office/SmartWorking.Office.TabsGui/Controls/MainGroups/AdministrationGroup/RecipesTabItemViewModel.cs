using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Contractors;
using SmartWorking.Office.TabsGui.Controls.Materials;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class RecipesTabItemViewModel : TabItemViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ProducersAndMaterialsTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public RecipesTabItemViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      RecipeDetailsViewModel = new RecipeDetailsViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      RecipeListViewModel = new RecipeListViewModel(MainViewModel, RecipeDetailsViewModel, ModalDialogProvider, ServiceFactory);
      RecipeComponentDetailsViewModel = new RecipeComponentDetailsViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      RecipeComponentListViewModel = new RecipeComponentListViewModel(MainViewModel, RecipeComponentDetailsViewModel, ModalDialogProvider, ServiceFactory);
    }

    /// <summary>
    /// Gets the car list view model.
    /// </summary>
    public RecipeListViewModel RecipeListViewModel { get; private set; }

    /// <summary>
    /// Gets the car details view model.
    /// </summary>
    public RecipeDetailsViewModel RecipeDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the recipe component details view model.
    /// </summary>
    public RecipeComponentDetailsViewModel RecipeComponentDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the recipe component list view model.
    /// </summary>
    public RecipeComponentListViewModel RecipeComponentListViewModel { get; private set; }



    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.RecipesTabItemViewModel_Name; }
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    protected override bool OnRefresh()
    {
      RecipeListViewModel.Refresh();
      RecipeDetailsViewModel.Refresh();
      RecipeComponentListViewModel.Refresh();
      RecipeComponentDetailsViewModel.Refresh();
      return true;
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               (RecipeListViewModel != null ? RecipeListViewModel.IsReadOnly : true) &&
               (RecipeDetailsViewModel != null ? RecipeDetailsViewModel.IsReadOnly : true) &&
               (RecipeComponentListViewModel != null ? RecipeComponentListViewModel.IsReadOnly : true) &&
               (RecipeComponentDetailsViewModel != null ? RecipeComponentDetailsViewModel.IsReadOnly : true);
      }
    }
  }
}