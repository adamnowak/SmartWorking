using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Recipes
{
  /// <summary>
  ///  View model for <see cref="CreateOrUpdateRecipe"/> dialog. 
  /// </summary>
  public class UpdateRecipeViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateRecipeCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateRecipeViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateRecipeViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the create recipe command.
    /// </summary>
    public ICommand CreateOrUpdateRecipeCommand
    {
      get
      {
        if (_createOrUpdateRecipeCommand == null)
          _createOrUpdateRecipeCommand = new RelayCommand(CreateOrUpdateRecipe, CanCreateOrUpdateRecipe);
        return _createOrUpdateRecipeCommand;
      }
    }

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nową receptę."
                 : "Edytuj receptę.";
      }
    }

    #region Recipe property

    /// <summary>
    /// The <see cref="Contractor" /> property's name.
    /// </summary>
    public const string RecipePropertyName = "Recipe";

    private RecipePrimitive _recipe;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public RecipePrimitive Recipe
    {
      get { return _recipe; }

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

    /// <summary>
    /// Determines whether this instance [can create recipe].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance [can create recipe]; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateOrUpdateRecipe()
    {
      //TODO: validate
      return true;
    }


    /// <summary>
    /// Updates the recipe.
    /// </summary>
    private void CreateOrUpdateRecipe()
    {
      string errorCaption = "Zatwierdzenie danych o recepcie!";
      try
      {
        if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
        {
          using (IRecipesService recipesService = ServiceFactory.GetRecipesService())
          {
            recipesService.UpdateRecipe(Recipe);
          }
        }
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
  }
}