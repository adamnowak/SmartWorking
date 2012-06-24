using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.Drivers;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Drivers
{
  /// <summary>
  ///  View model for <see cref="ManageDrivers"/> dialog. 
  /// </summary>
  public class ManageDriversViewModel : ModalDialogViewModelBase
  {
    private ICommand _choseDriverCommand;
    private ICommand _createDriverCommand;
    private ICommand _deleteDriverCommand;
    private ICommand _editDriverCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageDriversViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageDriversViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableDriver = new SelectableViewModelBase<DriverPrimitive>();
      LoadDrivers();
    }

    /// <summary>
    /// Gets the selectable driver.
    /// </summary>
    public SelectableViewModelBase<DriverPrimitive> SelectableDriver { get; private set; }

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
      get { return "Wybierz kierowcę."; }
    }

    /// <summary>
    /// Gets the create driver command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to creating driver.
    /// </remarks>
    public ICommand CreateDriverCommand
    {
      get
      {
        if (_createDriverCommand == null)
          _createDriverCommand = new RelayCommand(CreateDriver);
        return _createDriverCommand;
      }
    }

    /// <summary>
    /// Gets the edit driver command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to editing driver.
    /// </remarks>
    public ICommand EditDriverCommand
    {
      get
      {
        if (_editDriverCommand == null)
          _editDriverCommand = new RelayCommand(EditDriver, CanEditDriver);
        return _editDriverCommand;
      }
    }

    /// <summary>
    /// Gets the delete driver command.
    /// </summary>
    public ICommand DeleteDriverCommand
    {
      get
      {
        if (_deleteDriverCommand == null)
          _deleteDriverCommand = new RelayCommand(DeleteDriver, CanDeleteDriver);
        return _deleteDriverCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance [can edit driver].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance [can edit driver]; otherwise, <c>false</c>.
    /// </returns>
    private bool CanEditDriver()
    {
      return SelectableDriver != null && SelectableDriver.SelectedItem != null;
    }

    /// <summary>
    /// Edits the driver.
    /// </summary>
    private void EditDriver()
    {
      string errorCaption = "Edycja danych o kierowcy!";
      try
      {
        ModalDialogService.EditDriver(ModalDialogService, ServiceFactory, SelectableDriver.SelectedItem);
        LoadDrivers();
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

    /// <summary>
    /// Determines whether this driver (SelectableDriver.SelectedItem) can be deleted.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this driver doesn't belong to any delivery notes; otherwise, <c>false</c>.
    /// </returns>
    private bool CanDeleteDriver()
    {
      if (SelectableDriver != null && SelectableDriver.SelectedItem != null)
      {
        //TODO: if driver is not used in any DeliveryNots then true
      }
      return false;
    }

    /// <summary>
    /// Deletes the driver.
    /// </summary>
    private void DeleteDriver()
    {
      string errorCaption = "Usuwanie danych o kierowcy!";
      try
      {
        //TODO:
        LoadDrivers();
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


    /// <summary>
    /// Opens dialog to create new driver.
    /// </summary>
    private void CreateDriver()
    {
      string errorCaption = "Tworzenie danych o kierowcy!";
      try
      {
        ModalDialogService.CreateDriver(ModalDialogService, ServiceFactory);
        LoadDrivers();
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

    /// <summary>
    /// Loads the drivers.
    /// </summary>
    private void LoadDrivers()
    {
      string errorCaption = "Wczytywanie danych o kierowcach!";
      try
      {
        DriverPrimitive selectedItem = SelectableDriver.SelectedItem;
        using (IDriversService service = ServiceFactory.GetDriversService())
        {
          SelectableDriver.LoadItems(service.GetDrivers(string.Empty));
        }
        if (selectedItem != null)
        {
          DriverPrimitive selectionFromItems =
            SelectableDriver.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableDriver.SelectedItem = selectionFromItems;
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

    #region ChoseDriverCommand

    /// <summary>
    /// Gets the chose driver command.
    /// </summary>
    /// <remarks>Opens dialog to chose Driver.</remarks>
    public ICommand ChoseDriverCommand
    {
      get
      {
        if (_choseDriverCommand == null)
          _choseDriverCommand = new RelayCommand(ChoseDriver, CanChoseDriver);
        return _choseDriverCommand;
      }
    }

    /// <summary>
    /// Determines whether <see cref="ChoseDriverCommand"/> can be executed.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="ChoseDriverCommand"/> can be executed; otherwise, <c>false</c>.
    /// </returns>
    private bool CanChoseDriver()
    {
      return SelectableDriver.SelectedItem != null && DialogMode == DialogMode.Chose;
    }

    /// <summary>
    /// Executes  <see cref="ChoseDriverCommand"/>.
    /// </summary>
    /// <remarks>
    /// Closes modal dialog.
    /// </remarks>
    private void ChoseDriver()
    {
      CloseModalDialog();
    }

    #endregion
  }
}