using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.DeliveryNotes;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.DeliveryNotes
{
  /// <summary>
  ///  View model for <see cref="UpdateDeliveryNote"/> dialog. 
  /// </summary>
  public class UpdateDeliveryNoteViewModel : ModalDialogViewModelBase
  {
    private ICommand _createAndPrintDeliveryNoteCommand;
    private ICommand _selectBuildingCommand;
    private ICommand _selectCarCommand;
    private ICommand _selectDriverCommand;
    private ICommand _selectRecipeCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateDeliveryNoteViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateDeliveryNoteViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nową WZ'tkę."
                 : "Edytuj WZ'tkę.";
      }
    }

    #region DeliveryNotePackage property

    /// <summary>
    /// The <see cref="DeliveryNotePackage" /> property's name.
    /// </summary>
    public const string DeliveryNotePropertyName = "DeliveryNotePackage";

    private DeliveryNotePackage _deliveryNotePackage;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public DeliveryNotePackage DeliveryNotePackage
    {
      get
      {
        if (_deliveryNotePackage == null)
        {
          _deliveryNotePackage = new DeliveryNotePackage();
        }
        return _deliveryNotePackage;
      }

      set
      {
        if (_deliveryNotePackage == value)
        {
          return;
        }
        _deliveryNotePackage = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(DeliveryNotePropertyName);
      }
    }

    #endregion

    #region SelectBuildingCommand

    /// <summary>
    /// Gets the select building command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to selecting building.
    /// </remarks>
    public ICommand SelectBuildingCommand
    {
      get
      {
        if (_selectBuildingCommand == null)
          _selectBuildingCommand = new RelayCommand(SelectBuilding);
        return _selectBuildingCommand;
      }
    }

    private void SelectBuilding()
    {
      string errorCaption = "Wybieranie WZ'tki!";
      try
      {
        DeliveryNotePackage.BuildingAndContractor =
          ModalDialogService.SelectBuildingAndContractorPackage(ModalDialogService, ServiceFactory);
        RaisePropertyChanged("DeliveryNotePackage");
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

    #region SelectRecipeCommand

    public ICommand SelectRecipeCommand
    {
      get
      {
        if (_selectRecipeCommand == null)
          _selectRecipeCommand = new RelayCommand(SelectRecipe);
        return _selectRecipeCommand;
      }
    }

    private void SelectRecipe()
    {
      string errorCaption = "Wybieranie recepty!";
      try
      {
        DeliveryNotePackage.Recipe = ModalDialogService.SelectRecipe(ModalDialogService, ServiceFactory);
        RaisePropertyChanged("DeliveryNotePackage");
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

    #region CreateAndPrintDeliveryNoteCommand

    public ICommand CreateAndPrintDeliveryNoteCommand
    {
      get
      {
        if (_createAndPrintDeliveryNoteCommand == null)
          _createAndPrintDeliveryNoteCommand = new RelayCommand(CreateAndPrintDeliveryNote,
                                                                CanCreateAndPrintDeliveryNote);
        return _createAndPrintDeliveryNoteCommand;
      }
    }

    private bool CanCreateAndPrintDeliveryNote()
    {
      return DeliveryNotePackage.BuildingAndContractor != null &&
             DeliveryNotePackage.BuildingAndContractor.Building != null &&
             DeliveryNotePackage.BuildingAndContractor.Client != null &&
             DeliveryNotePackage.CarAndDriver != null && DeliveryNotePackage.Driver != null && DeliveryNotePackage.Recipe != null;
    }

    private void CreateAndPrintDeliveryNote()
    {
      string errorCaption = "Zatwierdzanie i drukowanie WZ'tki!";
      try
      {
        if (DeliveryNotePackage == null)
        {
          throw new SmartWorkingException("DeliveryNotePackage is not initialized.");
        }
        if (DeliveryNotePackage.BuildingAndContractor == null)
        {
          throw new SmartWorkingException("Building and contractor is not defined.");
        }
        if (DeliveryNotePackage.CarAndDriver == null)
        {
          throw new SmartWorkingException("Car is not defined.");
        }
        if (DeliveryNotePackage.Driver == null)
        {
          throw new SmartWorkingException("Driver is not defined.");
        }
        if (DeliveryNotePackage.Recipe == null)
        {
          throw new SmartWorkingException("Recipe is not defined.");
        }


        using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
        {
          int deliveryNoteId = service.UpdateDeliveryNote(DeliveryNotePackage.GetDeliveryNotePrimitiveWithReference());
          DeliveryNotePackage.DeliveryNote.Id = deliveryNoteId;
        }

        PrintDeliveryNote(DeliveryNotePackage);

        CloseModalDialog();
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

    #region SelectDriverCommand

    public ICommand SelectDriverCommand
    {
      get
      {
        if (_selectDriverCommand == null)
          _selectDriverCommand = new RelayCommand(SelectDriver);
        return _selectDriverCommand;
      }
    }

    private void SelectDriver()
    {
      string errorCaption = "Wybranie kierowcy!";
      try
      {
        CarAndDriverPackage carAndDriverPackage = ModalDialogService.SelectDriver(ModalDialogService, ServiceFactory);
        DeliveryNotePackage.Driver = carAndDriverPackage.Driver;
        if (DeliveryNotePackage.CarAndDriver == null)
        {
          DeliveryNotePackage.CarAndDriver = carAndDriverPackage.Car;
        }
        RaisePropertyChanged("DeliveryNotePackage");
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

    #region SelectCarCommand

    public ICommand SelectCarCommand
    {
      get
      {
        if (_selectCarCommand == null)
          _selectCarCommand = new RelayCommand(SelectCar);
        return _selectCarCommand;
      }
    }

    private void SelectCar()
    {
      string errorCaption = "Wybranie samochodu!";
      try
      {
        DeliveryNotePackage.CarAndDriver = ModalDialogService.SelectCar(ModalDialogService, ServiceFactory);
        RaisePropertyChanged("DeliveryNotePackage");
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

    #region PrintDeliveryNote

    private void PrintDeliveryNote(DeliveryNotePackage deliveryNotePackage)
    {
      string errorCaption = "Drukowanie WZ'tki!";
      try
      {
        PrinterHelper.PrintDeliveryNote(deliveryNotePackage);
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

  public class SmartWorkingException : Exception
  {
    public SmartWorkingException(string message)
      : base(message)
    {
    }
  }
}