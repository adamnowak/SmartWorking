using System;
using System.Windows;
using SmartWorking.Office.Gui.View.Cars;
using SmartWorking.Office.Gui.View.Clients;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Gui.View.DeliveryNotes;
using SmartWorking.Office.Gui.View.Drivers;
using SmartWorking.Office.Gui.View.Materials;
using SmartWorking.Office.Gui.View.Orders;
using SmartWorking.Office.Gui.View.Recipes;
using SmartWorking.Office.Gui.View.Reports;
using SmartWorking.Office.Gui.View.Shared.MessageBox;
using SmartWorking.Office.Gui.ViewModel;
using SmartWorking.Office.Gui.ViewModel.Cars;
using SmartWorking.Office.Gui.ViewModel.Clients;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Gui.ViewModel.DeliveryNotes;
using SmartWorking.Office.Gui.ViewModel.Drivers;
using SmartWorking.Office.Gui.ViewModel.Materials;
using SmartWorking.Office.Gui.ViewModel.Orders;
using SmartWorking.Office.Gui.ViewModel.Recipes;
using SmartWorking.Office.Gui.ViewModel.Reports;
using SmartWorking.Office.Gui.ViewModel.Shared.MessageBox;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using MessageBox = SmartWorking.Office.Gui.View.Shared.MessageBox.MessageBox;



namespace SmartWorking.Office.Gui.View
{
  public class ModalDialogService : IModalDialogService
  {
    #region IModalDialogService Members

    public OrderPackage CreateOrder(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateOrderViewModel(modalDialogService, serviceFactory);
      viewModel.OrderPackage = new OrderPackage();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateOrder>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.OrderPackage;
      }
      return null;
    }

    public void ManageOrders(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageOrdersViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageOrders>.ShowDialog(viewModel);
    }

