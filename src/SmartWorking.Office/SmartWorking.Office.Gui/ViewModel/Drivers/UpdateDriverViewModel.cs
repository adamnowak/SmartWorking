using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Drivers
{
  /// <summary>
  /// View model for <see cref="UpdateDriver"/> dialog. 
  /// </summary>
  public class UpdateDriverViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateDriverCommand;

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
          _createOrUpdateDriverCommand = new RelayCommand(UpdateDriver, CanUpdateDriver);
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

    #region Driver

    /// <summary>
    /// The <see cref="Driver" /> property's name.
    /// </summary>
    public const string DriverPropertyName = "Driver";

    private Driver _driver;

    /// <summary>
    /// Gets the Driver property.
    /// Driver which will be created or updated.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Driver Driver
    {
      get { return _driver; }

      set
      {
        if (_driver == value)
        {
          return;
        }
        _driver = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(DriverPropertyName);
      }
    }

    #endregion

    /// <summary>
    /// Determines whether <see cref="CreateOrUpdateDriverCommand"/> can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="CreateOrUpdateDriverCommand"/> can be execute; otherwise, <c>false</c>.
    /// </returns>
    private bool CanUpdateDriver()
    {
      //TODO: validate
      return true;
    }


    /// <summary>
    /// Creates or updates the driver in the system.
    /// </summary>
    private void UpdateDriver()
    {
      if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
      {
        using (IDriversService service = ServiceFactory.GetDriversService())
        {
          service.UpdateDriver(Driver);
        }
      }
      CloseModalDialog();
    }
  }
}