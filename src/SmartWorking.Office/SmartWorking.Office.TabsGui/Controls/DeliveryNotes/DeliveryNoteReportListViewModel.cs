using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
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

    protected override bool OnItemDeactivatedFlagChanged()
    {
      if (Items != null && Items.SelectedItem != null && base.OnItemDeactivatedFlagChanged())
      {
        using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
        {
          if (Items.SelectedItem.DeliveryNote.IsDeactive)
          {
            service.ActiveDeliveryNote(Items.SelectedItem.DeliveryNote);
          }
          else
          {
            service.DeactiveDeliveryNote(Items.SelectedItem.DeliveryNote);
          }
        }
        Refresh();
        return true;
      }
      return false;
    }

    
  }
}