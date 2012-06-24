using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.Recipes;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Recipes
{
  /// <summary>
  /// View model for <see cref="ManageRecipes"/> dialog. 
  /// </summary>
  public class ManageRecipesViewModel : ModalDialogViewModelBase
  {
    private ICommand _choseRecipeCommand;
    private ICommand _createRecipeCommand;
    private ICommand _createRecipeComponentCommand;
    private ICommand _deleteRecipeCommand;
    private ICommand _deleteRecipeComponentCommand;
    private ICommand _editRecipeCommand;
    private ICommand _editRecipeComponentCommand;


    /// <summary>
    /// Initializes a new instance of the <see cref="ManageRecipesViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageRecipesViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableRecipe = new SelectableViewModelBase<RecipePackage>();
      LoadRecipePackages();
    }

    /// <summary>
    /// Gets the selectable recipe.
    /// </summary>
    public SelectableViewModelBase<RecipePackage> SelectableRecipe { get; private set; }

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

    #region SelectedRecipeComponentAndMaterialPackage

    /// <summary>
    /// The <see cref="SelectedRecipeComponentAndMaterialPackage" /> property's name.
    /// </summary>
    public const string SelectedRecipeComponentPropertyName = "SelectedRecipeComponentAndMaterialPackage";

    private RecipeComponentAndMaterialPackage _selectedRecipeComponentAndMaterialPackage;


    /// <summary>
    /// Gets the SelectedRecipeComponent property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public RecipeComponentAndMaterialPackage SelectedRecipeComponentAndMaterialPackage
    {
      get { return _selectedRecipeComponentAndMaterialPackage; }

      set
      {
        if (_selectedRecipeComponentAndMaterialPackage == value)
        {
          return;
        }
        _selectedRecipeComponentAndMaterialPackage = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(SelectedRecipeComponentPropertyName);
      }
    }

    #endregion

    /// <summary>
    /// Loads the recipes.
    /// </summary>
    private void LoadRecipePackages()
    {
      string errorCaption = "Pobieranie danych o receptach!";
      try
      {
        using (IRecipesService recipesService = ServiceFactory.GetRecipesService())
        {
          SelectableRecipe.LoadItems(recipesService.GetRecipesPackage(string.Empty));
        }
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
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
      string errorCaption = "Edycja recepty!";
      try
      {
        ModalDialogService.EditRecipe(ModalDialogService, ServiceFactory, SelectableRecipe.SelectedItem.Recipe);
        LoadRecipePackages();
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
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
      string errorCaption = "Usuwanie recepty!";
      try
      {
        //TODO:
        LoadRecipePackages();
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }


    /// <summary>
    /// Opens dialog to create new recipe.
    /// </summary>
    private void CreateRecipe()
    {
      string errorCaption = "Tworzenie recepty!";
      try
      {
        ModalDialogService.CreateRecipe(ModalDialogService, ServiceFactory);
        LoadRecipePackages();
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
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
      return SelectableRecipe != null && SelectableRecipe.SelectedItem != null &&
             SelectedRecipeComponentAndMaterialPackage != null;
    }

    /// <summary>
    /// Edits the recipeComponent.
    /// </summary>
    private void EditRecipeComponent()
    {
      string errorCaption = "Edycja recepty!";
      try
      {
        ModalDialogService.EditRecipeComponent(ModalDialogService, ServiceFactory,
                                               SelectedRecipeComponentAndMaterialPackage);
        LoadRecipePackages();
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }

    /// <summary>
    /// Determines whether this recipeComponent (SelectableRecipeComponent.SelectedItem) can be deleted.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this recipeComponent doesn't belong to any delivery notes; otherwise, <c>false</c>.
    /// </returns>
    private bool CanDeleteRecipeComponent()
    {
      if (SelectableRecipe != null && SelectableRecipe.SelectedItem != null &&
          SelectedRecipeComponentAndMaterialPackage != null)
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
      string errorCaption = "Usunięcie recepty!";
      try
      {
        //TODO:
        LoadRecipePackages();
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
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
      ModalDialogService.CreateRecipeComponent(ModalDialogService, ServiceFactory, SelectableRecipe.SelectedItem.Recipe);
      LoadRecipePackages();
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
      return SelectableRecipe.SelectedItem != null && DialogMode == DialogMode.Chose;
    }

    /// <summary>
    /// Executes  <see cref="ChoseRecipeCommand"/>.
    /// </summary>
    /// <remarks>
    /// Closes modal dialog.
    /// </remarks>
    private void ChoseRecipe()
    {
      string errorCaption = "Wybranie recepty!";
      try
      {
        CloseModalDialog();
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }

    #endregion
  }
}