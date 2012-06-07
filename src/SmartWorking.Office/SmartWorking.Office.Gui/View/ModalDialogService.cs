using System;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Gui.View.DeliveryNotes;

using SmartWorking.Office.Gui.View.Recipes;
using SmartWorking.Office.Gui.ViewModel;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Gui.ViewModel.Materials;
using SmartWorking.Office.Services.Interfaces;


namespace SmartWorking.Office.Gui.View
{
  public class ModalDialogService : IModalDialogService
  {
    #region IModalDialogService Members

    public Contractor CreateContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = new Contractor();
      viewModel.ViewMode = DialogMode.Create;
      ModalDialogHelper<UpdateContractor>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Contractor;
      }
      return null;      
    }

    public Contractor EditContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                               Contractor contractorToEdit)
    {
      var viewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = contractorToEdit;
      viewModel.ViewMode = DialogMode.Update;
      ModalDialogHelper<UpdateContractor>.ShowDialog(viewModel);
      return viewModel.Contractor;
    }

    public void ManageContractors(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageContractorsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Selecting;;
      ModalDialogHelper<ManageContractors>.ShowDialog(viewModel);      
    }

    public Building CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                               Contractor contractor)
    {
      var viewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = contractor;
      viewModel.Building = new Building();
      viewModel.ViewMode = DialogMode.Create;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Building;
      }
      return null; 
    }

    public Building EditBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Building building)
    {
      var viewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = building.Contractor;
      viewModel.Building = building;
      viewModel.ViewMode = DialogMode.Update;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(viewModel);
      return viewModel.Building;
    }

    public DeliveryNote CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateDeliveryNoteViewModel(modalDialogService, serviceFactory);
      viewModel.ViewMode = DialogMode.Create;
      viewModel.DeliveryNote = new DeliveryNote();
      ModalDialogHelper<UpdateDeliveryNote>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.DeliveryNote;
      }
      return null; 
    }

    public void ManageDeliveryNotes(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      //var viewModel = new ManageDeliveryNotesViewModel(modalDialogService, serviceFactory);
      //viewModel.DialogMode = DialogMode.Selecting; ;
      //ModalDialogHelper<ManageDeliveryNotes>.ShowDialog(viewModel);  
    }

    public Material CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      viewModel.Material = new Material();
      viewModel.ViewMode = DialogMode.Create;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Material;
      }
      return null;
    }

    public Material EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                             Material selectedMaterial)
    {
      var viewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      viewModel.Material = selectedMaterial;
      viewModel.ViewMode = DialogMode.Update;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(viewModel);
      return viewModel.Material;
    }

    public void ManageMaterials(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageMaterialsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Selecting;
      ModalDialogHelper<ManageDeliveryNotes>.ShowDialog(viewModel);
    }

    public Recipe CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.Recipe = new Recipe();
      viewModel.ViewMode = DialogMode.Create;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Recipe;
      }
      return null;
    }

    public Recipe EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Recipe selectedRecipe)
    {
      var viewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.Recipe = selectedRecipe;
      viewModel.ViewMode = DialogMode.Create;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(viewModel);
      return viewModel.Recipe;
    }

    public void ManageRecipes(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new SelectRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Selecting;
      ModalDialogHelper<ManageRecipes>.ShowDialog(viewModel);
    }

    

    #endregion
  }
}