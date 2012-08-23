using System;
using System.Linq;
using System.Collections.Generic;
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
                                           IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogProvider, serviceFactory)
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
        List<DeliveryNoteReportPackage> items = service.GetDeliveryNoteReportPackageList();
        if (items != null)
        {
          Items.LoadItems(items.OrderByDescending(x => (x.DeliveryNote != null) ? x.DeliveryNote.Year : int.MaxValue).OrderByDescending(x => (x.DeliveryNote != null) ? x.DeliveryNote.Number : int.MaxValue).ToList());
        }
        else
        {
          Items.LoadItems(null);
        }
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
            string reason = string.Empty;
            if (ModalDialogProvider.ShowInputDialog("Wprowadz powód anulowania", "Powód:", ref reason, false))
            {
              service.DeactiveDeliveryNote(Items.SelectedItem.DeliveryNote, reason);
            }
            else
            {
              return false;
            }
          }
        }
        Refresh();
        return true;
      }

      return false;
    }

    #region ChangeReasonOfDeactivatedFlagCommand
    private ICommand _changeReasonOfDeactivatedFlagCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand ChangeReasonOfDeactivatedFlagCommand
    {
      get
      {
        if (_changeReasonOfDeactivatedFlagCommand == null)
          _changeReasonOfDeactivatedFlagCommand = new RelayCommand(ChangeReasonOfDeactivatedFlag, CanChangeReasonOfDeactivatedFlag);
        return _changeReasonOfDeactivatedFlagCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanChangeReasonOfDeactivatedFlag()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void ChangeReasonOfDeactivatedFlag()
    {
      string errorCaption = "TODO!";
      try
      {
        if (Items != null && Items.SelectedItem != null && base.OnItemDeactivatedFlagChanged())
        {

          string reason = string.Empty;
            //(Items.SelectedItem.DeliveryNote != null)
            //                ? Items.SelectedItem.DeliveryNote.ReasonOfDeactivated
            //                : string.Empty;
          if (ModalDialogProvider.ShowInputDialog("Wprowadz powód anulowania", "Powód:", ref reason, false))
          {
            using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
            {
              service.DeactiveDeliveryNote(Items.SelectedItem.DeliveryNote, reason);
            }
            Refresh();
          }
        }
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }
    #endregion //ChangeReasonOfDeactivatedFlagCommandCommand
  }
}