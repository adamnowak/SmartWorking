using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  /// <summary>
  /// View model for <see cref="CreateOrUpdateContractor"/> dialog. 
  /// </summary>
  public class UpdateContractorViewModel : ModalDialogViewModelBase
  {
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

    #region Contractor property

    /// <summary>
    /// The <see cref="Contractor" /> property's name.
    /// </summary>
    public const string ContractorPropertyName = "Contractor";

    private ContractorPrimitive _contractor;

    /// <summary>
    /// Gets the Contractor property.
    /// This instance of <see cref="UpdateContractorViewModel"/> provides operation for this Contractor. 
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public ContractorPrimitive Contractor
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
          _createOrUpdateContractorCommand = new RelayCommand(CreateOrUpdateContractor, CanCreateOrUpdateContractor);
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
    private void CreateOrUpdateContractor()
    {
      string errorCaption = "Zatwierdzenie danych o kontrahencie!";
      try
      {
        if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
        {
          using (IContractorsService contractorService = ServiceFactory.GetContractorsService())
          {
            contractorService.CreateOrUpdateContractor(Contractor);
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