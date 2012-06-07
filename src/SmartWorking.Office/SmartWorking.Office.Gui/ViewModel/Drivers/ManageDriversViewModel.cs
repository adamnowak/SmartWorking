using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Drivers
{

  public class ManageDriversViewModel : ModalDialogViewModelBase
  {
    private ICommand _selectMaterialCommand;
    private ICommand _createMaterialCommand;

    public ManageDriversViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableMaterial = new SelectableViewModelBase<Material>();
      LoadMaterials();
    }

    public SelectableViewModelBase<Material> SelectableMaterial { get; private set; }

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

    private void CreateMaterial()
    {
      ModalDialogService.CreateMaterial(ModalDialogService, ServiceFactory);

    }


    public override string Title
    {
      get { return "Wybierz materiał."; }
    }

    private void LoadMaterials()
    {
      using (IMaterialsService materialsService = ServiceFactory.GetMaterialsService())
      {
        SelectableMaterial.LoadItems(materialsService.GetMaterials(string.Empty));
      }
    }

    private void SelectMaterial()
    {
      CloseModalDialog();
    }
  }
}