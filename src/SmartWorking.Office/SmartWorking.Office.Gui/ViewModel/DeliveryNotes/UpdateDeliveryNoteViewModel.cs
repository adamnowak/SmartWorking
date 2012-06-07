using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  public class UpdateDeliveryNoteViewModel : ModalDialogViewModelBase
  {
    public UpdateDeliveryNoteViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    public DialogMode DialogMode { get; set; }

    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nową WZ'tkę."
                 : "Edytuj WZ'tkę.";
      }
    }

    #region Building property

    /// <summary>
    /// The <see cref="Building" /> property's name.
    /// </summary>
    public const string BuildingPropertyName = "Building";

    private Building _building;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Building Building
    {
      get { return _building; }

      set
      {
        if (_building == value)
        {
          return;
        }
        _building = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(BuildingPropertyName);
      }
    }

    #endregion

    #region SelectBuildingCommand

    /// <summary>
    /// The <see cref="DeliveryNote" /> property's name.
    /// </summary>
    public const string DeliveryNotePropertyName = "DeliveryNote";

    private DeliveryNote _deliveryNote;
    private ICommand _selectBuildingCommand;

    public ICommand SelectBuildingCommand
    {
      get
      {
        if (_selectBuildingCommand == null)
          _selectBuildingCommand = new RelayCommand(SelcectContractor);
        return _selectBuildingCommand;
      }
    }

    /// <summary>
    /// Gets the DeliveryNote property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public DeliveryNote DeliveryNote
    {
      get { return _deliveryNote; }

      set
      {
        if (_deliveryNote == value)
        {
          return;
        }
        _deliveryNote = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(DeliveryNotePropertyName);
      }
    }

    private void SelcectContractor()
    {
      //Contractor selectContractor = ModalDialogService.ManageContractors(ModalDialogService, ServiceFactory);
      //if (selectContractor != null)
      //{
      //  Building = ModalDialogService.SelectBuilding(ModalDialogService, ServiceFactory, selectContractor);
      //}
    }


    private void PrintPDF()
    {
      string filename = "d:\\adamnowak\\private\\Sylwek\\temp\\pdf\\" + DateTime.Now.ToString(); 
      string text = "Adam Nowak";
      PdfDocument document = new PdfDocument();

      PdfPage page = document.AddPage();
      XGraphics gfx = XGraphics.FromPdfPage(page);
      XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
      XTextFormatter tf = new XTextFormatter(gfx);

      XRect rect = new XRect(40, 100, 250, 232);
      gfx.DrawRectangle(XBrushes.SeaShell, rect);
      tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);
      
      document.Save(filename);
      Process.Start(filename);
    }
    #endregion
  }
}