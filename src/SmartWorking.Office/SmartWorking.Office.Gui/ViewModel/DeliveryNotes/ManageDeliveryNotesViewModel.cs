using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.DeliveryNotes;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.DeliveryNotes
{
  /// <summary>
  ///  View model for <see cref="ManageDeliveryNotes"/> dialog. 
  /// </summary>
  public class ManageDeliveryNotesViewModel : ModalDialogViewModelBase
  {
    private ICommand _cancelDeliveryNoteCommand;
    private ICommand _createDeliveryNoteCommand;
    private ICommand _printDeliveryNoteCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageDeliveryNotesViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageDeliveryNotesViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableDeliveryNote = new SelectableViewModelBase<DeliveryNotePackage>();
      ShowCanceledDeliveryNotes = true;
      LoadDeliveryNotes(string.Empty, ShowCanceledDeliveryNotes);
    }

    #region ShowCanceledDeliveryNotes

    /// <summary>
    /// The <see cref="ShowCanceledDeliveryNotes" /> property's name.
    /// </summary>
    public const string ShowCanceledDeliveryNotesPropertyName = "ShowCanceledDeliveryNotes";

    private bool _showCanceledDeliveryNotes;


    /// <summary>
    /// Gets the ShowCanceledDeliveryNotes property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool ShowCanceledDeliveryNotes
    {
      get { return _showCanceledDeliveryNotes; }

      set
      {
        if (_showCanceledDeliveryNotes == value)
        {
          return;
        }
        _showCanceledDeliveryNotes = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(ShowCanceledDeliveryNotesPropertyName);
      }
    }

    #endregion

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the selectable car.
    /// </summary>
    public SelectableViewModelBase<DeliveryNotePackage> SelectableDeliveryNote { get; private set; }


    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get { return "Wybierz materiał."; }
    }

    #region CancelDeliveryNoteCommand

    public ICommand CancelDeliveryNoteCommand
    {
      get
      {
        if (_cancelDeliveryNoteCommand == null)
          _cancelDeliveryNoteCommand = new RelayCommand(CancelDeliveryNote, CanCancelDeliveryNote);
        return _cancelDeliveryNoteCommand;
      }
    }

    private void CancelDeliveryNote()
    {
      string errorCaption = "Anulowanie WZ'tki!";
      try
      {
        using (IDeliveryNotesService deliveryNotesService = ServiceFactory.GetDeliveryNotesService())
        {
          deliveryNotesService.CanceledDeliveryNote(SelectableDeliveryNote.SelectedItem.DeliveryNote);
        }
        LoadDeliveryNotes(string.Empty, ShowCanceledDeliveryNotes);
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

    private bool CanCancelDeliveryNote()
    {
      return SelectableDeliveryNote.SelectedItem != null && SelectableDeliveryNote.SelectedItem.DeliveryNote != null;
    }

    #endregion

    #region CreateDeliveryNoteCommand

    /// <summary>
    /// Gets the create delivery note command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to creating delivery note.
    /// </remarks>
    public ICommand CreateDeliveryNoteCommand
    {
      get
      {
        if (_createDeliveryNoteCommand == null)
          _createDeliveryNoteCommand = new RelayCommand(CreateDeliveryNote);
        return _createDeliveryNoteCommand;
      }
    }

    /// <summary>
    /// Execution of <see cref="CreateDeliveryNoteCommand"/>.
    /// </summary>
    private void CreateDeliveryNote()
    {
      string errorCaption = "Tworzenie WZ'tki!";
      try
      {
        ModalDialogService.CreateDeliveryNote(ModalDialogService, ServiceFactory);
        LoadDeliveryNotes(string.Empty, ShowCanceledDeliveryNotes);
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

    #endregion

    /// <summary>
    /// Loads the delivery notes.
    /// </summary>
    /// <param name="buildingContains">Used to filtering result. Loaded <see cref="DeliveryNote"/> object will contain this string.</param>
    /// <param name="showDeactivedDeliveryNotes">if set to <c>true</c> then loaded <see cref="DeliveryNote"/> object  will contain <see cref="DeliveryNote"/> which are deactivated; otherwise not.</param>    
    /// <remarks>
    /// Loaded items will be in <see cref="SelectableDeliveryNote"/> object in Items property.
    /// </remarks>
    private void LoadDeliveryNotes(string buildingContains, bool showDeactivedDeliveryNotes)
    {
      string errorCaption = "Wczytywanie danych o WZ'tkach!";
      try
      {
        DeliveryNotePackage selectedItem = SelectableDeliveryNote.SelectedItem;
        using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
        {
          SelectableDeliveryNote.LoadItems(service.GetDeliveryNotePackages(buildingContains, showDeactivedDeliveryNotes));
        }
        if (selectedItem != null)
        {
          DeliveryNotePackage selectionFromItems =
            SelectableDeliveryNote.Items.Where(x => x.DeliveryNote.Id == selectedItem.DeliveryNote.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableDeliveryNote.SelectedItem = selectionFromItems;
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

    #region PrintDeliveryNoteCommand

    /// <summary>
    /// Gets the create delivery note command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to creating delivery note.
    /// </remarks>
    public ICommand PrintDeliveryNoteCommand
    {
      get
      {
        if (_printDeliveryNoteCommand == null)
          _printDeliveryNoteCommand = new RelayCommand(PrintDeliveryNote, CanPrintDeliveryNote);
        return _printDeliveryNoteCommand;
      }
    }

    private bool CanPrintDeliveryNote()
    {
      return SelectableDeliveryNote.SelectedItem != null && SelectableDeliveryNote.SelectedItem.DeliveryNote != null;
    }

    /// <summary>
    /// Execution of <see cref="CreateDeliveryNoteCommand"/>.
    /// </summary>
    private void PrintDeliveryNote()
    {
      string errorCaption = "Drukowanie WZ'tki!";
      try
      {
        PrinterHelper.PrintDeliveryNote(SelectableDeliveryNote.SelectedItem);
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

    #endregion
  }
}