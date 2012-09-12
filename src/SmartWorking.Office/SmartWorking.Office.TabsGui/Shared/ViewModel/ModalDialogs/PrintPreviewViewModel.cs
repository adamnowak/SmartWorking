using SmartWorking.Office.Gui.ViewModel;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.View
{
  public class PrintPreviewViewModel : ModalDialogViewModelBase
  {
    public PrintPreviewViewModel(IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(modalDialogProvider, serviceFactory)
    {
    }
    public override string Title
    {
      get { return "PrintPreview"; }
    }
  }
}