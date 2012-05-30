using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  public class UpdateContractorViewModel : ModalDialogViewModelBase
  {
    public UpdateContractorViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    public ViewMode ViewMode { get; set; }

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
      get
      {
        return _contractor;
      }

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
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Building SelectedBuilding
    {
      get
      {
        return _selectedBuilding;
      }

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
    
    #region CreateContractorConmmand
    private ICommand _createContractorCommand;

    public ICommand CreateContractorCommand
    {
      get
      {
        if (_createContractorCommand == null)
          _createContractorCommand = new RelayCommand(CreateContractor, CanCreateContractor);
        return _createContractorCommand;
      }
    }

    private bool CanCreateContractor()
    {
      //TODO: validate
      return true;
    }

    private void CreateContractor()
    {
      if (ViewMode == ViewMode.Create || ViewMode == ViewMode.Update)
      {
        using (var contractorService = ServiceFactory.GetContractorsService())
        {
          contractorService.UpdateContractor(Contractor);
        }
      }
      CloaseModalDialog();
    }
    #endregion

    private ICommand _createBuildingCommand;

    public ICommand CreateBuildingCommand
    {
      get
      {
        if (_createBuildingCommand == null)
          _createBuildingCommand = new RelayCommand(CreateBuilding);
        return _createBuildingCommand;
      }
    }

    

    private void CreateBuilding()
    {
      ModalDialogService.CreateBuilding(ModalDialogService, ServiceFactory, Contractor);
    }


    private ICommand _updateBuildingCommand;

    public ICommand UpdateBuildingCommand
    {
      get
      {
        if (_updateBuildingCommand == null)
          _updateBuildingCommand = new RelayCommand(UpdateBuilding, () => { return SelectedBuilding != null; });
        return _updateBuildingCommand;
      }
    }

    private void UpdateBuilding()
    {
      ModalDialogService.UpdateBuilding(ModalDialogService, ServiceFactory, SelectedBuilding);
    }

    private ICommand _deleteBuildingCommand;

    public ICommand DeleteBuildingCommand
    {
      get
      {
        if (_deleteBuildingCommand == null)
          _deleteBuildingCommand = new RelayCommand(DeleteBuilding, () => { return SelectedBuilding != null; });
        return _deleteBuildingCommand;
      }
    }

    private void DeleteBuilding()
    {
      //TODO:
    }

    public override string Title
    {
      get
      {
        return (ViewMode == ViewModel.ViewMode.Create)
                 ? "Utwórz nowego kontrahenta."
                 : "Edytuj kontrahenta.";
      }
    }
  }
}