﻿using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Buildings;
using SmartWorking.Office.TabsGui.Controls.Clients;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class ClientsAndBuildingsTabItemViewModel : TabItemViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ProducersAndMaterialsTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ClientsAndBuildingsTabItemViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      ClientDetailsViewModel = new ClientDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      ClientListViewModel = new ClientListViewModel(MainViewModel, ClientDetailsViewModel, ModalDialogService, ServiceFactory);
      BuildingDetailsViewModel = new BuildingDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      BuildingListViewModel = new BuildingListViewModel(MainViewModel, BuildingDetailsViewModel, ModalDialogService, ServiceFactory);
    }

    /// <summary>
    /// Gets the car list view model.
    /// </summary>
    public ClientListViewModel ClientListViewModel { get; private set; }

    /// <summary>
    /// Gets the car details view model.
    /// </summary>
    public ClientDetailsViewModel ClientDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the recipe component details view model.
    /// </summary>
    public BuildingDetailsViewModel BuildingDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the recipe component list view model.
    /// </summary>
    public BuildingListViewModel BuildingListViewModel { get; private set; }



    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_ClientsAndBuildings"; }
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    public override void Refresh()
    {
      ClientListViewModel.Refresh();
      //ClientDetailsViewModel.Refresh();
      BuildingListViewModel.Refresh();
      //BuildingDetailsViewModel.Refresh();
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               ClientListViewModel.IsReadOnly &&
               ClientDetailsViewModel.IsReadOnly &&
               BuildingListViewModel.IsReadOnly &&
               BuildingDetailsViewModel.IsReadOnly;
      }
    }
  }
}