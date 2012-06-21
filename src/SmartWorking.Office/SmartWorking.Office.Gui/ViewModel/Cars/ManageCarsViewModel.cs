using System;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Cars;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Cars
{
  /// <summary>
  ///  View model for <see cref="ManageCars"/> dialog. 
  /// </summary>
  public class ManageCarsViewModel : ModalDialogViewModelBase
  {
    private ICommand _choseCarCommand;
    private ICommand _createCarCommand;
    private ICommand _deleteCarCommand;
    private ICommand _editCarCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageCarsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageCarsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableCar = new SelectableViewModelBase<CarPrimitive>();      
    }

    /// <summary>
    /// Initializes view model properties.
    /// </summary>
    public override void Initialize()
    {
      base.Initialize();
      LoadCars();
    }

    /// <summary>
    /// Gets the selectable car.
    /// </summary>
    public SelectableViewModelBase<CarPrimitive> SelectableCar { get; private set; }

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
      get { return "Wybierz samochód."; }
    }

    /// <summary>
    /// Gets the create car command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to creating car.
    /// </remarks>
    public ICommand CreateCarCommand
    {
      get
      {
        if (_createCarCommand == null)
          _createCarCommand = new RelayCommand(CreateCar);
        return _createCarCommand;
      }
    }

    /// <summary>
    /// Gets the edit car command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to editing car.
    /// </remarks>
    public ICommand EditCarCommand
    {
      get
      {
        if (_editCarCommand == null)
          _editCarCommand = new RelayCommand(EditCar, CanEditCar);
        return _editCarCommand;
      }
    }

    /// <summary>
    /// Gets the delete car command.
    /// </summary>
    public ICommand DeleteCarCommand
    {
      get
      {
        if (_deleteCarCommand == null)
          _deleteCarCommand = new RelayCommand(DeleteCar, CanDeleteCar);
        return _deleteCarCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance [can edit car].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance [can edit car]; otherwise, <c>false</c>.
    /// </returns>
    private bool CanEditCar()
    {
      return SelectableCar != null && SelectableCar.SelectedItem != null;
    }

    /// <summary>
    /// Edits the car.
    /// </summary>
    private void EditCar()
    {
      ModalDialogService.EditCar(ModalDialogService, ServiceFactory, SelectableCar.SelectedItem);
      LoadCars();
    }

    /// <summary>
    /// Determines whether this car (SelectableCar.SelectedItem) can be deleted.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this car doesn't belong to any delivery notes; otherwise, <c>false</c>.
    /// </returns>
    private bool CanDeleteCar()
    {
      if (SelectableCar != null && SelectableCar.SelectedItem != null)
      {
        //TODO: if car is not used in any DeliveryNots then true
      }
      return false;
    }

    /// <summary>
    /// Deletes the car.
    /// </summary>
    private void DeleteCar()
    {
      //TODO:
      LoadCars();
    }


    /// <summary>
    /// Opens dialog to create new car.
    /// </summary>
    private void CreateCar()
    {
      ModalDialogService.CreateCar(ModalDialogService, ServiceFactory);
      LoadCars();
    }

    /// <summary>
    /// Loads the cars.
    /// </summary>
    private void LoadCars()
    {
      string errorCaption = "Pobranie danych o samochodach!";
      try
      {
        CarPrimitive selectedItem = SelectableCar.SelectedItem;
        using (ICarsService service = ServiceFactory.GetCarsService())
        {
          SelectableCar.LoadItems(service.GetCars(string.Empty));
        }
        if (selectedItem != null)
        {
          CarPrimitive selectionFromItems =
            SelectableCar.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableCar.SelectedItem = selectionFromItems;
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

    #region ChoseCarCommand

    /// <summary>
    /// Gets the chose car command.
    /// </summary>
    /// <remarks>Opens dialog to chose Car.</remarks>
    public ICommand ChoseCarCommand
    {
      get
      {
        if (_choseCarCommand == null)
          _choseCarCommand = new RelayCommand(ChoseCar, CanChoseCar);
        return _choseCarCommand;
      }
    }

    /// <summary>
    /// Determines whether <see cref="ChoseCarCommand"/> can be executed.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="ChoseCarCommand"/> can be executed; otherwise, <c>false</c>.
    /// </returns>
    private bool CanChoseCar()
    {
      return SelectableCar.SelectedItem != null && DialogMode == DialogMode.Chose;
    }

    /// <summary>
    /// Executes  <see cref="ChoseCarCommand"/>.
    /// </summary>
    /// <remarks>
    /// Closes modal dialog.
    /// </remarks>
    private void ChoseCar()
    {
      CloseModalDialog();
    }

    #endregion
  }
}