using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Recipes
{
  public class ManageRecipesViewModel : ModalDialogViewModelBase
  {
    private ICommand _selectRecipeCommand;

    public ManageRecipesViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableRecipe = new SelectableViewModelBase<Recipe>();
      LoadRecipes();
    }

    public SelectableViewModelBase<Recipe> SelectableRecipe { get; private set; }

    public DialogMode DialogMode { get; set; }

    public ICommand SelectRecipeCommand
    {
      get
      {
        if (_selectRecipeCommand == null)
          _selectRecipeCommand = new RelayCommand(SelectRecipe);
        return _selectRecipeCommand;
      }
    }


    public override string Title
    {
      get { return "Wybierz receptę."; }
    }

    private void LoadRecipes()
    {
      using (IRecipesService recipesService = ServiceFactory.GetRecipesService())
      {
        SelectableRecipe.LoadItems(recipesService.GetRecipes(string.Empty));
      }
    }

    private void SelectRecipe()
    {
      CloseModalDialog();
    }
  }
}