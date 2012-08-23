using System.Collections.Generic;
using System.Windows.Controls;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class AdministrationGroupViewModel : TabControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public AdministrationGroupViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      DriversAndCarsTabItemViewModel = new DriversAndCarsTabItemViewModel(mainViewModel, ModalDialogProvider, ServiceFactory);
      MaterialsAndContractorsTabItemViewModel = new MaterialsAndContractorsTabItemViewModel(mainViewModel, ModalDialogProvider, ServiceFactory);
      RecipesTabItemViewModel = new RecipesTabItemViewModel(mainViewModel, ModalDialogProvider, ServiceFactory);
    }

    /// <summary>
    /// Gets the drivers and cars tab item view model.
    /// </summary>
    public DriversAndCarsTabItemViewModel DriversAndCarsTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the materials and contractors tab item view model.
    /// </summary>
    public MaterialsAndContractorsTabItemViewModel MaterialsAndContractorsTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the recipes tab item view model.
    /// </summary>
    public RecipesTabItemViewModel RecipesTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return Resources.AdministrationGroupViewModel_Name; }
    }

   

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
          (DriversAndCarsTabItemViewModel != null ? DriversAndCarsTabItemViewModel.IsReadOnly : true) &&
          (MaterialsAndContractorsTabItemViewModel != null ? MaterialsAndContractorsTabItemViewModel.IsReadOnly : true) &&
          (RecipesTabItemViewModel != null ? RecipesTabItemViewModel.IsReadOnly : true);
      }
    }

  }
}
