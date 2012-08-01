using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class SettingsGroupViewModel : TabControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public SettingsGroupViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      
      GeneralViewModel = new GeneralViewModel(mainViewModel, ModalDialogService, ServiceFactory);
      UsersViewModel = new UsersViewModel(mainViewModel, ModalDialogService, ServiceFactory);

      
    }

    /// <summary>
    /// Gets the drivers and cars tab item view model.
    /// </summary>
    public UsersViewModel UsersViewModel { get; private set; }

    /// <summary>
    /// Gets the materials and contractors tab item view model.
    /// </summary>
    public GeneralViewModel GeneralViewModel { get; private set; }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "Settings"; }
    }
  }
}
