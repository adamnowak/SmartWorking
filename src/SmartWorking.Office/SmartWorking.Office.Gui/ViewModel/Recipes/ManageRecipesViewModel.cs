using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Recipes;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Recipes
{
  /// <summary>
  ///  View model for <see cref="ManageRecipes"/> dialog. 
  /// </summary>
  public class ManageRecipesViewModel : ModalDialogViewModelBase
  {
    private ICommand _choseRecipeCommand;
    private ICommand _createRecipeCommand;
    private ICommand _editRecipeCommand;
    private ICommand _deleteRecipeCommand;
    private ICommand _createRecipeComponentCommand;
    private ICommand _editRecipeComponentCommand;
    private ICommand _deleteRecipeComponentCommand;


    /// <summary>
    /// Initializes a new instance of the <see cref="ManageRecipesViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageRecipesViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableRecipe = new SelectableViewModelBase<Recipe>();
      LoadRecipes();
    }

    /// <summary>
    /// Gets the selectable recipe.
    /// </summary>
    public SelectableViewModelBase<Recipe> SelectableRecipe { get; private set; }

    #region SelectedRecipeComponent
    /// <summary>
    /// The <see cref="SelectedRecipeComponent" /> property's name.
    /// </summary>
    public const string SelectedRecipeComponentPropertyName = "SelectedRecipeComponent";

    private RecipeComponent _recipeComponent;
    

    /// <summary>
    /// Gets the SelectedRecipeComponent property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public RecipeComponent SelectedRecipeComponent
    {
      get
      {
        return _recipeComponent;
      }

      set
      {
        if (_recipeComponent == value)
        {
          return;
        }
        _recipeComponent = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(SelectedRecipeComponentPropertyName);
      }
    }
    #endregion
    
    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }




    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get { return "Wybierz receptę."; }
    }

    /// <summary>
    /// Loads the recipes.
    /// </summary>
    private void LoadRecipes()
    {
      using (IRecipesService recipesService = ServiceFactory.GetRecipesService())
      {
        SelectableRecipe.LoadItems(recipesService.GetRecipes(string.Empty));
      }
    }

    /// <summary>
    /// Gets the create recipe command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to creating recipe.
    /// </remarks>
    public ICommand CreateRecipeCommand
    {
      get
      {
        if (_createRecipeCommand == null)
          _createRecipeCommand = new RelayCommand(CreateRecipe);
        return _createRecipeCommand;
      }
    }

    /// <summary>
    /// Gets the edit recipe command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to editing recipe.
    /// </remarks>
    public ICommand EditRecipeCommand
    {
      get
      {
        if (_editRecipeCommand == null)
          _editRecipeCommand = new RelayCommand(EditRecipe, CanEditRecipe);
        return _editRecipeCommand;
      }
    }

    /// <summary>
    /// Gets the delete recipe command.
    /// </summary>
    public ICommand DeleteRecipeCommand
    {
      get
      {
        if (_deleteRecipeCommand == null)
          _deleteRecipeCommand = new RelayCommand(DeleteRecipe, CanDeleteRecipe);
        return _deleteRecipeCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance [can edit recipe].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance [can edit recipe]; otherwise, <c>false</c>.
    /// </returns>
    private bool CanEditRecipe()
    {
      return SelectableRecipe != null && SelectableRecipe.SelectedItem != null;
    }

    /// <summary>
    /// Edits the recipe.
    /// </summary>
    private void EditRecipe()
    {
      ModalDialogService.EditRecipe(ModalDialogService, ServiceFactory, SelectableRecipe.SelectedItem);
      LoadRecipes();
    }

    /// <summary>
    /// Determines whether this recipe (SelectableRecipe.SelectedItem) can be deleted.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this recipe doesn't belong to any delivery notes; otherwise, <c>false</c>.
    /// </returns>
    private bool CanDeleteRecipe()
    {
      if (SelectableRecipe != null && SelectableRecipe.SelectedItem != null)
      {
        //TODO: if recipe is not used in any DeliveryNots then true
      }
      return false;
    }

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    private void DeleteRecipe()
    {
      //TODO:
      LoadRecipes();
    }


    /// <summary>
    /// Opens dialog to create new recipe.
    /// </summary>
    private void CreateRecipe()
    {
      ModalDialogService.CreateRecipe(ModalDialogService, ServiceFactory);
      LoadRecipes();
    }

    #region ChoseRecipeCommand
    /// <summary>
    /// Gets the chose recipe command.
    /// </summary>
    /// <remarks>Opens dialog chose Recipe.</remarks>
    public ICommand ChoseRecipeCommand
    {
      get
      {
        if (_choseRecipeCommand == null)
          _choseRecipeCommand = new RelayCommand(ChoseRecipe, CanChoseRecipe);
        return _choseRecipeCommand;
      }
    }

    /// <summary>
    /// Determines whether <see cref="ChoseRecipeCommand"/> can be executed.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="ChoseRecipeCommand"/> can be executed; otherwise, <c>false</c>.
    /// </returns>
    private bool CanChoseRecipe()
    {
      return SelectableRecipe.SelectedItem != null;
    }

    /// <summary>
    /// Executes  <see cref="ChoseRecipeCommand"/>.
    /// </summary>
    /// <remarks>
    /// Closes modal dialog.
    /// </remarks>
    private void ChoseRecipe()
    {
      CloseModalDialog();
    }
    #endregion



    /// <summary>
    /// Gets the create recipeComponent command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to creating recipeComponent.
    /// </remarks>
    public ICommand CreateRecipeComponentCommand
    {
      get
      {
        if (_createRecipeComponentCommand == null)
          _createRecipeComponentCommand = new RelayCommand(CreateRecipeComponent, CanCreateRecipeComponent);
        return _createRecipeComponentCommand;
      }
    }

    

    /// <summary>
    /// Gets the edit recipeComponent command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to editing recipeComponent.
    /// </remarks>
    public ICommand EditRecipeComponentCommand
    {
      get
      {
        if (_editRecipeComponentCommand == null)
          _editRecipeComponentCommand = new RelayCommand(EditRecipeComponent, CanEditRecipeComponent);
        return _editRecipeComponentCommand;
      }
    }

    /// <summary>
    /// Gets the delete recipeComponent command.
    /// </summary>
    public ICommand DeleteRecipeComponentCommand
    {
      get
      {
        if (_deleteRecipeComponentCommand == null)
          _deleteRecipeComponentCommand = new RelayCommand(DeleteRecipeComponent, CanDeleteRecipeComponent);
        return _deleteRecipeComponentCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance [can edit recipeComponent].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance [can edit recipeComponent]; otherwise, <c>false</c>.
    /// </returns>
    private bool CanEditRecipeComponent()
    {
      return SelectableRecipe != null && SelectableRecipe.SelectedItem != null && SelectedRecipeComponent != null;
    }

    /// <summary>
    /// Edits the recipeComponent.
    /// </summary>
    private void EditRecipeComponent()
    {
      ModalDialogService.EditRecipeComponent(ModalDialogService, ServiceFactory, SelectedRecipeComponent);
      LoadRecipes();
    }

    /// <summary>
    /// Determines whether this recipeComponent (SelectableRecipeComponent.SelectedItem) can be deleted.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this recipeComponent doesn't belong to any delivery notes; otherwise, <c>false</c>.
    /// </returns>
    private bool CanDeleteRecipeComponent()
    {
      if (SelectableRecipe != null && SelectableRecipe.SelectedItem != null && SelectedRecipeComponent != null)
      {
        //TODO: if recipe is not used in any DeliveryNots then true
      }
      return false;
    }

    /// <summary>
    /// Deletes the recipeComponent.
    /// </summary>
    private void DeleteRecipeComponent()
    {
      //TODO:
      LoadRecipes();
    }

    /// <summary>
    /// Determines whether <see cref="CreateRecipeComponentCommand"/> can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if  <see cref="CreateRecipeComponentCommand"/> can be execute; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateRecipeComponent()
    {
      return SelectableRecipe != null && SelectableRecipe.SelectedItem != null;
    }

    /// <summary>
    /// Opens dialog to create new recipeComponent.
    /// </summary>
    private void CreateRecipeComponent()
    {
      ModalDialogService.CreateRecipeComponent(ModalDialogService, ServiceFactory, SelectableRecipe.SelectedItem);
      LoadRecipes();
    }
  }
}