    public ClientPrimitive CreateClient(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateClientViewModel(modalDialogService, serviceFactory);
      viewModel.Client = new ClientPrimitive();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateClient>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.Client;
      }
      return null;
    }

    public ClientPrimitive EditClient(IModalDialogService modalDialogService, IServiceFactory serviceFactory, ClientPrimitive client)
    {
      var viewModel = new UpdateClientViewModel(modalDialogService, serviceFactory);
      viewModel.Client = client;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateClient>.ShowDialog(viewModel);
      return viewModel.Client;
    }

    public void ManageClients(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageClientsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageClients>.ShowDialog(viewModel);
    }

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

    public ContractorPrimitive SelectContractor(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageContractorsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Chose;
      ModalDialogHelper<ManageContractors>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.SelectableContractor.SelectedItem;
      }
      return null;
    }

    public ClientBuildingAndBuildingPackage CreateBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                            ClientPrimitive client)
    {
      var viewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      //viewModel.Contractor = contractor;
      viewModel.BuildingAndClient = new ClientBuildingAndBuildingPackage();
      viewModel.BuildingAndClient.Building = new BuildingPrimitive();
      viewModel.BuildingAndClient.Client = client;
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.BuildingAndClient;
      }
      return null;
    }

    public ClientBuildingAndBuildingPackage EditBuilding(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                          ClientBuildingAndBuildingPackage buildingAndClientPackage)
    {
      var viewModel = new UpdateBuildingViewModel(modalDialogService, serviceFactory);
      viewModel.BuildingAndClient = buildingAndClientPackage;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateBuilding>.ShowDialog(viewModel);
      return viewModel.BuildingAndClient;
    }

    public ClientBuildingAndBuildingPackage SelectBuildingAndContractorPackage(IModalDialogService modalDialogService,
                                                                           IServiceFactory serviceFactory)
    {
      var viewModel = new ManageClientsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.ChoseSubItem;
      ModalDialogHelper<ManageClients>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        var result = new ClientBuildingAndBuildingPackage();
        result.Building = viewModel.SelectedBuilding;
        result.Client = viewModel.SelectableClient.SelectedItem.Client;
        return result;
      }
      return null;
    }

    public DeliveryNotePackage CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateDeliveryNoteViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Create;
      viewModel.DeliveryNotePackage = new DeliveryNotePackage();
      viewModel.DeliveryNotePackage.DeliveryNote = new DeliveryNotePrimitive();
      viewModel.DeliveryNotePackage.DeliveryNote.DateDrawing = DateTime.Now;
      viewModel.DeliveryNotePackage.DeliveryNote.DateOfArrival = DateTime.Now;
      ModalDialogHelper<UpdateDeliveryNote>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.DeliveryNotePackage;
      }
      return null;
    }

    public DeliveryNotePackage CreateDeliveryNote(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                                  ClientBuildingAndBuildingPackage buildingAndContractorPackage)
    {
      var viewModel = new UpdateDeliveryNoteViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Create;
      viewModel.DeliveryNotePackage = new DeliveryNotePackage();
      viewModel.DeliveryNotePackage.DeliveryNote = new DeliveryNotePrimitive();
      viewModel.DeliveryNotePackage.DeliveryNote.DateDrawing = DateTime.Now;
      viewModel.DeliveryNotePackage.DeliveryNote.DateOfArrival = DateTime.Now;
      viewModel.DeliveryNotePackage.BuildingAndContractor = buildingAndContractorPackage;
      ModalDialogHelper<UpdateDeliveryNote>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.DeliveryNotePackage;
      }
      return null;
    }

    public void ManageDeliveryNotes(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageDeliveryNotesViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageDeliveryNotes>.ShowDialog(viewModel);
    }

    public MaterialAndContractorsPackage CreateMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      viewModel.MaterialAndContractors = new MaterialAndContractorsPackage();
      viewModel.MaterialAndContractors.Material = new MaterialPrimitive();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.MaterialAndContractors;
      }
      return null;
    }

    public MaterialAndContractorsPackage EditMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                          MaterialAndContractorsPackage selectedMaterial)
    {
      var viewModel = new UpdateMaterialViewModel(modalDialogService, serviceFactory);
      viewModel.MaterialAndContractors = selectedMaterial;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateMaterial>.ShowDialog(viewModel);
      return viewModel.MaterialAndContractors;
    }

    public void ManageMaterials(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageMaterialsViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageMaterials>.ShowDialog(viewModel);
    }

    public MaterialAndContractorsPackage SelectMaterial(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
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

    public RecipePackage CreateRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.RecipePackage = new RecipePackage();
      viewModel.RecipePackage.Recipe = new RecipePrimitive();      
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.RecipePackage;
      }
      return null;
    }

    public RecipePackage EditRecipe(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                      RecipePackage recipePackage)
    {
      var viewModel = new UpdateRecipeViewModel(modalDialogService, serviceFactory);
      viewModel.RecipePackage = recipePackage;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateRecipe>.ShowDialog(viewModel);
      return viewModel.RecipePackage;
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
        return viewModel.SelectableRecipe.SelectedItem.Recipe;
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
    public RecipeComponentPrimitive CreateRecipeComponent(IModalDialogService modalDialogService,
                                                          IServiceFactory serviceFactory, 
                                                          RecipePrimitive recipePrimitive, MaterialAndContractorsPackage materialAndContractorsPackage)
    {
      var viewModel = new UpdateRecipeComponentViewModel(modalDialogService, serviceFactory);
      viewModel.RecipeComponent = new RecipeComponentPrimitive();
      viewModel.RecipeComponent.Recipe_Id = recipePrimitive.Id;
      viewModel.MaterialAndContractors = materialAndContractorsPackage;
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
    /// <param name="recipeComponentAndMaterialPackage">The selected recipe component.</param>
    /// <returns></returns>
    public RecipeComponentPrimitive EditRecipeComponent(IModalDialogService modalDialogService,
                                                        IServiceFactory serviceFactory,
                                                        RecipeComponentAndMaterialPackage recipeComponentAndMaterialPackage)
    {
      var viewModel = new UpdateRecipeComponentViewModel(modalDialogService, serviceFactory);
      viewModel.RecipeComponent = recipeComponentAndMaterialPackage.RecipeComponent;
      viewModel.MaterialAndContractors = recipeComponentAndMaterialPackage.MaterialAndContractors;
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

    public CarPrimitive EditCar(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                CarPrimitive selectedCar)
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

    public CarAndDriverPackage CreateDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new UpdateDriverViewModel(modalDialogService, serviceFactory);
      viewModel.CarAndDriver = new CarAndDriverPackage();
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<UpdateDriver>.ShowDialog(viewModel);
      if (!viewModel.IsCanceled)
      {
        return viewModel.CarAndDriver;
      }
      return null;
    }

    public CarAndDriverPackage EditDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                      CarAndDriverPackage selectedCarAndDriver)
    {
      var viewModel = new UpdateDriverViewModel(modalDialogService, serviceFactory);
      viewModel.CarAndDriver = selectedCarAndDriver;
      viewModel.DialogMode = DialogMode.Update;
      ModalDialogHelper<UpdateDriver>.ShowDialog(viewModel);
      return viewModel.CarAndDriver;
    }

    public void ManageDrivers(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new ManageDriversViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Manage;
      ModalDialogHelper<ManageDrivers>.ShowDialog(viewModel);
    }

    public CarAndDriverPackage SelectDriver(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
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
                                           MessageBoxImage icon, string caption, string message, MessageBoxButton button,
                                           string info)
    {
      var viewModel = new MessageBoxViewModel(modalDialogService, serviceFactory, icon, caption, message, button, info);
      return MessageBoxHelper<MessageBox>.ShowDialog(viewModel);
    }

    public void CreateDriversCarsReport(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      var viewModel = new DriversCarsReportViewModel(modalDialogService, serviceFactory);
      viewModel.DialogMode = DialogMode.Create;
      ModalDialogHelper<DriversCarsReport>.ShowDialog(viewModel);      
    }

    #endregion
  }
}