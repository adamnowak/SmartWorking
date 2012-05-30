using System;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Gui.View.DeliveryNotes;
using SmartWorking.Office.Gui.View.Materials;
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

    public void CreateContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var updateContractorViewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      updateContractorViewModel.Contractor = new Contractor();
      updateContractorViewModel.ViewMode = ViewMode.Create;
      ModalDialogHelper<UpdateContractor>.ShowDialog(updateContractorViewModel);
    }

    public void EditContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Contractor contractorToEdit)
    {
      var updateContractorViewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      updateContractorViewModel.Contractor = contractorToEdit;
      updateContractorViewModel.ViewMode = ViewMode.Update;
      ModalDialogHelper<UpdateContractor>.ShowDialog(updateContractorViewModel);
    }

    public Contractor SelectContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var selectContractorViewModel = new SelectContractorViewModel(modalDialogService, serviceFactory);
      selectContractorViewModel.ViewMode = SelectContractorViewMode.SelectContractor;
      bool resultSelectContractor = ModalDialogHelper<SelectContractor>.ShowDialog(selectContractorViewModel);
      if (resultSelectContractor)
        return selectContractorViewModel.SelectableContractor.SelectedItem;
      return null;
    }

    public void CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Contractor contractor)
    {
      var updateBuildingViewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      updateBuildingViewModel.Contractor = contractor;
      updateBuildingViewModel.Building = new Building();
      updateBuildingViewModel.ViewMode = ViewMode.Create;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(updateBuildingViewModel);
    }

    public void UpdateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Building building)
    {
      var updateBuildingViewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      updateBuildingViewModel.Contractor = building.Contractor;
      updateBuildingViewModel.Building = building;
      updateBuildingViewModel.ViewMode = ViewMode.Update;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(updateBuildingViewModel);
    }

    

    public Building SelectBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Contractor selectContractor)
    {
      var updateContractorViewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      updateContractorViewModel.Contractor = selectContractor;
      updateContractorViewModel.ViewMode = ViewMode.Selecte;
      ModalDialogHelper<UpdateContractor>.ShowDialog(updateContractorViewModel);
      return updateContractorViewModel.SelectedBuilding;
    }

    public void CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var updateDeliveryNoteViewModel = new UpdateDeliveryNoteViewModel(modalDialogService, serviceFactory);
      updateDeliveryNoteViewModel.ViewMode = ViewMode.Create;
      ModalDialogHelper<UpdateDeliveryNote>.ShowDialog(updateDeliveryNoteViewModel);
    }

    public void CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var updateMaterialViewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      updateMaterialViewModel.Material = new Material();
      updateMaterialViewModel.ViewMode = ViewMode.Create;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(updateMaterialViewModel);
    }

    public Material SelectMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var selectMaterialViewModel = new SelectMaterialViewModel(modalDialogService, serviceFactory);
      selectMaterialViewModel.ViewMode = SelectMaterialViewMode.SelectMaterial;
      bool resultSelectMaterial = ModalDialogHelper<SelectMaterial>.ShowDialog(selectMaterialViewModel);
      if (resultSelectMaterial)
        return selectMaterialViewModel.SelectableMaterial.SelectedItem;
      return null;
      
    }

    public void EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Material selectedMaterial)
    {
      var updateMaterialViewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      updateMaterialViewModel.Material = selectedMaterial;
      updateMaterialViewModel.ViewMode = ViewMode.Update;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(updateMaterialViewModel);
    }

    public void CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var updateRecipeViewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      updateRecipeViewModel.Recipe = new Recipe();
      updateRecipeViewModel.ViewMode = ViewMode.Create;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(updateRecipeViewModel);
    }

    public Recipe SelectRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var selectRecipeViewModel = new SelectRecipeViewModel(modalDialogService, serviceFactory);
      selectRecipeViewModel.ViewMode = SelectRecipeViewMode.SelectRecipe;
      bool resultSelectMaterial = ModalDialogHelper<SelectRecipe>.ShowDialog(selectRecipeViewModel);
      if (resultSelectMaterial)
        return selectRecipeViewModel.SelectableRecipe.SelectedItem;
      return null;
    }

    public void EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Recipe selectedRecipe)
    {
      var updateRecipeViewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      updateRecipeViewModel.Recipe = selectedRecipe;
      updateRecipeViewModel.ViewMode = ViewMode.Create;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(updateRecipeViewModel);
    }

    #endregion
  }
}