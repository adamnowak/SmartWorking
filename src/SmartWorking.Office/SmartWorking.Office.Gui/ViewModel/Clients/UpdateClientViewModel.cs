using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Clients
{
  /// <summary>
  /// View model for <see cref="CreateOrUpdateClient"/> dialog. 
  /// </summary>
  public class UpdateClientViewModel : ModalDialogViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateClientViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateClientViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets or sets the view mode.
    /// </summary>
    /// <value>
    /// The view mode.
    /// </value>
    public DialogMode DialogMode { get; set; }


    /// <summary>
    /// Gets the title of dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nowego kontrahenta."
                 : "Edytuj kontrahenta.";
      }
    }

    #region Client property

    /// <summary>
    /// The <see cref="Client" /> property's name.
    /// </summary>
    public const string ClientPropertyName = "Client";

    private ClientPrimitive _client;

    /// <summary>
    /// Gets the Client property.
    /// This instance of <see cref="UpdateClientViewModel"/> provides operation for this Client. 
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public ClientPrimitive Client
    {
      get { return _client; }

      set
      {
        if (_client == value)
        {
          return;
        }
        _client = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(ClientPropertyName);
      }
    }

    #endregion

    #region CreateOrUpdateClientConmmand

    private ICommand _createOrUpdateClientCommand;

    /// <summary>
    /// Gets the create or update client command.
    /// </summary>
    /// <remarks>This command opens dialog where Client can be created or updated.</remarks>
    public ICommand CreateOrUpdateClientCommand
    {
      get
      {
        if (_createOrUpdateClientCommand == null)
          _createOrUpdateClientCommand = new RelayCommand(CreateOrUpdateClient, CanCreateOrUpdateClient);
        return _createOrUpdateClientCommand;
      }
    }

    /// <summary>
    /// Validates current fields of Client.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if current fields of Client is validate; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateOrUpdateClient()
    {
      //TODO: validate
      return true;
    }

    /// <summary>
    /// Updates the Client in the system.
    /// </summary>
    private void CreateOrUpdateClient()
    {
      string errorCaption = "Zatwierdzenie danych o kontrahencie!";
      try
      {
        if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
        {
          using (IClientsService clientService = ServiceFactory.GetClientsService())
          {
            clientService.CreateOrUpdateClient(Client);
          }
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

    #endregion
  }
}