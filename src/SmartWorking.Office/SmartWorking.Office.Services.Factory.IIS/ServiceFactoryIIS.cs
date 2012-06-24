using System;
using System.ServiceModel;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Factory.IIS
{
  /// <summary>
  /// <see cref="IClientChannel"/> for <see cref="IContractorsService"/> service.
  /// </summary>
  internal interface IContractorsServiceChannel : IContractorsService, IClientChannel
  {
  }

  /// <summary>
  /// <see cref="IClientChannel"/> for <see cref="IMaterialsService"/> service.
  /// </summary>
  internal interface IMaterialsServiceChannel : IMaterialsService, IClientChannel
  {
  }

  /// <summary>
  /// <see cref="IClientChannel"/> for <see cref="IRecipesService"/> service.
  /// </summary>
  internal interface IRecipesServiceChannel : IRecipesService, IClientChannel
  {
  }

  /// <summary>
  /// <see cref="IClientChannel"/> for <see cref="ICarsService"/> service.
  /// </summary>
  internal interface ICarsServiceChannel : ICarsService, IClientChannel
  {
  }

  /// <summary>
  /// <see cref="IClientChannel"/> for <see cref="IDeliveryNotesService"/> service.
  /// </summary>
  internal interface IDeliveryNotesServiceChannel : IDeliveryNotesService, IClientChannel
  {
  }

  /// <summary>
  /// <see cref="IClientChannel"/> for <see cref="IDriversService"/> service.
  /// </summary>
  internal interface IDriversServiceChannel : IDriversService, IClientChannel
  {
  }

  /// <summary>
  /// <see cref="IClientChannel"/> for <see cref="IReportsService"/> service.
  /// </summary>
  internal interface IReportsServiceChannel : IReportsService, IClientChannel
  {
  }

  /// <summary>
  /// Service factory which are stored on IIS.
  /// </summary>
  public class ServiceFactoryIIS : IServiceFactory
  {
    #region IServiceFactory Members

    /// <summary>
    /// Gets the contractors service.
    /// </summary>
    /// <returns>
    /// Service provides operations on contractors.
    /// </returns>
    public IContractorsService GetContractorsService()
    {
      var channelFactory = new ChannelFactory<IContractorsServiceChannel>("*");
      IContractorsServiceChannel service = channelFactory.CreateChannel();
      return service;
    }

    /// <summary>
    /// Gets the materials service.
    /// </summary>
    /// <returns>
    /// Service provides operations on materials.
    /// </returns>
    public IMaterialsService GetMaterialsService()
    {
      var channelFactory = new ChannelFactory<IMaterialsServiceChannel>("*");
      IMaterialsServiceChannel service = channelFactory.CreateChannel();
      return service;
    }

    /// <summary>
    /// Gets the recipes service.
    /// </summary>
    /// <returns>
    /// Service provides operations on recipes.
    /// </returns>
    public IRecipesService GetRecipesService()
    {
      var channelFactory = new ChannelFactory<IRecipesServiceChannel>("*");
      IRecipesServiceChannel service = channelFactory.CreateChannel();
      return service;
    }

    /// <summary>
    /// Gets the cars service.
    /// </summary>
    /// <returns>
    /// Service provides operations on cars.
    /// </returns>
    public ICarsService GetCarsService()
    {
      var channelFactory = new ChannelFactory<ICarsServiceChannel>("*");
      ICarsServiceChannel service = channelFactory.CreateChannel();
      return service;
    }

    /// <summary>
    /// Gets the delivery notes service.
    /// </summary>
    /// <returns>
    /// Service provides operations on delivery notes.
    /// </returns>
    public IDeliveryNotesService GetDeliveryNotesService()
    {
      var channelFactory = new ChannelFactory<IDeliveryNotesServiceChannel>("*");
      IDeliveryNotesServiceChannel service = channelFactory.CreateChannel();
      return service;
    }

    /// <summary>
    /// Gets the drivers service.
    /// </summary>
    /// <returns>
    /// Service provides operations on drivers.
    /// </returns>
    public IDriversService GetDriversService()
    {
      var channelFactory = new ChannelFactory<IDriversServiceChannel>("*");
      IDriversServiceChannel service = channelFactory.CreateChannel();
      return service;
    }

    /// <summary>
    /// Gets the reports service.
    /// </summary>
    /// <returns>
    /// Service provides operations to create reports.
    /// </returns>
    public IReportsService GetReportsService()
    {
      var channelFactory = new ChannelFactory<IReportsServiceChannel>("*");
      IReportsServiceChannel service = channelFactory.CreateChannel();
      return service;
    }

    #endregion
  }
}