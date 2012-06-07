using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  /// <summary>
  /// View model for <see cref="UpdateContractor"/> dialog. 
  /// </summary>
  public class UpdateContractorViewModel : ModalDialogViewModelBase
  {
    private ICommand _createBuildingCommand;
    private ICommand _deleteBuildingCommand;
    private ICommand _updateBuildingCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateContractorViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateContractorViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets or sets the view mode.
    /// </summary>
    /// <value>
    /// The view mode.
    /// </value>
    public DialogMode ViewMode { get; set; }

    /// <summary>
    /// Gets the create building command.
    /// </summary>
    /// <remarks>This command display dialog where You can create new Building for Contractor.</remarks>
    public ICommand CreateBuildingCommand
    {
      get
      {
        if (_createBuildingCommand == null)
          _createBuildingCommand = new RelayCommand(CreateBuilding);
        return _createBuildingCommand;
      }
    }


    /// <summary>
    /// Gets the update building command.
    /// </summary>
    /// <remarks>This command display dialog where You can update fields of <see cref="SelectedBuilding"/>.</remarks>
    public ICommand UpdateBuildingCommand
    {
      get
      {
        if (_updateBuildingCommand == null)
          _updateBuildingCommand = new RelayCommand(UpdateBuilding, () => { return SelectedBuilding != null; });
        return _updateBuildingCommand;
      }
    }

    /// <summary>
    /// Gets the delete building command.
    /// </summary>
    /// <remarks>Deletes <see cref="SelectedBuilding"/>.</remarks>
    public ICommand DeleteBuildingCommand
    {
      get
      {
        if (_deleteBuildingCommand == null)
          _deleteBuildingCommand = new RelayCommand(DeleteBuilding, () => { return SelectedBuilding != null; });
        return _deleteBuildingCommand;
      }
    }

    /// <summary>
    /// Gets the title of dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (ViewMode == DialogMode.Create)
                 ? "Utwórz nowego kontrahenta."
                 : "Edytuj kontrahenta.";
      }
    }

    #region Contractor property

    /// <summary>
    /// The <see cref="Contractor" /> property's name.
    /// </summary>
    public const string ContractorPropertyName = "Contractor";

    private Contractor _contractor;

    /// <summary>
    /// Gets the Contractor property.
    /// This instance of <see cref="UpdateContractorViewModel"/> provides operation for this Contractor. 
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Contractor Contractor
    {
      get { return _contractor; }

      set
      {
        if (_contractor == value)
        {
          return;
        }
        _contractor = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(ContractorPropertyName);
      }
    }

    #endregion

    #region SelectedBuilding property

    /// <summary>
    /// The <see cref="SelectedBuilding" /> property's name.
    /// </summary>
    public const string SelectedBuildingPropertyName = "SelectedBuilding";

    private Building _selectedBuilding;

    /// <summary>
    /// Gets the SelectedBuilding property.
    /// Building which is selected. All operation on Building are invokes on this object.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Building SelectedBuilding
    {
      get { return _selectedBuilding; }

      set
      {
        if (_selectedBuilding == value)
        {
          return;
        }

        _selectedBuilding = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(SelectedBuildingPropertyName);
      }
    }

    #endregion

    #region CreateOrUpdateContractorConmmand

    private ICommand _createOrUpdateContractorCommand;

    /// <summary>
    /// Gets the create or update contractor command.
    /// </summary>
    /// <remarks>This command opens dialog where Contractor can be created or updated.</remarks>
    public ICommand CreateOrUpdateContractorCommand
    {
      get
      {
        if (_createOrUpdateContractorCommand == null)
          _createOrUpdateContractorCommand = new RelayCommand(UpdateContractor, CanCreateOrUpdateContractor);
        return _createOrUpdateContractorCommand;
      }
    }

    /// <summary>
    /// Validates current fields of Contractor.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if current fields of Contractor is validate; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateOrUpdateContractor()
    {
      //TODO: validate
      return true;
    }

    /// <summary>
    /// Updates the Contractor in the system.
    /// </summary>
    private void UpdateContractor()
    {
      if (ViewMode == DialogMode.Create || ViewMode == DialogMode.Update)
      {
        using (IContractorsService contractorService = ServiceFactory.GetContractorsService())
        {
          contractorService.UpdateContractor(Contractor);
        }
      }
      CloseModalDialog();
    }

    #endregion

    /// <summary>
    /// Displays dialog to create new building.
    /// </summary>
    private void CreateBuilding()
    {
      ModalDialogService.CreateBuilding(ModalDialogService, ServiceFactory, Contractor);
    }

    /// <summary>
    /// Displays dialog to update <see cref="SelectedBuilding"/>.
    /// </summary>
    private void UpdateBuilding()
    {
      ModalDialogService.EditBuilding(ModalDialogService, ServiceFactory, SelectedBuilding);
    }

    /// <summary>
    /// Deletes the <see cref="SelectedBuilding"/>.
    /// </summary>
    private void DeleteBuilding()
    {
      //TODO:
    }
  }
}