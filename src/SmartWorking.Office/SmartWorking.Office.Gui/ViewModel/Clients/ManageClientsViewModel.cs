using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.Clients;
using SmartWorking.Office.Gui.ViewModel.Clients;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Clients
{
  /// <summary>
  /// View model for <see cref="ManageClients"/> dialog. 
  /// </summary>
  public class ManageClientsViewModel : ModalDialogViewModelBase
  {
    private ICommand _choseBuildingCommand;
    private ICommand _createBuildingCommand;
    private ICommand _createClientCommand;
    private ICommand _createDeliveryNoteCommand;
    private ICommand _deleteBuildingCommand;
    private ICommand _deleteClientCommand;
    private ICommand _editBuildingCommand;
    private ICommand _editClientCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageClientsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageClientsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableClient = new SelectableViewModelBase<ClientAndClientBuildingsPackage>();
      LoadClients();
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the selectable client with building information. List of clients with information about them buildings and one which is selected.
    /// </summary>
    public SelectableViewModelBase<ClientAndClientBuildingsPackage> SelectableClient { get; private set; }

    /// <summary>
    /// Gets or sets the selected building.
    /// </summary>
    /// <value>
    /// The selected building.
    /// </value>
    public BuildingPrimitive SelectedBuilding { get; set; }

    /// <summary>
    /// Gets the create client command.
    /// </summary>
    /// <remarks>Opens dialog to creating <see cref="Client"/>.</remarks>
    public ICommand CreateClientCommand
    {
      get
      {
        if (_createClientCommand == null)
          _createClientCommand = new RelayCommand(CreateClient);
        return _createClientCommand;
      }
    }

    /// <summary>
    /// Gets the edit client command.
    /// </summary>
    /// <remarks>Opens dialog to editing <see cref="Client"/>.</remarks>
    public ICommand EditClientCommand
    {
      get
      {
        if (_editClientCommand == null)
          _editClientCommand = new RelayCommand(
            EditClient,
            () => SelectableClient != null && SelectableClient.SelectedItem != null);
        return _editClientCommand;
      }
    }

    /// <summary>
    /// Gets the delete client command.
    /// </summary>
    /// <remarks>
    /// Deletes <see cref="Client"/> if user confirmed action. 
    /// Command cannot be execute if any Building of this Client is connected with any <see cref="DeliveryNote"/>.
    /// </remarks>
    public ICommand DeleteClientCommand
    {
      get
      {
        if (_deleteClientCommand == null)
          _deleteClientCommand = new RelayCommand(DeleteClient,
                                                      CanDeleteClient);
        return _deleteClientCommand;
      }
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
                                                    () =>
                                                    SelectableClient != null &&
                                                    SelectableClient.SelectedItem != null);
        return _createBuildingCommand;
      }
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
            () => SelectableClient != null && SelectableClient.SelectedItem != null && SelectedBuilding != null);
        return _editBuildingCommand;
      }
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

    public override string Title
    {
      get { return "Wybierz klienta."; }
    }

    /// <summary>
    /// Creates the client.
    /// </summary>
    private void CreateClient()
    {
      string errorCaption = "Tworzenie danych o kliencie!";
      try
      {
        ModalDialogService.CreateClient(ModalDialogService, ServiceFactory);
        LoadClients();
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

    private void EditClient()
    {
      string errorCaption = "Edycja danych o kliencie!";
      try
      {
        ModalDialogService.EditClient(ModalDialogService, ServiceFactory,
                                          SelectableClient.SelectedItem.Client);
        LoadClients();
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

    private void DeleteClient()
    {
      string errorCaption = "Usuwanie danych o kliencie!";
      try
      {
        //TODO: 
        //MessageBox with question
        //if yes deletes all building of this client and this client
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

    private bool CanDeleteClient()
    {
      if (SelectableClient != null && SelectableClient.SelectedItem != null)
      {
        //TODO: return true if all building of this client can be deleted.
      }
      return false;
    }


    private void CreateBuilding()
    {
      string errorCaption = "Tworzenie danych o budowie!";
      try
      {
        ModalDialogService.CreateBuilding(ModalDialogService, ServiceFactory,
                                          SelectableClient.SelectedItem.Client);
        LoadClients();
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

    private void EditBuilding()
    {
      string errorCaption = "Edycj danych o budowie!";
      try
      {
        ModalDialogService.EditBuilding(ModalDialogService, ServiceFactory,
          new ClientBuildingAndBuildingPackage() { Building = SelectedBuilding, 
            Client = (SelectableClient.SelectedItem == null) ? null : SelectableClient.SelectedItem.Client });
        LoadClients();
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

    private void DeleteBuilding()
    {
      string errorCaption = "Uduwanie danych o budowie!";
      try
      {
        //TODO: 
        //MessageBox with question
        //if any <see cref="DeliveryNotePackage"/> exists for this Building.
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

    private bool CanDeleteBuilding()
    {
      if (SelectableClient != null && SelectableClient.SelectedItem != null && SelectedBuilding != null)
      {
        //TODO: return true if building of this client can be deleted.
      }
      return false;
    }


    private void LoadClients()
    {
      string errorCaption = "Pobranie danych o klientach!";
      try
      {
        ClientAndClientBuildingsPackage selectedItem = SelectableClient.SelectedItem;
        using (IClientsService clientsService = ServiceFactory.GetClientsService())
        {
          SelectableClient.LoadItems(clientsService.GetClientAndBuildingsPackageList(string.Empty));
        }
        if (selectedItem != null && selectedItem.Client != null)
        {
          ClientAndClientBuildingsPackage selectionFromItems =
            SelectableClient.Items.Where(x => x.Client.Id == selectedItem.Client.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableClient.SelectedItem = selectionFromItems;
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

    #region ChoseBuildingCommand

    /// <summary>
    /// Gets the chose building command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="Client"/> object where user can chose Building.</remarks>
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
      string errorCaption = "Wybieranie budowli!";
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
      return SelectableClient.SelectedItem != null && SelectedBuilding != null &&
             DialogMode != DialogMode.ChoseSubItem;
    }

    /// <summary>
    /// Executes  <see cref="ChoseBuildingCommand"/>.
    /// </summary>
    /// <remarks>
    /// Closes modal dialog.
    /// </remarks>
    private void CreateDeliveryNote()
    {
      string errorCaption = "Tworzenie WZ'tki!";
      try
      {
        var buildingAndClientPackage = new ClientBuildingAndBuildingPackage();
        buildingAndClientPackage.Building = SelectedBuilding;
        buildingAndClientPackage.Client = SelectableClient.SelectedItem.Client;
        ModalDialogService.CreateDeliveryNote(ModalDialogService, ServiceFactory, buildingAndClientPackage);
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

    #endregion
  }
}