using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.DeliveryNotes
{
  public class DeliveryNoteReportListViewModel : ListingEditableControlViewModel<DeliveryNoteReportPackage>
  {

    public DeliveryNoteReportListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<DeliveryNoteReportPackage> editingViewModel, 
                                           IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
      
    }

    public override string Name
    {
      get { return "DeliveryNoteReportList"; }
    }

    protected override void OnLoadItems()
    {

      using (IReportsService service = ServiceFactory.GetReportsService())
      {
        Items.LoadItems(service.GetDeliveryNoteReportPackageList());

      }

    }
  }
}