using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Gui.ViewModel.Shared;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Clients
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

    #region BuildingDescription
    /// <summary>
    /// The <see cref="BuildingDescription" /> property's name.
    /// </summary>
    public const string BuildingDescriptionPropertyName = "BuildingDescription";

    private string _buldingDescription;

    /// <summary>
    /// Gets the BuildingDescription property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string BuildingDescription
    {
      get
      {
        return (_buildingAndClient != null && _buildingAndClient.Building != null) 
          ? _buildingAndClient.Building.City + ", " + _buildingAndClient.Building.ZIPCode + ", " + 
          _buildingAndClient.Building.Street + " " + _buildingAndClient.Building.HouseNo : string.Empty;
      }

    }
    #endregion //BuildingDescription

    #region BuildingAndClient property

    /// <summary>
    /// The <see cref="Building" /> property's name.
    /// </summary>
    public const string BuildingAndClientPropertyName = "BuildingAndClient";

    private BuildingAndClientPackage _buildingAndClient;

    /// <summary>
    /// Gets the Building property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public BuildingAndClientPackage BuildingAndClient
    {
      get { return _buildingAndClient; }

      set
      {
        if (_buildingAndClient == value)
        {
          return;
        }
        _buildingAndClient = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(BuildingAndClientPropertyName);
      }
    }

    #endregion


    private bool CanCreateOrUpdatBuilding()
    {
      if (BuildingAndClient == null || BuildingAndClient.Building == null || BuildingAndClient.Client == null)
        return false;
      //TODO: validate
      return true;
    }


    private void CreateOrUpdatBuilding()
    {
      string errorCaption = "Zatwierdzenie danych o budowie!";
      try
      {
        if (BuildingAndClient == null)
          throw new Exception(); //TODO:

        using (IClientsService clientService = ServiceFactory.GetClientsService())
        {
          if (DialogMode == DialogMode.Create)
          {
            if (BuildingAndClient.Building.Id > 0)
              throw new Exception("Building has wrong Id (>0).");
          }
          else if (DialogMode == DialogMode.Update)
          {
            if (BuildingAndClient.Building.Id <= 0)
              throw new Exception("Building has wrong Id (<=0).");
          }

          clientService.UpdateBuilding(BuildingAndClient.GetBuildingPrimitiveWithReference());
        }
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
  }
}