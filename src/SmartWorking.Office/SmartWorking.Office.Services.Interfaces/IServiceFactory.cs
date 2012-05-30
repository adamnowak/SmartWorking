

namespace SmartWorking.Office.Services.Interfaces
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  public interface IServiceFactory
  {
    IContractorsService GetContractorsService();
    IMaterialsService GetMaterialsService();
    IRecipesService GetRecipesService();
  }
}