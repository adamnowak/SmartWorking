using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Drivers
{
  /// <summary>
  /// View model for <see cref="CreateOrUpdateDriver"/> dialog. 
  /// </summary>
  public class UpdateDriverViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateDriverCommand;
    private ICommand _selectCarCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateDriverViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateDriverViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
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
    /// Gets the create or update driver command.
    /// </summary>
    /// <remarks>
    /// Opens dialog for creating or editing Driver.
    /// </remarks>
    public ICommand CreateOrUpdateDriverCommand
    {
      get
      {
        if (_createOrUpdateDriverCommand == null)
          _createOrUpdateDriverCommand = new RelayCommand(CreateOrUpdateDriver, CanCreateOrUpdateDriver);
        return _createOrUpdateDriverCommand;
      }
    }

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nowego kierowcę."
                 : "Edytuj kierowcę.";
      }
    }



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
        CarAndDriver.Car = ModalDialogService.SelectCar(ModalDialogService, ServiceFactory);
        RaisePropertyChanged(DriverAndCarPropertyName);
        //RaisePropertyChanged(DriverAndCarPropertyName + ".Car");
        //RaisePropertyChanged("Car");
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

    #region CarAndDriver

    /// <summary>
    /// The <see cref="CarAndDriver" /> property's name.
    /// </summary>
    public const string DriverAndCarPropertyName = "CarAndDriver";

    private CarAndDriverPackage _carAndDriver;
    

    /// <summary>
    /// Gets the Driver property.
    /// Driver which will be created or updated.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public CarAndDriverPackage CarAndDriver
    {
      get { return _carAndDriver; }

      set
      {
        if (_carAndDriver == value)
        {
          return;
        }
        _carAndDriver = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(DriverAndCarPropertyName);
      }
    }

    #endregion

    /// <summary>
    /// Determines whether <see cref="CreateOrUpdateDriverCommand"/> can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="CreateOrUpdateDriverCommand"/> can be execute; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateOrUpdateDriver()
    {
      //TODO: validate
      return true;
    }


    /// <summary>
    /// Creates or updates the driver in the system.
    /// </summary>
    private void CreateOrUpdateDriver()
    {
      string errorCaption = "Zatwierdzanie danych kierowcy!";
      try
      {
        if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
        {
          using (IDriversService service = ServiceFactory.GetDriversService())
          {
            service.UpdateDriver(CarAndDriver.Driver);
          }
        }
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
  }
}