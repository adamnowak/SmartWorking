using System.Collections.Generic;
using System.Windows.Controls;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

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
    public AdministrationGroupViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      DriversAndCarsTabItemViewModel = new DriversAndCarsTabItemViewModel(ModalDialogService, ServiceFactory);
    }

    public DriversAndCarsTabItemViewModel DriversAndCarsTabItemViewModel { get; private set; }

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
  }
}
