using SmartWorking.Office.Entities;
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
    Contractor CreateContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the contractor.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="contractorToEdit">The contractor to edit.</param>
    /// <returns></returns>
    Contractor EditContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                              Contractor contractorToEdit);

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
    /// <returns></returns>
    Building CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                            Contractor contractor);

    /// <summary>
    /// Opens dialog for editing building.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="building">The building.</param>
    /// <returns></returns>
    Building EditBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Building building);

    #endregion

    #region DeliveryNote

    /// <summary>
    /// Opens dialog for creating delivery note.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    DeliveryNote CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

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
    Material CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the material.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedMaterial">The selected material.</param>
    /// <returns></returns>
    Material EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                          Material selectedMaterial);

    /// <summary>
    /// Opens dialog for managing the materials.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageMaterials(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    #endregion

    #region Recipe

    /// <summary>
    /// Opens dialog for creating the recipe.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    Recipe CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the recipe.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipe">The selected recipe.</param>
    /// <returns></returns>
    Recipe EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Recipe selectedRecipe);

    /// <summary>
    /// Opens dialog for managing the recipes.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageRecipes(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    #endregion

    #region Car

    /// <summary>
    /// Opens dialog for creating the car.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    Car CreateCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the car.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipe">The car to edit.</param>
    /// <returns></returns>
    Car EditCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Car selectedCar);

    /// <summary>
    /// Opens dialog for managing the cars.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageCars(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    #endregion

    #region Driver

    /// <summary>
    /// Opens dialog for creating the driver.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <returns></returns>
    Driver CreateDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    /// <summary>
    /// Opens dialog for editing the driver.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="selectedRecipe">The driver to edit.</param>
    /// <returns></returns>
    Driver EditDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory, Driver selectedDriver);

    /// <summary>
    /// Opens dialog for managing the driver.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    void ManageDrivers(IModalDialogService modalDialogService, IServiceFactory serviceFactory);

    #endregion
  }
}