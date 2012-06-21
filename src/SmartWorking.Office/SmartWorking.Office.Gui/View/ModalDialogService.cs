using System;
using System.Windows;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Cars;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Gui.View.DeliveryNotes;
using SmartWorking.Office.Gui.View.Drivers;
using SmartWorking.Office.Gui.View.Materials;
using SmartWorking.Office.Gui.View.Recipes;
using SmartWorking.Office.Gui.View.Shared;
using SmartWorking.Office.Gui.View.Shared.MessageBox;
using SmartWorking.Office.Gui.ViewModel;
using SmartWorking.Office.Gui.ViewModel.Cars;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Gui.ViewModel.DeliveryNotes;
using SmartWorking.Office.Gui.ViewModel.Drivers;
using SmartWorking.Office.Gui.ViewModel.Materials;
using SmartWorking.Office.Gui.ViewModel.Recipes;
using SmartWorking.Office.Gui.ViewModel.Shared.MessageBox;
using SmartWorking.Office.Services.Interfaces;
using MessageBox = SmartWorking.Office.Gui.View.Shared.MessageBox.MessageBox;
using UpdateCar = SmartWorking.Office.Gui.View.Cars.UpdateCar;

namespace SmartWorking.Office.Gui.View
{
  public class ModalDialogService : IModalDialogService
  {
    #region IModalDialogService Members

