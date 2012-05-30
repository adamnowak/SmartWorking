using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
 
  public class UpdateBuildingViewModel : ModalDialogViewModelBase
  {
    public UpdateBuildingViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
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
      get
      {
        return _building;
      }

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

    private ICommand _createBuildingCommand;

    public ICommand CreateBuildingBuildingCommand
    {
      get
      {
        if (_createBuildingCommand == null)
          _createBuildingCommand = new RelayCommand(UpdateBuilding, CanCreateBuilding);
        return _createBuildingCommand;
      }
    }

    private bool CanCreateBuilding()
    {
      //TODO: validate
      return true;
    }


    private void UpdateBuilding()
    {
      if (ViewMode == ViewMode.Create)
      {
        Contractor.Buildings.Add(Building);  
      }
      CloaseModalDialog();
    }

    public override string Title
    {
      get
      {
        return (ViewMode == ViewModel.ViewMode.Create)
                 ? "Utwórz nową budowę."
                 : "Edytuj budowę.";
      }
    }
  }
}