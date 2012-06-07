namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Factory for services.
  /// </summary>
  public interface IServiceFactory
  {
    /// <summary>
    /// Gets the contractors service.
    /// </summary>
    /// <returns>Service provides operations on contractors.</returns>
    IContractorsService GetContractorsService();

    /// <summary>
    /// Gets the delivery notes service.
    /// </summary>
    /// <returns>Service provides operations on delivery notes.</returns>
    IDeliveryNotesService GetDeliveryNotesService();

    /// <summary>
    /// Gets the materials service.
    /// </summary>
    /// <returns>Service provides operations on materials.</returns>
    IMaterialsService GetMaterialsService();

    /// <summary>
    /// Gets the recipes service.
    /// </summary>
    /// <returns>Service provides operations on recipes.</returns>
    IRecipesService GetRecipesService();

    /// <summary>
    /// Gets the cars service.
    /// </summary>
    /// <returns>Service provides operations on cars.</returns>
    ICarsService GetCarsService();


    /// <summary>
    /// Gets the drivers service.
    /// </summary>
    /// <returns>Service provides operations on drivers.</returns>
    IDriversService GetDriversService();
  }
}