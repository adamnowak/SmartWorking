using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  /// <summary>
  ///  View model for <see cref="UpdateBuilding"/> dialog. 
  /// </summary>
  public class UpdateBuildingViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateBuildingCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateBuildingViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateBuildingViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the create or updat building command.
    /// </summary>
    public ICommand CreateOrUpdatBuildingCommand
    {
      get
      {
        if (_createOrUpdateBuildingCommand == null)
          _createOrUpdateBuildingCommand = new RelayCommand(CreateOrUpdatBuilding, CanCreateOrUpdatBuilding);
        return _createOrUpdateBuildingCommand;
      }
    }

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nową budowę."
                 : "Edytuj budowę.";
      }
    }

    //#region Contractor property

    ///// <summary>
    ///// The <see cref="Contractor" /> property's name.
    ///// </summary>
    //public const string ContractorPropertyName = "Contractor";

    //private Contractor _contractor;

    ///// <summary>
    ///// Gets the Contractor property.
    ///// TODO Update documentation:
    ///// Changes to that property's value raise the PropertyChanged event. 
    ///// This property's value is broadcasted by the Messenger's default instance when it changes.
    ///// </summary>
    //public Contractor Contractor
    //{
    //  get { return _contractor; }

    //  set
    //  {
    //    if (_contractor == value)
    //    {
    //      return;
    //    }
    //    _contractor = value;

    //    // Update bindings, no broadcast
    //    RaisePropertyChanged(ContractorPropertyName);
    //  }
    //}

    //#endregion

    #region Building property

    /// <summary>
    /// The <see cref="Building" /> property's name.
    /// </summary>
    public const string BuildingPropertyName = "Building";

    private BuildingPrimitive _building;

    /// <summary>
    /// Gets the Building property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public BuildingPrimitive Building
    {
      get { return _building; }

      set
      {
        if (_building == value)
        {
          return;
        }
        _building = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(BuildingPropertyName);
      }
    }

    #endregion

    private bool CanCreateOrUpdatBuilding()
    {
      if ( Building == null)
        return false;
      //TODO: validate
      return true;
    }


    private void CreateOrUpdatBuilding()
    {
      if (Building == null)
        throw new Exception(); //TODO:
      
      using (IContractorsService contractorService = ServiceFactory.GetContractorsService())
      {
        if (DialogMode == DialogMode.Create)
        {
          if (Building.Id > 0)
            throw new Exception("Building has wrong Id (>0).");
        }
        else if (DialogMode == DialogMode.Update)
        {
          if (Building.Id <= 0)
            throw new Exception("Building has wrong Id (<=0).");
          
        }
        if (Building.Contractor_Id <= 0)
          throw new Exception("Building has to belong to Contractor.");
        contractorService.UpdateBuilding(Building);
      }
      CloseModalDialog();
    }
  }
}