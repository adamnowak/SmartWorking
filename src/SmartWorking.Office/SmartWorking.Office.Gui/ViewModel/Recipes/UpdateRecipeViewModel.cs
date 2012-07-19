using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private ICommand _createRecipeComponentCommand;
    private ICommand _deleteRecipeComponentCommand;
    

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateRecipeViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateRecipeViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableMaterial = new SelectableViewModelBase<MaterialAndContractorsPackage>();
      LoadMaterials(new List<MaterialAndContractorsPackage>());
    }

    #region Recipe
    /// <summary>
    /// The <see cref="RecipePackage" /> property's name.
    /// </summary>
    public const string RecipePropertyName = "Recipe";

    private RecipePackage _recipePackage;

    /// <summary>
    /// Gets the Recipe property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public RecipePackage RecipePackage
    {
      get
      {
        return _recipePackage;
      }

      set
      {
        if (_recipePackage == value)
        {
          return;
        }
        _recipePackage = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(RecipePropertyName);
      }
    }
    #endregion //Recipe

    #region SelectedRecipeComponentAndMaterialPackage

    /// <summary>
    /// The <see cref="SelectedRecipeComponentAndMaterialPackage" /> property's name.
    /// </summary>
    public const string SelectedRecipeComponentPropertyName = "SelectedRecipeComponentAndMaterialPackage";

    private RecipeComponentAndMaterialPackage _selectedRecipeComponentAndMaterialPackage;

    public override void Initialize()
    {
      base.Initialize();
      Refresh();
    }

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

    #region EditRecipeComponentCommand
    private ICommand _editRecipeComponentCommand;
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
    /// Determines whether this instance [can edit recipeComponent].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance [can edit recipeComponent]; otherwise, <c>false</c>.
    /// </returns>
    private bool CanEditRecipeComponent()
    {
      return RecipePackage != null && RecipePackage.Recipe != null && SelectedRecipeComponentAndMaterialPackage != null;
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
        Refresh();
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

    /// <summary>
    /// Determines whether this recipeComponent (SelectableRecipeComponent.SelectedItem) can be deleted.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this recipeComponent doesn't belong to any delivery notes; otherwise, <c>false</c>.
    /// </returns>
    private bool CanDeleteRecipeComponent()
    {
      return RecipePackage != null && RecipePackage.Recipe != null && SelectedRecipeComponentAndMaterialPackage != null;
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
        Refresh();
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
      return RecipePackage != null && RecipePackage.Recipe != null && RecipePackage.RecipeComponentAndMaterialList != null;
    }

    /// <summary>
    /// Opens dialog to create new recipeComponent.
    /// </summary>
    private void CreateRecipeComponent()
    {
      RecipeComponentPrimitive recipeComponentPrimitive = ModalDialogService.CreateRecipeComponent(ModalDialogService,
                                                                                                   ServiceFactory,
                                                                                                   RecipePackage.Recipe,
                                                                                                   SelectableMaterial.
                                                                                                     SelectedItem);
      if (recipeComponentPrimitive != null)
      {
        RecipePackage.RecipeComponentAndMaterialList.Add(new RecipeComponentAndMaterialPackage()
                                                           {
                                                             MaterialAndContractors = SelectableMaterial.SelectedItem,
                                                             RecipeComponent = recipeComponentPrimitive
                                                           });
      }


      Refresh();
    }

    /// <summary>
    /// Gets the selectable material.
    /// </summary>
    public SelectableViewModelBase<MaterialAndContractorsPackage> SelectableMaterial { get; private set; }

    public override void Refresh()
    {
      LoadMaterials(RecipePackage.RecipeComponentAndMaterialList.Select(x => x.MaterialAndContractors).ToList());      
    }

    public class MaterialAndContractorsPackageComparer : IEqualityComparer<MaterialAndContractorsPackage>
    {
      #region IEqualityComparer Members

      public bool Equals(MaterialAndContractorsPackage x, MaterialAndContractorsPackage y)
      {
        return (x == null && y == null) || (x != null && y != null && x.Material.Id.Equals(y.Material.Id));
      }

      /// </exception>
      public int GetHashCode(MaterialAndContractorsPackage obj)
      {
        if (obj == null)
        {
          throw new ArgumentNullException("obj");
        }

        return obj.Material.Id;
      }

      #endregion
    }

    private void LoadMaterials(List<MaterialAndContractorsPackage> materialsInRecipe)
    {
      string errorCaption = "Pobieranie danych o materiałach!";
      try
      {
        MaterialAndContractorsPackage selectedItem = SelectableMaterial.SelectedItem;
        using (IMaterialsService materialsService = ServiceFactory.GetMaterialsService())
        {
          List<MaterialAndContractorsPackage> allMaterials = materialsService.GetMaterialAndContractorsPackageList(string.Empty, ListItemsFilterValues.All);
          List<MaterialAndContractorsPackage> toDisplay = allMaterials.Except(materialsInRecipe, new MaterialAndContractorsPackageComparer()).ToList();
          SelectableMaterial.LoadItems(toDisplay);
        }
        if (selectedItem != null && selectedItem.Material != null)
        {
          MaterialAndContractorsPackage selectionFromItems =
            SelectableMaterial.Items.Where(x => x.Material.Id == selectedItem.Material.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableMaterial.SelectedItem = selectionFromItems;
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
            RecipePackage.Recipe = recipesService.UpdateRecipe(RecipePackage.Recipe);
            RaisePropertyChanged("RecipePackage");
          }
        }
        //CloseModalDialog();
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