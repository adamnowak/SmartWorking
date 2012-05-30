using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  public class UpdateDeliveryNoteViewModel : ModalDialogViewModelBase
  {
    public UpdateDeliveryNoteViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    public ViewMode ViewMode { get; set; }

    #region Building property
    /// <summary>
    /// The <see cref="Building" /> property's name.
    /// </summary>
    public const string BuildingPropertyName = "Building";

    private Building _building;

    /// <summary>
    /// Gets the Contractor property.
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

    #region SelectBuildingCommand

    private ICommand _selectBuildingCommand;

    public ICommand SelectBuildingCommand
    {
      get
      {
        if (_selectBuildingCommand == null)
          _selectBuildingCommand = new RelayCommand(SelcectContractor);
        return _selectBuildingCommand;
      }
    }

    private void SelcectContractor()
    {
      Contractor selectContractor = ModalDialogService.SelectContractor(ModalDialogService, ServiceFactory);      
      if (selectContractor != null)
      {
        Building = ModalDialogService.SelectBuilding(ModalDialogService, ServiceFactory, selectContractor);
      }
    }
    
    #endregion

    public override string Title
    {
      get
      {
        return (ViewMode == ViewModel.ViewMode.Create)
                 ? "Utwórz nową WZ'tkę."
                 : "Edytuj WZ'tkę.";
      }
    }
  }
}