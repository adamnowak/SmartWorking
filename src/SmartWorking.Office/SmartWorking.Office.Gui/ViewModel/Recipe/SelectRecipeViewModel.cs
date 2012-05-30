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
    public SelectableViewModelBase<Recipe> SelectableRecipe { get; private set; }

    public SelectRecipeViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableRecipe = new SelectableViewModelBase<Recipe>();
      LoadRecipes();
    }

    public SelectRecipeViewMode ViewMode { get; set; }

    private void LoadRecipes()
    {
      using (var recipesService = ServiceFactory.GetRecipesService())
      {
        SelectableRecipe.LoadItems(recipesService.GetRecipes());
      }
    }

    private ICommand _selectRecipeCommand;

    public ICommand SelectRecipeCommand
    {
      get
      {
        if (_selectRecipeCommand == null)
          _selectRecipeCommand = new RelayCommand(SelectRecipe);
        return _selectRecipeCommand;
      }
    }

    private void SelectRecipe()
    {
      CloaseModalDialog();
    }

    


    public override string Title
    {
      get { return "Wybierz receptę."; }
    }


  }
}