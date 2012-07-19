using System.Collections.Generic;
using System.Windows.Controls;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
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
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public AdministrationGroupViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      DriversAndCarsTabItemViewModel = new DriversAndCarsTabItemViewModel(mainViewModel, ModalDialogService, ServiceFactory);
      MaterialsAndContractorsTabItemViewModel = new MaterialsAndContractorsTabItemViewModel(mainViewModel, ModalDialogService, ServiceFactory);
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
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "str_AdministrationGroup"; }
    }

    protected override void WorkaroundOnSelectedTab(TabItem oldValue)
    {
      if (oldValue == null && SelectedTab != null)
      {
        //TabChanged(new SelectionChangedEventArgs(TabControl.SelectionChangedEvent, new List<TabItem>(), new List<TabItem> { SelectedTab }));
      }
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly && DriversAndCarsTabItemViewModel.IsReadOnly;
      }
    }

  }
}
