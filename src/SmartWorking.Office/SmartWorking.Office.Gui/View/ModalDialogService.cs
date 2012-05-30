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

    public Contractor CreateContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = new Contractor();
      viewModel.ViewMode = ViewMode.Create;
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
      viewModel.ViewMode = ViewMode.Update;
      ModalDialogHelper<UpdateContractor>.ShowDialog(viewModel);
      return viewModel.Contractor;
    }

    public Contractor SelectContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new SelectContractorViewModel(modalDialogService, serviceFactory);
      viewModel.ViewMode = SelectContractorViewMode.SelectContractor;
      ModalDialogHelper<SelectContractor>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectableContractor.SelectedItem;
      }
      return null;
    }

    public Building CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                               Contractor contractor)
    {
      var viewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = contractor;
      viewModel.Building = new Building();
      viewModel.ViewMode = ViewMode.Create;
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
      viewModel.ViewMode = ViewMode.Update;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(viewModel);
      return viewModel.Building;
    }


    public Building SelectBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                   Contractor selectContractor)
    {
      var viewModel = new UpdateContractorViewModel(modalDialogService, serviceFactory);
      viewModel.Contractor = selectContractor;
      viewModel.ViewMode = ViewMode.Selecte;
      ModalDialogHelper<UpdateContractor>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectedBuilding;
      }
      return null;
    }

    public DeliveryNote CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateDeliveryNoteViewModel(modalDialogService, serviceFactory);
      viewModel.ViewMode = ViewMode.Create;
      viewModel.DeliveryNote = new DeliveryNote();
      ModalDialogHelper<UpdateDeliveryNote>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.DeliveryNote;
      }
      return null; 
    }

    public Material CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      viewModel.Material = new Material();
      viewModel.ViewMode = ViewMode.Create;
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
      viewModel.ViewMode = ViewMode.Update;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(viewModel);
      return viewModel.Material;
    }

    public Material SelectMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new SelectMaterialViewModel(modalDialogService, serviceFactory);
      viewModel.ViewMode = SelectMaterialViewMode.SelectMaterial;
      ModalDialogHelper<SelectMaterial>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectableMaterial.SelectedItem;
      }
      return null;
    }

    public Recipe CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.Recipe = new Recipe();
      viewModel.ViewMode = ViewMode.Create;
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
      viewModel.ViewMode = ViewMode.Create;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(viewModel);
      return viewModel.Recipe;
    }

    public Recipe SelectRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new SelectRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.ViewMode = SelectRecipeViewMode.SelectRecipe;
      ModalDialogHelper<SelectRecipe>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectableRecipe.SelectedItem;
      }
      return null;
    }

    

    #endregion
  }
}