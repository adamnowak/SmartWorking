using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Materials;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Materials
{
  /// <summary>
  ///  View model for <see cref="ManageMaterials"/> dialog. 
  /// </summary>
  public class ManageMaterialsViewModel : ModalDialogViewModelBase
  {
    private ICommand _createMaterialCommand;
    private ICommand _editMaterialCommand;
    private ICommand _deleteMaterialCommand;
    private ICommand _choseMaterialCommand;

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

    public ICommand ChoseMaterialCommand
    {
      get
      {
        if (_choseMaterialCommand == null)
          _choseMaterialCommand = new RelayCommand(ChoseMaterial);
        return _choseMaterialCommand;
      }
    }

    private void ChoseMaterial()
    {
      CloseModalDialog();
    }

    /// <summary>
    /// Gets the create material command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to creating material.
    /// </remarks>
    public ICommand CreateMaterialCommand
    {
      get
      {
        if (_createMaterialCommand == null)
          _createMaterialCommand = new RelayCommand(CreateMaterial);
        return _createMaterialCommand;
      }
    }

    /// <summary>
    /// Gets the edit material command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to editing material.
    /// </remarks>
    public ICommand EditMaterialCommand
    {
      get
      {
        if (_editMaterialCommand == null)
          _editMaterialCommand = new RelayCommand(EditMaterial, CanEditMaterial);
        return _editMaterialCommand;
      }
    }

    /// <summary>
    /// Gets the delete material command.
    /// </summary>
    public ICommand DeleteMaterialCommand
    {
      get
      {
        if (_deleteMaterialCommand == null)
          _deleteMaterialCommand = new RelayCommand(DeleteMaterial, CanDeleteMaterial);
        return _deleteMaterialCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance [can edit material].
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this instance [can edit material]; otherwise, <c>false</c>.
    /// </returns>
    private bool CanEditMaterial()
    {
      return SelectableMaterial != null && SelectableMaterial.SelectedItem != null;
    }

    /// <summary>
    /// Edits the material.
    /// </summary>
    private void EditMaterial()
    {
      ModalDialogService.EditMaterial(ModalDialogService, ServiceFactory, SelectableMaterial.SelectedItem);
      LoadMaterials();
    }

    /// <summary>
    /// Determines whether this material (SelectableMaterial.SelectedItem) can be deleted.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if this material doesn't belong to any delivery notes; otherwise, <c>false</c>.
    /// </returns>
    private bool CanDeleteMaterial()
    {
      if (SelectableMaterial != null && SelectableMaterial.SelectedItem != null)
      {
        //TODO: if material is not used in any DeliveryNots then true
      }
      return false;
    }

    /// <summary>
    /// Deletes the material.
    /// </summary>
    private void DeleteMaterial()
    {
      //TODO:
      LoadMaterials();
    }


    /// <summary>
    /// Opens dialog to create new material.
    /// </summary>
    private void CreateMaterial()
    {
      ModalDialogService.CreateMaterial(ModalDialogService, ServiceFactory);
      LoadMaterials();
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