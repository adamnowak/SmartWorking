using System.Windows.Controls;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;
using WPFLocalizeExtension.Engine;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class SaleGroupViewModel : TabControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public SaleGroupViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      ClientsAndBuildingsTabItemViewModel = new ClientsAndBuildingsTabItemViewModel(mainViewModel, ModalDialogProvider, ServiceFactory);
      OrdersTabItemViewModel = new OrdersTabItemViewModel(mainViewModel, ModalDialogProvider, ServiceFactory);
      DeliveryNotesTabItemViewModel = new DeliveryNotesTabItemViewModel(mainViewModel, ModalDialogProvider, ServiceFactory);

      
    }

    /// <summary>
    /// Gets the drivers and cars tab item view model.
    /// </summary>
    public ClientsAndBuildingsTabItemViewModel ClientsAndBuildingsTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the materials and contractors tab item view model.
    /// </summary>
    public OrdersTabItemViewModel OrdersTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the recipes tab item view model.
    /// </summary>
    public DeliveryNotesTabItemViewModel DeliveryNotesTabItemViewModel { get; private set; }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return Resources.SaleGroupViewModel_Name; }
    }

    

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&               
          (ClientsAndBuildingsTabItemViewModel != null ? ClientsAndBuildingsTabItemViewModel.IsReadOnly : true);
      }
    }

  }
}
