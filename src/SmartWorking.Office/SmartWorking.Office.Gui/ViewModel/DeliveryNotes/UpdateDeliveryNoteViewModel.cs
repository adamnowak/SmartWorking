using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  public class UpdateDeliveryNoteViewModel : ModalDialogViewModelBase
  {
    public UpdateDeliveryNoteViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    public DialogMode ViewMode { get; set; }

    public override string Title
    {
      get
      {
        return (ViewMode == DialogMode.Create)
                 ? "Utwórz nową WZ'tkę."
                 : "Edytuj WZ'tkę.";
      }
    }

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

    #region SelectBuildingCommand

    /// <summary>
    /// The <see cref="DeliveryNote" /> property's name.
    /// </summary>
    public const string DeliveryNotePropertyName = "DeliveryNote";

    private DeliveryNote _deliveryNote;
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

    /// <summary>
    /// Gets the DeliveryNote property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public DeliveryNote DeliveryNote
    {
      get { return _deliveryNote; }

      set
      {
        if (_deliveryNote == value)
        {
          return;
        }
        _deliveryNote = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(DeliveryNotePropertyName);
      }
    }

    private void SelcectContractor()
    {
      //Contractor selectContractor = ModalDialogService.ManageContractors(ModalDialogService, ServiceFactory);
      //if (selectContractor != null)
      //{
      //  Building = ModalDialogService.SelectBuilding(ModalDialogService, ServiceFactory, selectContractor);
      //}
    }

    #endregion
  }
}