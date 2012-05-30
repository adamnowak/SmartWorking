using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
 
  public class UpdateRecipeViewModel : ModalDialogViewModelBase
  {
    public UpdateRecipeViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    public ViewMode ViewMode { get; set; }

    #region Recipe property
    /// <summary>
    /// The <see cref="Contractor" /> property's name.
    /// </summary>
    public const string RecipePropertyName = "Recipe";

    private Recipe _recipe;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Recipe Recipe
    {
      get
      {
        return _recipe;
      }

      set
      {
        if (_recipe == value)
        {
          return;
        }
        _recipe = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(RecipePropertyName);
      }
    }
    #endregion


    private ICommand _createRecipeCommand;

    public ICommand CreateRecipeCommand
    {
      get
      {
        if (_createRecipeCommand == null)
          _createRecipeCommand = new RelayCommand(UpdateRecipe, CanCreateRecipe);
        return _createRecipeCommand;
      }
    }

    private bool CanCreateRecipe()
    {
      //TODO: validate
      return true;
    }


    private void UpdateRecipe()
    {
      if (ViewMode == ViewMode.Create || ViewMode == ViewMode.Update)
      {
        using (var recipesService = ServiceFactory.GetRecipesService())
        {
          recipesService.UpdateRecipe(Recipe);
        }
      }
      CloaseModalDialog();
    }

    public override string Title
    {
      get
      {
        return (ViewMode == ViewModel.ViewMode.Create)
                 ? "Utwórz nową receptę."
                 : "Edytuj receptę.";
      }
    }
  }
}