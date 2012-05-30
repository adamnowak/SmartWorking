using System;

namespace SmartWorking.Office.Gui.ViewModel
{
  public interface IModalDialogViewModel
  {
    event EventHandler RequestClose;
    string Title { get; }
    bool Canceled { get; }
  }
}