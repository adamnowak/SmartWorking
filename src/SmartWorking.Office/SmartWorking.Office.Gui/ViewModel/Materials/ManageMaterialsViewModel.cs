using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Materials
{
  public class ManageMaterialsViewModel : ModalDialogViewModelBase
  {
    private ICommand _createMaterialCommand;
    private ICommand _selectMaterialCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageMaterialsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageMaterialsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableMaterial = new SelectableViewModelBase<Material>();
      LoadMaterials();
    }

    /// <summary>
    /// Gets the selectable material.
    /// </summary>
    public SelectableViewModelBase<Material> SelectableMaterial { get; private set; }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
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

    private void SelectMaterial()
    {
      CloseModalDialog();
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

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get { return "Wybierz materiał."; }
    }

    

    /// <summary>
    /// Loads the materials.
    /// </summary>
    private void LoadMaterials()
    {
      Material selectedItem = SelectableMaterial.SelectedItem;
      using (IMaterialsService materialsService = ServiceFactory.GetMaterialsService())
      {
        SelectableMaterial.LoadItems(materialsService.GetMaterials(string.Empty));
      }
      if (selectedItem != null)
      {
        Material selectionFromItems =
          SelectableMaterial.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
        if (selectionFromItems != null)
          SelectableMaterial.SelectedItem = selectionFromItems;
      }
      
    }

    
  }
}