    public ContractorPrimitive CreateContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = new ContractorPrimitive();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateContractor>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Contractor;
      }
      return null;
    }

    public ContractorPrimitive EditContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                     ContractorPrimitive contractorToEdit)
    {
      var viewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = contractorToEdit;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateContractor>.ShowDialog(viewModel);
      return viewModel.Contractor;
    }

    public void ManageContractors(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageContractorsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageContractors>.ShowDialog(viewModel);
    }

    public BuildingPrimitive CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                   ContractorPrimitive contractor)
    {
      var viewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      //viewModel.Contractor = contractor;
      viewModel.Building = new BuildingPrimitive();
      viewModel.Building.Contractor_Id = contractor.Id;
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Building;
      }
      return null;
    }

    public BuildingPrimitive EditBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                 BuildingPrimitive building)
    {
      var viewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      //viewModel.Contractor = building.Contractor;
      viewModel.Building = building;      
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(viewModel);
      return viewModel.Building;
    }

    public BuildingPrimitive SelectBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageContractorsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.ChoseSubItem;
      ModalDialogHelper<ManageContractors>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        BuildingPrimitive result = viewModel.SelectedBuilding;
        return result;
      }
      return null;
    }

    public DeliveryNotePrimitive CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateDeliveryNoteViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Create;
      viewModel.DeliveryNote = new DeliveryNotePrimitive();
      ModalDialogHelper<UpdateDeliveryNote>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.DeliveryNote;
      }
      return null;
    }

    public DeliveryNotePrimitive CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory, BuildingPrimitive building)
    {
      var viewModel = new UpdateDeliveryNoteViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Create;
      viewModel.DeliveryNote = new DeliveryNotePrimitive();
      viewModel.Building = building;
      ModalDialogHelper<UpdateDeliveryNote>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.DeliveryNote;
      }
      return null;
    }

    public void ManageDeliveryNotes(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageDeliveryNotesViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageDeliveryNotes>.ShowDialog(viewModel);
    }

    public MaterialPrimitive CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      viewModel.Material = new MaterialPrimitive();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Material;
      }
      return null;
    }

    public MaterialPrimitive EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                 MaterialPrimitive selectedMaterial)
    {
      var viewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      viewModel.Material = selectedMaterial;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(viewModel);
      return viewModel.Material;
    }

    public void ManageMaterials(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageMaterialsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageMaterials>.ShowDialog(viewModel);
    }

    public MaterialPrimitive SelectMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageMaterialsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Chose;
      ModalDialogHelper<ManageMaterials>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectableMaterial.SelectedItem;
      }
      return null;
    }

    public RecipePrimitive CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.Recipe = new RecipePrimitive();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Recipe;
      }
      return null;
    }

    public RecipePrimitive EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                             RecipePrimitive selectedRecipe)
    {
      var viewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.Recipe = selectedRecipe;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(viewModel);
      return viewModel.Recipe;
    }

    public void ManageRecipes(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageRecipesViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageRecipes>.ShowDialog(viewModel);
    }

    public RecipePrimitive SelectRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageRecipesViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Chose;
      ModalDialogHelper<ManageRecipes>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectableRecipe.SelectedItem;
      }
      return null;
    }

    /// <summary>
    /// Opens dialog for creating the recipe component.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="recipe">The recipe for which the <see cref="RecipeComponent"/>s will be added.</param>
    /// <returns></returns>
    public RecipeComponentPrimitive CreateRecipeComponent(IModalDialogService modalDialogService, IServiceFactory serviceFactory, RecipePrimitive recipe)
    {      
      var viewModel = new UpdateRecipeComponentViewModel(modalDialogService, serviceFactory);
      viewModel.RecipeComponent = new RecipeComponentPrimitive();
      viewModel.RecipeComponent.Recipe_Id = recipe.Id;
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateRecipeComponent>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.RecipeComponent;
      }
      return null;
    }

    /// <summary>
    /// Opens dialog for editing the recipe component.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipeComponent">The selected recipe component.</param>
    /// <returns></returns>
    public RecipeComponentPrimitive EditRecipeComponent(IModalDialogService modalDialogService, IServiceFactory serviceFactory, RecipeComponentPrimitive selectedRecipeComponent)
    {
      var viewModel = new UpdateRecipeComponentViewModel(modalDialogService, serviceFactory);
      viewModel.RecipeComponent = selectedRecipeComponent;
      //viewModel.Material = selectedRecipeComponent.Material;//todo: check if not CopyWithOutReferences needed
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateRecipeComponent>.ShowDialog(viewModel);
      return viewModel.RecipeComponent;
    }

    public CarPrimitive CreateCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateCarViewModel(modalDialogService, serviceFactory);
      viewModel.Car = new CarPrimitive();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateCar>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Car;
      }
      return null;
    }

    public CarPrimitive EditCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory, CarPrimitive selectedCar)
    {
      var viewModel = new UpdateCarViewModel(modalDialogService, serviceFactory);
      viewModel.Car = selectedCar;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateCar>.ShowDialog(viewModel);
      return viewModel.Car;
    }

    public void ManageCars(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageCarsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageCars>.ShowDialog(viewModel);
    }

    public CarPrimitive SelectCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageCarsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Chose;
      ModalDialogHelper<ManageCars>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectableCar.SelectedItem;
      }
      return null;
    }

    public DriverPrimitive CreateDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateDriverViewModel(modalDialogService, serviceFactory);
      viewModel.Driver = new DriverPrimitive();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateDriver>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Driver;
      }
      return null;
    }

    public DriverPrimitive EditDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                             DriverPrimitive selectedDriver)
    {
       var viewModel = new UpdateDriverViewModel(modalDialogService, serviceFactory);
       viewModel.Driver = selectedDriver;
       viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateDriver>.ShowDialog(viewModel);
      return viewModel.Driver;
    }

    public void ManageDrivers(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageDriversViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageDrivers>.ShowDialog(viewModel);
    }

    public DriverPrimitive SelectDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageDriversViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Chose;
      ModalDialogHelper<ManageDrivers>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectableDriver.SelectedItem;
      }
      return null;
    }

    #endregion

    #region MessageBox
    /// <summary>
    /// Shows the message box.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="icon">The icon.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="message">The message.</param>
    /// <param name="button">The button.</param>
    /// <param name="info">The info.</param>
    /// <returns>Result depends button which was pressed.</returns>
    public MessageBoxResult ShowMessageBox(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
      MessageBoxImage icon, string caption, string message, MessageBoxButton button, string info)
    {
      var viewModel = new MessageBoxViewModel(modalDialogService, serviceFactory, icon, caption, message, button, info);
      return MessageBoxHelper<MessageBox>.ShowDialog(viewModel);
    }

    #endregion
  }
}