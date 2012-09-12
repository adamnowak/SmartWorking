using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Users;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class UsersViewModel : TabControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UsersViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      UserDetailsViewModel = new UserDetailsViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      UserListViewModel = new UserListViewModel(MainViewModel, UserDetailsViewModel, ModalDialogProvider, ServiceFactory);

      RoleDetailsViewModel = new RoleDetailsViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      RoleListViewModel = new RoleListViewModel(MainViewModel, RoleDetailsViewModel, ModalDialogProvider, ServiceFactory);
    }


    public UserDetailsViewModel UserDetailsViewModel { get; private set; }
    public UserListViewModel UserListViewModel { get; private set; }
    public RoleDetailsViewModel RoleDetailsViewModel { get; private set; }
    public RoleListViewModel RoleListViewModel { get; private set; }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "Users"; }
    }

    protected override bool OnRefresh()
    {
      UserListViewModel.Refresh();
      UserDetailsViewModel.Refresh();
      RoleListViewModel.Refresh();
      RoleDetailsViewModel.Refresh();
      return true;
    }
  }
}
