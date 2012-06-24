using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Cars
{
  /// <summary>
  /// View model for <see cref="CreateOrUpdateCar"/> dialog. 
  /// </summary>
  public class UpdateCarViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateCarCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCarViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateCarViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
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
    /// Gets the create or update car command.
    /// </summary>
    /// <remarks>
    /// Opens dialog for creating or editing Car.
    /// </remarks>
    public ICommand CreateOrUpdateCarCommand
    {
      get
      {
        if (_createOrUpdateCarCommand == null)
          _createOrUpdateCarCommand = new RelayCommand(CreateOrUpdateCar, CanCreateOrUpdateCar);
        return _createOrUpdateCarCommand;
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
                 ? "Utwórz nowy samochód."
                 : "Edytuj samochód.";
      }
    }

    #region Car

    /// <summary>
    /// The <see cref="Car" /> property's name.
    /// </summary>
    public const string CarPropertyName = "Car";

    private CarPrimitive _car;

    /// <summary>
    /// Gets the Car property.
    /// Car which will be created or updated.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public CarPrimitive Car
    {
      get { return _car; }

      set
      {
        if (_car == value)
        {
          return;
        }
        _car = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(CarPropertyName);
      }
    }

    #endregion

    /// <summary>
    /// Determines whether <see cref="CreateOrUpdateCarCommand"/> can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="CreateOrUpdateCarCommand"/> can be execute; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateOrUpdateCar()
    {
      //TODO: validate
      return true;
    }


    /// <summary>
    /// Creates or updates the car in the system.
    /// </summary>
    private void CreateOrUpdateCar()
    {
      string errorCaption = "Tworzenie danych o samochodzie!";
      try
      {
        if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
        {
          using (ICarsService service = ServiceFactory.GetCarsService())
          {
            service.UpdateCar(Car);
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