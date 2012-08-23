using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using SmartWorking.Office.TabsGui.Shared.ViewModel.MessageBox;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  public interface IMainViewModel : ITabControlViewModel
  {
    AccessLevel AccessLevel { get;  }
    bool IsDebugMode { get; }
    SmartWorkingConfiguration Configuration { get; }
    string StatusText { get; set; }
    Color StatusTextColor { get; set; }
    //string ProgressText { get; set; }
    //bool IsActionExecuting { get; set; }
    //void ShowModalDialog(ControlViewModelBase viewModel, VisibleModalDialogEnum visibleModalDialogEnum);
    bool SetAccessByUserPassword(string userId, string password);
  }
}
