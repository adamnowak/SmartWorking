using System.Windows;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Provides functionality of opening modal dialogs.
  /// </summary>
  public interface IModalDialogService
  {
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

    #endregion

    #region Building

    /// <summary>
    /// Opens dialog for creating the building.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="contractor">The contractor.</param>
    /// <returns>Created Building.</returns>
    BuildingPrimitive CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                            ContractorPrimitive contractor);

    /// <summary>
    /// Opens dialog for editing building.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="building">The building.</param>
    /// <returns>Edited Building.</returns>
    BuildingPrimitive EditBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, BuildingPrimitive building);

    /// <summary>
    /// Opens dialog for managing Contractor and user can chose Building.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>    
    /// <returns>Selected Building.</returns>
    BuildingAndContractorPackage SelectBuildingAndContractorPackage(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

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
    DeliveryNotePackage CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory, BuildingAndContractorPackage buildingAndContractorPackage);

    /// <summary>
    /// Opens dialog for managing the delivery notes.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageDeliveryNotes(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    #endregion

    #region Material

    /// <summary>
    /// Opens dialog for creating the material.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    MaterialPrimitive CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the material.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedMaterial">The selected material.</param>
    /// <returns></returns>
    MaterialPrimitive EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                          MaterialPrimitive selectedMaterial);

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
    MaterialPrimitive SelectMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
    #endregion

    #region Recipe

    /// <summary>
    /// Opens dialog for creating the recipe.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    RecipePrimitive CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the recipe.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipe">The selected recipe.</param>
    /// <returns></returns>
    RecipePrimitive EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory, RecipePrimitive selectedRecipe);

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
    RecipeComponentPrimitive CreateRecipeComponent(IModalDialogService modalDialogService, IServiceFactory serviceFactory, RecipePrimitive recipe);

    /// <summary>
    /// Opens dialog for editing the recipe component.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipeComponent">The selected recipe component.</param>
    /// <returns></returns>
    RecipeComponentPrimitive EditRecipeComponent(IModalDialogService modalDialogService, IServiceFactory serviceFactory, RecipeComponentAndMaterialPackage selectedRecipeComponent);
    
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
    CarPrimitive EditCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory, CarPrimitive selectedCar);

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
    DriverPrimitive CreateDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the driver.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipe">The driver to edit.</param>
    /// <returns></returns>
    DriverPrimitive EditDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory, DriverPrimitive selectedDriver);

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
    DriverPrimitive SelectDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory);
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

  }
}