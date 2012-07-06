using System;
using SmartWorking.Office.Services.Hosting.Local;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Factory.Local
{
  /// <summary>
  /// Service factory which are stored locally.
  /// </summary>
  public class ServiceFactoryLocal : IServiceFactory
  {
    #region IServiceFactory Members

    /// <summary>
    /// Gets the orders service.
    /// </summary>
    /// <returns>
    /// Service provides operations on orders.
    /// </returns>
    public IOrdersService GetOrdersService()
    {
      return new OrdersService();
    }

    /// <summary>
    /// Gets the clients service.
    /// </summary>
    /// <returns>
    /// Service provides operations on clients.
    /// </returns>
    public IClientsService GetClientsService()
    {
      return new ClientsService();
    }

    /// <summary>
    /// Gets the contractors service.
    /// </summary>
    /// <returns>
    /// Service provides operations on contractors.
    /// </returns>
    public IContractorsService GetContractorsService()
    {
      return new ContractorsService();
    }

    /// <summary>
    /// Gets the materials service.
    /// </summary>
    /// <returns>
    /// Service provides operations on materials.
    /// </returns>
    public IMaterialsService GetMaterialsService()
    {
      return new MaterialsService();
    }

    /// <summary>
    /// Gets the recipes service.
    /// </summary>
    /// <returns>
    /// Service provides operations on recipes.
    /// </returns>
    public IRecipesService GetRecipesService()
    {
      return new RecipesService();
    }

    /// <summary>
    /// Gets the cars service.
    /// </summary>
    /// <returns>
    /// Service provides operations on cars.
    /// </returns>
    public ICarsService GetCarsService()
    {
      return new CarsService();
    }

    /// <summary>
    /// Gets the delivery notes service.
    /// </summary>
    /// <returns>
    /// Service provides operations on delivery notes.
    /// </returns>
    public IDeliveryNotesService GetDeliveryNotesService()
    {
      return new DeliveryNotesService();
    }

    /// <summary>
    /// Gets the recipes drivers.
    /// </summary>
    /// <returns>
    /// Service provides operations on drivers.
    /// </returns>
    public IDriversService GetDriversService()
    {
      return new DriversService();
    }

    /// <summary>
    /// Gets the reports service.
    /// </summary>
    /// <returns>
    /// Service provides operations to create reports.
    /// </returns>
    public IReportsService GetReportsService()
    {
      return new ReportsService();
    }

    #endregion
  }
}