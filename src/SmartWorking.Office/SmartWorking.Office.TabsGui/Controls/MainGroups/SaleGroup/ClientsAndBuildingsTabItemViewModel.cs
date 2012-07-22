using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class ClientsAndBuildingsTabItemViewModel : ControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ProducersAndMaterialsTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ClientsAndBuildingsTabItemViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      RecipeDetailsViewModel = new RecipeDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      RecipeListViewModel = new RecipeListViewModel(MainViewModel, RecipeDetailsViewModel, ModalDialogService, ServiceFactory);
      RecipeComponentDetailsViewModel = new RecipeComponentDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      RecipeComponentListViewModel = new RecipeComponentListViewModel(MainViewModel, RecipeComponentDetailsViewModel, ModalDialogService, ServiceFactory);
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
      get { return "str_ClientsAndBuildings"; }
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    public override void Refresh()
    {
      RecipeListViewModel.Refresh();
      RecipeDetailsViewModel.Refresh();
      RecipeComponentListViewModel.Refresh();
      RecipeComponentDetailsViewModel.Refresh();
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               RecipeListViewModel.IsReadOnly &&
               RecipeDetailsViewModel.IsReadOnly &&
               RecipeComponentListViewModel.IsReadOnly &&
               RecipeComponentDetailsViewModel.IsReadOnly;
      }
    }
  }
}