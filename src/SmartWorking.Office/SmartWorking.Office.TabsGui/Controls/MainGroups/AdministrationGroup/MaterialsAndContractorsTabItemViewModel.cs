using SmartWorking.Office.PrimitiveEntities;
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
  public class MaterialsAndContractorsTabItemViewModel : ControlViewModelBase
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
    public override void Refresh()
    {
      MaterialListViewModel.Refresh();
      MaterialDetailsViewModel.Refresh();
      ContractorListViewModel.Refresh();
      ContractorDetailsViewModel.Refresh();
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               MaterialListViewModel.IsReadOnly &&
               MaterialDetailsViewModel.IsReadOnly &&
               ContractorListViewModel.IsReadOnly &&
               ContractorDetailsViewModel.IsReadOnly;
      }
    }
  }
}