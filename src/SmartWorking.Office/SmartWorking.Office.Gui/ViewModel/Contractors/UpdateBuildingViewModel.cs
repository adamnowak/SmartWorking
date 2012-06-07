using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  public class UpdateBuildingViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateBuildingCommand;

    public UpdateBuildingViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    public DialogMode ViewMode { get; set; }

    public ICommand CreateOrUpdatBuildingCommand
    {
      get
      {
        if (_createOrUpdateBuildingCommand == null)
          _createOrUpdateBuildingCommand = new RelayCommand(CreateOrUpdatBuilding, CanCreateOrUpdatBuilding);
        return _createOrUpdateBuildingCommand;
      }
    }

    public override string Title
    {
      get
      {
        return (ViewMode == DialogMode.Create)
                 ? "Utwórz nową budowę."
                 : "Edytuj budowę.";
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
    /// TODO Update documentation:
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

    #region Building property

    /// <summary>
    /// The <see cref="Building" /> property's name.
    /// </summary>
    public const string BuildingPropertyName = "Building";

    private Building _building;

    /// <summary>
    /// Gets the Building property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Building Building
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
      if (Contractor == null || Building == null)
        return false;
      //TODO: validate
      return true;
    }


    private void CreateOrUpdatBuilding()
    {
      if (Contractor == null || Building == null)
        throw new Exception(); //TODO:
      
      using (IContractorsService contractorService = ServiceFactory.GetContractorsService())
      {
        if (ViewMode == DialogMode.Create)
        {
          if (Building.Id > 0)
            throw new Exception("Building has wrong Id (>0).");
          Building.Contractor_Id = Contractor.Id;
          contractorService.AddBuildingToContractor(Contractor, Building);
        }
        else if (ViewMode == DialogMode.Update)
        {
          if (Building.Id <= 0)
            throw new Exception("Building has wrong Id (<=0).");
          if (Contractor.Id != Building.Contractor_Id)
            throw new Exception("Building has to belong to Contractor.");
          contractorService.UpdateBuilding(Building);
        }
      }
      CloseModalDialog();
    }
  }
}