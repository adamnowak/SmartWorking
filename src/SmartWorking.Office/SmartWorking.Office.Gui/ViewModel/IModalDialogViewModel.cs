using System;

namespace SmartWorking.Office.Gui.ViewModel
{
  public interface IModalDialogViewModel
  {
    string Title { get; }
    bool IsCanceled { get; }
    event EventHandler RequestClose;
  }
}