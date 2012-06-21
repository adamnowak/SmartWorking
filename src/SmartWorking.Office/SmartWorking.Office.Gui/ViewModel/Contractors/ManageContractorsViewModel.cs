using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  /// <summary>
  /// View model for <see cref="ManageContractors"/> dialog. 
  /// </summary>
  public class ManageContractorsViewModel : ModalDialogViewModelBase
  {
    private ICommand _createContractorCommand;
    private ICommand _editContractorCommand;
    private ICommand _deleteContractorCommand;
    private ICommand _createBuildingCommand;
    private ICommand _editBuildingCommand;
    private ICommand _deleteBuildingCommand;
    private ICommand _choseBuildingCommand;
    private ICommand _createDeliveryNoteCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageContractorsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageContractorsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableContractor = new SelectableViewModelBase<ContractorAndBuildingsPackage>();
      LoadContractors();
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the selectable contractor. List of contractors and one which is selected.
    /// </summary>
    public SelectableViewModelBase<ContractorAndBuildingsPackage> SelectableContractor { get; private set; }

    /// <summary>
    /// Gets or sets the selected building.
    /// </summary>
    /// <value>
    /// The selected building.
    /// </value>
    public BuildingPrimitive SelectedBuilding { get; set; }

    /// <summary>
    /// Gets the create contractor command.
    /// </summary>
    /// <remarks>Opens dialog to creating <see cref="Contractor"/>.</remarks>
    public ICommand CreateContractorCommand
    {
      get
      {
        if (_createContractorCommand == null)
          _createContractorCommand = new RelayCommand(CreateContractor);
        return _createContractorCommand;
      }
    }

    /// <summary>
    /// Creates the contractor.
    /// </summary>
    private void CreateContractor()
    {
      ModalDialogService.CreateContractor(ModalDialogService, ServiceFactory);
      LoadContractors();
    }

    #region ChoseBuildingCommand
    /// <summary>
    /// Gets the chose building command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="Contractor"/> object where user can chose Building.</remarks>
    public ICommand ChoseBuildingCommand
    {
      get
      {
        if (_choseBuildingCommand == null)
          _choseBuildingCommand = new RelayCommand(ChoseBuilding, CanChoseBuilding);
        return _choseBuildingCommand;
      }
    }

    /// <summary>
    /// Determines whether <see cref="ChoseBuildingCommand"/> can be executed.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="ChoseBuildingCommand"/> can be executed; otherwise, <c>false</c>.
    /// </returns>
    private bool CanChoseBuilding()
    {
      return SelectedBuilding != null && DialogMode == DialogMode.ChoseSubItem;
    }

    /// <summary>
    /// Executes  <see cref="ChoseBuildingCommand"/>.
    /// </summary>
    /// <remarks>
    /// Closes modal dialog.
    /// </remarks>
    private void ChoseBuilding()
    {
      CloseModalDialog();
    }
    #endregion

    #region CreateDeliveryNoteCommand
    /// <summary>
    /// Gets the create delivery note command.
    /// </summary>
    /// <remarks>Opens dialog to create <see cref="DeliveryNote"/> object.</remarks>
    public ICommand CreateDeliveryNoteCommand
    {
      get
      {
        if (_createDeliveryNoteCommand == null)
          _createDeliveryNoteCommand = new RelayCommand(CreateDeliveryNote, CanCreateDeliveryNote);
        return _createDeliveryNoteCommand;
      }
    }

    /// <summary>
    /// Determines whether <see cref="CreateDeliveryNoteCommand"/> can be executed.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="CreateDeliveryNoteCommand"/> can be executed; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateDeliveryNote()
    {
      return SelectableContractor.SelectedItem != null && SelectedBuilding != null && DialogMode != DialogMode.ChoseSubItem;
    }

    /// <summary>
    /// Executes  <see cref="ChoseBuildingCommand"/>.
    /// </summary>
    /// <remarks>
    /// Closes modal dialog.
    /// </remarks>
    private void CreateDeliveryNote()
    {
      BuildingPrimitive building = SelectedBuilding;
      ContractorPrimitive contractor = SelectableContractor.SelectedItem.Contractor;
      //todo: pass to CreateDeliveryNote building and contractor or create new package
      ModalDialogService.CreateDeliveryNote(ModalDialogService, ServiceFactory, building);
    }
    #endregion
    
    /// <summary>
    /// Gets the edit contractor command.
    /// </summary>
    /// <remarks>Opens dialog to editing <see cref="Contractor"/>.</remarks>
    public ICommand EditContractorCommand
    {
      get
      {
        if (_editContractorCommand == null)
          _editContractorCommand = new RelayCommand(
            EditContractor, 
            () => SelectableContractor != null && SelectableContractor.SelectedItem != null);
        return _editContractorCommand;
      }
    }

    private void EditContractor()
    {
      ModalDialogService.EditContractor(ModalDialogService, ServiceFactory, SelectableContractor.SelectedItem.Contractor);
      LoadContractors();
    }

    /// <summary>
    /// Gets the delete contractor command.
    /// </summary>
    /// <remarks>
    /// Deletes <see cref="Contractor"/> if user confirmed action. 
    /// Command cannot be execute if any Building of this Contractor is connected with any <see cref="DeliveryNote"/>.
    /// </remarks>
    public ICommand DeleteContractorCommand
    {
      get
      {
        if (_deleteContractorCommand == null)
          _deleteContractorCommand = new RelayCommand(DeleteContractor,
            CanDeleteContractor);
        return _deleteContractorCommand;
      }
    }

    private void DeleteContractor()
    {
      //TODO: 
      //MessageBox with question
      //if yes deletes all building of this contractor and this contractor
    }

    private bool CanDeleteContractor()
    {
      if (SelectableContractor != null && SelectableContractor.SelectedItem != null)
      {
        //TODO: return true if all building of this contractor can be deleted.
      }
      return false;
    }



    /// <summary>
    /// Gets the create building command.
    /// </summary>
    /// <remarks>Opens dialog to creating <see cref="Building"/>.</remarks>
    public ICommand CreateBuildingCommand
    {
      get
      {
        if (_createBuildingCommand == null)
          _createBuildingCommand = new RelayCommand(CreateBuilding,
            () => SelectableContractor != null && SelectableContractor.SelectedItem != null);
        return _createBuildingCommand;
      }
    }

    private void CreateBuilding()
    {
      ModalDialogService.CreateBuilding(ModalDialogService, ServiceFactory, SelectableContractor.SelectedItem.Contractor);
      LoadContractors();
    }

    /// <summary>
    /// Gets the edit building command.
    /// </summary>
    /// <remarks>Opens dialog to editing <see cref="Building"/>.</remarks>
    public ICommand EditBuildingCommand
    {
      get
      {
        if (_editBuildingCommand == null)
          _editBuildingCommand = new RelayCommand(
            EditBuilding,
            () => SelectableContractor != null && SelectableContractor.SelectedItem != null && SelectedBuilding != null);
        return _editBuildingCommand;
      }
    }

    private void EditBuilding()
    {
      ModalDialogService.EditBuilding(ModalDialogService, ServiceFactory, SelectedBuilding);
      LoadContractors();
    }

    /// <summary>
    /// Gets the delete building command.
    /// </summary>
    /// <remarks>
    /// Deletes <see cref="Building"/> if user confirmed action. 
    /// Command cannot be execute if any <see cref="DeliveryNote"/> exists for this Building.
    /// </remarks>
    public ICommand DeleteBuildingCommand
    {
      get
      {
        if (_deleteBuildingCommand == null)
          _deleteBuildingCommand = new RelayCommand(DeleteBuilding,
            CanDeleteBuilding);
        return _deleteBuildingCommand;
      }
    }

    private void DeleteBuilding()
    {
      //TODO: 
      //MessageBox with question
      //if any <see cref="DeliveryNote"/> exists for this Building.
    }

    private bool CanDeleteBuilding()
    {
      if (SelectableContractor != null && SelectableContractor.SelectedItem != null && SelectedBuilding != null)
      {
        //TODO: return true if building of this contractor can be deleted.
      }
      return false;
    }

    public override string Title
    {
      get { return "Wybierz kontrahenta."; }
    }

    

    private void LoadContractors()
    {
      string errorCaption = "Pobranie danych o kontrahentach!";
      try
      {
        ContractorAndBuildingsPackage selectedItem = SelectableContractor.SelectedItem;
        using (IContractorsService contractorService = ServiceFactory.GetContractorsService())
        {
          SelectableContractor.LoadItems(contractorService.GetContractorAndBuildingsPackage(string.Empty));
        }
        if (selectedItem != null && selectedItem.Contractor != null)
        {
          ContractorAndBuildingsPackage selectionFromItems =
            SelectableContractor.Items.Where(x => x.Contractor.Id == selectedItem.Contractor.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableContractor.SelectedItem = selectionFromItems;
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