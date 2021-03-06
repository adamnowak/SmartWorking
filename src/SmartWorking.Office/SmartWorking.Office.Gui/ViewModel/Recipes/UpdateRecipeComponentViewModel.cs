﻿using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Recipes
{
  /// <summary>
  /// View model for <see cref="CreateOrUpdateRecipeComponent"/> dialog. 
  /// </summary>
  public class UpdateRecipeComponentViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateRecipeComponentCommand;
    private ICommand _selectMaterialCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateRecipeComponentViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateRecipeComponentViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
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
    /// Gets the create or update material command.
    /// </summary>
    /// <remarks>
    /// Opens dialog for creating or editing MaterialAndContractors.
    /// </remarks>
    public ICommand CreateOrUpdateRecipeComponentCommand
    {
      get
      {
        if (_createOrUpdateRecipeComponentCommand == null)
          _createOrUpdateRecipeComponentCommand = new RelayCommand(CreateOrUpdateRecipeComponent,
                                                                   CanCreateOrUpdateRecipeComponent);
        return _createOrUpdateRecipeComponentCommand;
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
                 ? "Utwórz nowy element recepty."
                 : "Edytuj element recepty.";
      }
    }

    #region RecipeComponent

    /// <summary>
    /// The <see cref="RecipeComponent" /> property's name.
    /// </summary>
    public const string RecipeComponentPropertyName = "RecipeComponent";

    private RecipeComponentPrimitive _recipeComponent;

    /// <summary>
    /// Gets the RecipeComponent property.
    /// RecipeComponent which will be created or updated.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public RecipeComponentPrimitive RecipeComponent
    {
      get { return _recipeComponent; }

      set
      {
        if (_recipeComponent == value)
        {
          return;
        }
        _recipeComponent = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(RecipeComponentPropertyName);
      }
    }

    #endregion

    #region MaterialAndContractors

    /// <summary>
    /// The <see cref="MaterialAndContractorsPackage" /> property's name.
    /// </summary>
    public const string MaterialAndContractorsPropertyName = "MaterialAndContractors";

    private MaterialAndContractorsPackage _materialAndContractors;

    /// <summary>
    /// Gets the MaterialAndContractors property.
    /// MaterialAndContractors which will be created or updated.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public MaterialAndContractorsPackage MaterialAndContractors
    {
      get { return _materialAndContractors; }

      set
      {
        if (_materialAndContractors == value)
        {
          return;
        }
        _materialAndContractors = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(MaterialAndContractorsPropertyName);
      }
    }

    #endregion

    /// <summary>
    /// Determines whether <see cref="CreateOrUpdateRecipeComponentCommand"/> can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="CreateOrUpdateRecipeComponentCommand"/> can be execute; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateOrUpdateRecipeComponent()
    {
      //TODO: validate
      return true;
    }


    /// <summary>
    /// Creates or updates the material in the system.
    /// </summary>
    private void CreateOrUpdateRecipeComponent()
    {
      string errorCaption = "Zatwierdzenie zmian w danych recepty!";
      try
      {
        if (RecipeComponent != null && MaterialAndContractors != null && MaterialAndContractors.Material != null)
          RecipeComponent.Material_Id = MaterialAndContractors.Material.Id;
        if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
        {
          using (IRecipesService service = ServiceFactory.GetRecipesService())
          {
            //service.UpdateRecipeComponent(RecipeComponent);
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

    #region SelectMaterialCommand

    /// <summary>
    /// Gets the select material command.
    /// </summary>
    public ICommand SelectMaterialCommand
    {
      get
      {
        if (_selectMaterialCommand == null)
          _selectMaterialCommand = new RelayCommand(SelectMaterial, CanSelectMaterial);
        return _selectMaterialCommand;
      }
    }

    /// <summary>
    /// Determines whether <see cref="SelectMaterialCommand"/> can be executed.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="SelectMaterialCommand"/> can be executed; otherwise, <c>false</c>.
    /// </returns>
    private bool CanSelectMaterial()
    {
      return RecipeComponent != null;
    }

    /// <summary>
    /// Executes the <see cref="SelectMaterialCommand"/>.
    /// </summary>
    private void SelectMaterial()
    {
      string errorCaption = "Wybranie materiału!";
      try
      {
        MaterialAndContractors = ModalDialogService.SelectMaterial(ModalDialogService, ServiceFactory);
        RaisePropertyChanged(MaterialAndContractorsPropertyName);
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