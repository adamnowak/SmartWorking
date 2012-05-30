using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Materials
{
  public enum SelectMaterialViewMode
  {
    SelectMaterial, 
    SelectBuilding
  }

  public class SelectMaterialViewModel : ModalDialogViewModelBase
  {
    public SelectableViewModelBase<Material> SelectableMaterial { get; private set; }

    public SelectMaterialViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableMaterial = new SelectableViewModelBase<Material>();
      LoadMaterials();
    }

    public SelectMaterialViewMode ViewMode { get; set; }

    private void LoadMaterials()
    {
      using (var materialsService = ServiceFactory.GetMaterialsService())
      {
        SelectableMaterial.LoadItems(materialsService.GetMaterials());
      }
    }

    private ICommand _selectMaterialCommand;

    public ICommand SelectMaterialCommand
    {
      get
      {
        if (_selectMaterialCommand == null)
          _selectMaterialCommand = new RelayCommand(SelectMaterial);
        return _selectMaterialCommand;
      }
    }

    private void SelectMaterial()
    {
      CloaseModalDialog();
    }

    


    public override string Title
    {
      get { return "Wybierz materiał."; }
    }


  }
}