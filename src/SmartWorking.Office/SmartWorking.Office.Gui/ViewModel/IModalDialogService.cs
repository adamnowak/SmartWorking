using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  public interface IModalDialogService
  {
    Contractor CreateContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    Contractor EditContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                        Contractor contractorToEdit);
    Contractor SelectContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    Building CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Contractor contractor);
    Building EditBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Building building);
    Building SelectBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                            Contractor selectContractor);

    DeliveryNote CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    Material CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    Material EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Material selectedMaterial);
    Material SelectMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    

    Recipe CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    Recipe EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Recipe selectedRecipe);
    Recipe SelectRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    
  }
}