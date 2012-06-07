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
    /// Gets the materials service.
    /// </summary>
    /// <returns>Service provides operations on materials.</returns>
    IMaterialsService GetMaterialsService();

    /// <summary>
    /// Gets the recipes service.
    /// </summary>
    /// <returns>Service provides operations on recipes.</returns>
    IRecipesService GetRecipesService();
  }
}