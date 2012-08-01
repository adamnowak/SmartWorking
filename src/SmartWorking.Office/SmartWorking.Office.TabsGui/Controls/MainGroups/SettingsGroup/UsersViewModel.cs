﻿using SmartWorking.Office.Services.Interfaces;
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
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UsersViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {

      

      
    }




    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "Users"; }
    }

    


  }
}
