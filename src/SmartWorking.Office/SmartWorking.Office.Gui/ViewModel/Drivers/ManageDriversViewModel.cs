using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Drivers
{
  public class ManageDriversViewModel : ModalDialogViewModelBase
  {
    private ICommand _createMaterialCommand;
    private ICommand _selectMaterialCommand;

    public ManageDriversViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableDriver = new SelectableViewModelBase<Driver>();
      LoadDrivers();
    }

    public SelectableViewModelBase<Driver> SelectableDriver { get; private set; }

    public DialogMode DialogMode { get; set; }

    public ICommand SelectMaterialCommand
    {
      get
      {
        if (_selectMaterialCommand == null)
          _selectMaterialCommand = new RelayCommand(SelectMaterial);
        return _selectMaterialCommand;
      }
    }

    public ICommand CreateMaterialCommand
    {
      get
      {
        if (_createMaterialCommand == null)
          _createMaterialCommand = new RelayCommand(CreateMaterial);
        return _createMaterialCommand;
      }
    }


    public override string Title
    {
      get { return "Wybierz materiał."; }
    }

    private void CreateMaterial()
    {
      ModalDialogService.CreateMaterial(ModalDialogService, ServiceFactory);
    }

    private void LoadDrivers()
    {
      using (IDriversService materialsService = ServiceFactory.GetDriversService())
      {
        SelectableDriver.LoadItems(materialsService.GetDrivers(string.Empty));
      }
    }

    private void SelectMaterial()
    {
      CloseModalDialog();
    }
  }
}