using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.Services.Hosting.Local;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Factory.Local
{
  public class ServiceFactoryLocal : IServiceFactory
  {
    public IContractorsService GetContractorsService()
    {
      return new ContractorsService();
    }

    public IMaterialsService GetMaterialsService()
    {
      return new MaterialsService();
    }

    public IRecipesService GetRecipesService()
    {
      return new RecipesService();
    }
  }
}
