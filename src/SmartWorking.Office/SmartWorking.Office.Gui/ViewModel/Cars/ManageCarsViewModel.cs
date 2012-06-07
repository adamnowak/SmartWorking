using System;
using System.Linq;
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
    private ICommand _createCarCommand;
    private ICommand _editCarCommand;
    private ICommand _deleteCarCommand;


    public ManageCarsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableCar = new SelectableViewModelBase<Car>();
      LoadCars();
    }

    public SelectableViewModelBase<Car> SelectableCar { get; private set; }

    public DialogMode DialogMode { get; set; }

    public ICommand CreateCarCommand
    {
      get
      {
        if (_createCarCommand == null)
          _createCarCommand = new RelayCommand(CreateCar);
        return _createCarCommand;
      }
    }

    public ICommand EditCarCommand
    {
      get
      {
        if (_editCarCommand == null)
          _editCarCommand = new RelayCommand(EditCar, CanEditCar);
        return _editCarCommand;
      }
    }

    private bool CanEditCar()
    {
      return SelectableCar != null && SelectableCar.SelectedItem != null;
    }

    private void EditCar()
    {
      ModalDialogService.EditCar(ModalDialogService, ServiceFactory, SelectableCar.SelectedItem);
      LoadCars();
    }

    public ICommand DeleteCarCommand
    {
      get
      {
        if (_deleteCarCommand == null)
          _deleteCarCommand = new RelayCommand(DeleteCar, CanDeleteCar);
        return _deleteCarCommand;
      }
    }

    private bool CanDeleteCar()
    {
      if (SelectableCar != null && SelectableCar.SelectedItem != null)
      {
        //TODO: if car is not used in any DeliveryNots then true
      }
      return false;
    }

    private void DeleteCar()
    {
      //TODO:
      LoadCars();
    }


    public override string Title
    {
      get { return "Wybierz samochód."; }
    }

    private void CreateCar()
    {
      ModalDialogService.CreateCar(ModalDialogService, ServiceFactory);
      LoadCars();
    }

    private void LoadCars()
    {
      Car selectedItem = SelectableCar.SelectedItem;
      using (ICarsService service = ServiceFactory.GetCarsService())
      {
        SelectableCar.LoadItems(service.GetCars(string.Empty));
      }
      if (selectedItem != null)
      {
        Car selectionFromItems =
          SelectableCar.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
        if (selectionFromItems != null)
          SelectableCar.SelectedItem = selectionFromItems;
      }
      
    }

    
  }
}