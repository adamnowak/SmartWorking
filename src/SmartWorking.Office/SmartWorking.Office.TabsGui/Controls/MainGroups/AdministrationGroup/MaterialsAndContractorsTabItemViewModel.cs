﻿using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Contractors;
using SmartWorking.Office.TabsGui.Controls.Materials;

using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class MaterialsAndContractorsTabItemViewModel : TabItemViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ProducersAndMaterialsTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public MaterialsAndContractorsTabItemViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      MaterialDetailsViewModel = new MaterialDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      MaterialListViewModel = new MaterialListViewModel(MainViewModel, MaterialDetailsViewModel, ModalDialogService, ServiceFactory);
      ContractorDetailsViewModel = new ContractorDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      ContractorListViewModel = new ContractorListViewModel(MainViewModel, ContractorDetailsViewModel, ModalDialogService, ServiceFactory);

      ViewModelProvider.RegisterChildViewModel(MaterialDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged);
      ViewModelProvider.RegisterChildViewModel(ContractorDetailsViewModel, ViewModelProviderAction.IsReadOnlyChanged | ViewModelProviderAction.SaveInvoked);

      ViewModelProvider.RegisterChildViewModel(ContractorListViewModel, ViewModelProviderAction.DeleteInvoked);

      ViewModelProvider.ChildrenViewModelDeleteInvoked += new System.EventHandler<ViewModelProviderActionEventArgs>(ViewModelProvider_ChildrenViewModelDeleteInvoked);
      ViewModelProvider.ChildrenViewModelSaveInvoked += new System.EventHandler<ViewModelProviderActionEventArgs>(ViewModelProvider_ChildrenViewModelSaveInvoked);
    }

    void ViewModelProvider_ChildrenViewModelSaveInvoked(object sender, ViewModelProviderActionEventArgs e)
    {
      if (e != null && e.ViewModel != null)
      {
        if (e.ViewModel == ContractorDetailsViewModel)
        {
          MaterialDetailsViewModel.Refresh();
        }
      }
    }

    void ViewModelProvider_ChildrenViewModelDeleteInvoked(object sender, ViewModelProviderActionEventArgs e)
    {
      if (e != null && e.ViewModel != null)
      {
        if (e.ViewModel == ContractorListViewModel)
        {
          MaterialListViewModel.Refresh();
        }
      }
    }

    /// <summary>
    /// Gets the car list view model.
    /// </summary>
    public MaterialListViewModel MaterialListViewModel { get; private set; }

    /// <summary>
    /// Gets the car details view model.
    /// </summary>
    public MaterialDetailsViewModel MaterialDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public ContractorListViewModel ContractorListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public ContractorDetailsViewModel ContractorDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_ProducersAndMaterialsTabItem"; }
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    protected override bool OnRefresh()
    {
      MaterialListViewModel.Refresh();
      MaterialDetailsViewModel.Refresh();
      ContractorListViewModel.Refresh();
      ContractorDetailsViewModel.Refresh();
      return true;
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               (MaterialListViewModel != null ? MaterialListViewModel.IsReadOnly : true) &&
               (MaterialDetailsViewModel != null ? MaterialDetailsViewModel.IsReadOnly : true) &&
               (ContractorListViewModel != null ? ContractorListViewModel.IsReadOnly : true) &&
               (ContractorDetailsViewModel != null ? ContractorDetailsViewModel.IsReadOnly : true);
      }
    }
  }
}