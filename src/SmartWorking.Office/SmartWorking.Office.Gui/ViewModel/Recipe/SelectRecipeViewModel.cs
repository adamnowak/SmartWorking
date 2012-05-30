using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Materials
{
  public enum SelectRecipeViewMode
  {
    SelectRecipe,
    SelectMaterial
  }

  public class SelectRecipeViewModel : ModalDialogViewModelBase
  {
    private ICommand _selectRecipeCommand;

    public SelectRecipeViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableRecipe = new SelectableViewModelBase<Recipe>();
      LoadRecipes();
    }

    public SelectableViewModelBase<Recipe> SelectableRecipe { get; private set; }

    public SelectRecipeViewMode ViewMode { get; set; }

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
        SelectableRecipe.LoadItems(recipesService.GetRecipes());
      }
    }

    private void SelectRecipe()
    {
      CloaseModalDialog();
    }
  }
}