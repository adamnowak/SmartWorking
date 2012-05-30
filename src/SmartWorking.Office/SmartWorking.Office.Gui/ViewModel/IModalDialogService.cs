using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  public interface IModalDialogService
  {
    void CreateContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    void EditContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Contractor contractorToEdit);
    Contractor SelectContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    
    void CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Contractor contractor);
    void UpdateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Building building);    
    Building SelectBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Contractor selectContractor);
   
    void CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    void CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    Material SelectMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    void EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Material selectedMaterial);

    void CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    Recipe SelectRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    void EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Recipe selectedRecipe);
  }
}