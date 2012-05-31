using System.ServiceModel;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Factory.IIS
{
  interface IContractorsServiceChannel : IContractorsService, IClientChannel { }
  interface IMaterialsServiceChannel : IMaterialsService, IClientChannel { }
  interface IRecipesServiceChannel : IRecipesService, IClientChannel { }

  public class ServiceFactoryIIS : IServiceFactory
  {
    #region IServiceFactory Members

    public IContractorsService GetContractorsService()
    {
      var channelFactory = new ChannelFactory<IContractorsServiceChannel>();
      var service = channelFactory.CreateChannel();
      return service;
    }

    public IMaterialsService GetMaterialsService()
    {
      var channelFactory = new ChannelFactory<IMaterialsServiceChannel>();
      var service = channelFactory.CreateChannel();
      return service;
    }

    public IRecipesService GetRecipesService()
    {
      var channelFactory = new ChannelFactory<IRecipesServiceChannel>();
      var service = channelFactory.CreateChannel();
      return service;
    }

    #endregion
  }
}