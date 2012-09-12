using System;
using System.Windows.Input;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs
{
  public interface IProgressActionViewModel
  {
    ProgressActionStatusEnum ActionStatus { get; }
    void Action();
    void Error(Exception exception);
    void Completed();
    ICommand Cancel { get; }
    Exception Exception { get; set; }

    string Text { get; }
  }
}