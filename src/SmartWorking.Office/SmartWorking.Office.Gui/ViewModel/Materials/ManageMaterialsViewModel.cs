using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.Materials;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Materials
{
  /// <summary>
  ///  View model for <see cref="ManageMaterials"/> dialog. 
  /// </summary>
  public class ManageMaterialsViewModel : ModalDialogViewModelBase
  {
    private ICommand _choseMaterialCommand;
    private ICommand _createMaterialCommand;
    private ICommand _deleteMaterialCommand;
    private ICommand _editMaterialCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageMaterialsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageMaterialsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableMaterial = new SelectableViewModelBase<MaterialPrimitive>();
      LoadMaterials();
    }

    /// <summary>
    /// Gets the selectable material.
    /// </summary>
    public SelectableViewModelBase<MaterialPrimitive> SelectableMaterial { get; private set; }

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
          _choseMaterialCommand = new RelayCommand(ChoseMaterial, CanChoseMaterial);
        return _choseMaterialCommand;
      }
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
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get { return "Wybierz materiał."; }
    }

    private bool CanChoseMaterial()
    {
      return SelectableMaterial != null && SelectableMaterial.SelectedItem != null && DialogMode == DialogMode.Chose;
    }

    private void ChoseMaterial()
    {
      string errorCaption = "Wybieranie materiału!";
      try
      {
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
      string errorCaption = "Edycja materiału!";
      try
      {
        ModalDialogService.EditMaterial(ModalDialogService, ServiceFactory, SelectableMaterial.SelectedItem);
        LoadMaterials();
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
      string errorCaption = "Usuwanie materiału!";
      try
      {
        //TODO:
        LoadMaterials();
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
    /// Opens dialog to create new material.
    /// </summary>
    private void CreateMaterial()
    {
      string errorCaption = "Tworzenie materiału!";
      try
      {
        ModalDialogService.CreateMaterial(ModalDialogService, ServiceFactory);
        LoadMaterials();
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
    /// Loads the materials.
    /// </summary>
    private void LoadMaterials()
    {
      string errorCaption = "Pobieranie danych o materiałach!";
      try
      {
        MaterialPrimitive selectedItem = SelectableMaterial.SelectedItem;
        using (IMaterialsService materialsService = ServiceFactory.GetMaterialsService())
        {
          SelectableMaterial.LoadItems(materialsService.GetMaterialList(string.Empty));
        }
        if (selectedItem != null)
        {
          MaterialPrimitive selectionFromItems =
            SelectableMaterial.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableMaterial.SelectedItem = selectionFromItems;
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
  }
}