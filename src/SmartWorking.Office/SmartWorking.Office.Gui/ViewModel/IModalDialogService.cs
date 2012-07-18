using System.Windows;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Provides functionality of opening modal dialogs.
  /// </summary>
  public interface IModalDialogService
  {
    #region Order
    OrderPackage CreateOrder(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    void ManageOrders(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    #endregion

    #region Client
    ClientPrimitive CreateClient(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    ClientPrimitive EditClient(IModalDialogService modalDialogService, IServiceFactory serviceFactory, ClientPrimitive client);
    void ManageClients(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    #endregion

    #region Contractor

    /// <summary>
    /// Opens dialog for creating the contractor.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns>Contractor which will be created. If user cancel creating operation then <c>null</c>.</returns>
    ContractorPrimitive CreateContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the contractor.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="contractorToEdit">The contractor to edit.</param>
    /// <returns></returns>
    ContractorPrimitive EditContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                       ContractorPrimitive contractorToEdit);

    /// <summary>
    /// Opens dialog for managing the contractors.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageContractors(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for selecting <see cref="Contractor"/>.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>    
    /// <returns>Selected Contractor.</returns>
    ContractorPrimitive SelectContractor(IModalDialogService modalDialogService,
                                                                    IServiceFactory serviceFactory);

    #endregion

    #region Building

    /// <summary>
    /// Opens dialog for creating the building.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="contractor">The contractor.</param>
    /// <returns>Created Building.</returns>
    BuildingAndClientPackage CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                     ClientPrimitive contractor);

    /// <summary>
    /// Opens dialog for editing building.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="building">The building.</param>
    /// <returns>Edited Building.</returns>
    BuildingAndClientPackage EditBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                   BuildingAndClientPackage buildingAndClientPackage);

    /// <summary>
    /// Opens dialog for managing Contractor and user can chose Building.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>    
    /// <returns>Selected Building.</returns>
    BuildingAndClientPackage SelectBuildingAndContractorPackage(IModalDialogService modalDialogService,
                                                                    IServiceFactory serviceFactory);

    #endregion

    #region DeliveryNotePackage

    /// <summary>
    /// Opens dialog for creating delivery note.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    DeliveryNotePackage CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for creating delivery note for <paramref name="building"/>.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="buildingAndContractorPackage">The building and contractor package.</param>
    /// <returns></returns>
    DeliveryNotePackage CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                           BuildingAndClientPackage buildingAndContractorPackage);

    /// <summary>
    /// Opens dialog for managing the delivery notes.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageDeliveryNotes(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    #endregion

    #region MaterialAndContractors

    /// <summary>
    /// Opens dialog for creating the material.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    MaterialAndContractorsPackage CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the material.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedMaterial">The selected material.</param>
    /// <returns></returns>
    MaterialAndContractorsPackage EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                   MaterialAndContractorsPackage selectedMaterial);

    /// <summary>
    /// Opens dialog for managing the materials.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageMaterials(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for managing the material to chose one.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    MaterialAndContractorsPackage SelectMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    #endregion

    #region Recipe

    /// <summary>
    /// Opens dialog for creating the recipe.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    RecipePackage CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the recipe.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipe">The selected recipe.</param>
    /// <returns></returns>
    RecipePackage EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                               RecipePackage recipePackage);

    /// <summary>
    /// Opens dialog for managing the recipes.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageRecipes(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for managing the recipes to chose one.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    RecipePrimitive SelectRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for creating the recipe component.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="recipe">The recipe for which the <see cref="RecipeComponent"/>s will be added.</param>
    /// <returns></returns>
    RecipeComponentPrimitive CreateRecipeComponent(IModalDialogService modalDialogService,
                                                   IServiceFactory serviceFactory, RecipePrimitive recipePrimitive, MaterialAndContractorsPackage materialAndContractorsPackage);

    /// <summary>
    /// Opens dialog for editing the recipe component.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipeComponent">The selected recipe component.</param>
    /// <returns></returns>
    RecipeComponentPrimitive EditRecipeComponent(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                                 RecipeComponentAndMaterialPackage selectedRecipeComponent);

    #endregion

    #region Car

    /// <summary>
    /// Opens dialog for creating the car.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    CarPrimitive CreateCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the car.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipe">The car to edit.</param>
    /// <returns></returns>
    CarPrimitive EditCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                         CarPrimitive selectedCar);

    /// <summary>
    /// Opens dialog for managing the cars.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageCars(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for managing the cars to chose one.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    CarPrimitive SelectCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    #endregion

    #region Driver

    /// <summary>
    /// Opens dialog for creating the driver.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    CarAndDriverPackage CreateDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the driver.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipe">The driver to edit.</param>
    /// <returns></returns>
    CarAndDriverPackage EditDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                               CarAndDriverPackage selectedCarAndDriver);

    /// <summary>
    /// Opens dialog for managing the driver.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageDrivers(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for managing the drivers to chose one.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    CarAndDriverPackage SelectDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

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
    MessageBoxResult ShowMessageBox(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                    MessageBoxImage icon,
                                    string caption, string message, MessageBoxButton button, string info);

    #endregion

    void CreateDriversCarsReport(IModalDialogService modalDialogService, IServiceFactory serviceFactory);


    
  }
}