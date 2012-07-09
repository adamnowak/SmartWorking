using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Materials
{
  /// <summary>
  /// View model for <see cref="CreateOrUpdateMaterial"/> dialog. 
  /// </summary>
  public class UpdateMaterialViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateMaterialCommand;
    private ICommand _selectProducerComman;
    private ICommand _selectDelivererComman;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateMaterialViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateMaterialViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
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
    /// Gets the create or update material command.
    /// </summary>
    /// <remarks>
    /// Opens dialog for creating or editing MaterialAndContractors.
    /// </remarks>
    public ICommand CreateOrUpdateMaterialCommand
    {
      get
      {
        if (_createOrUpdateMaterialCommand == null)
          _createOrUpdateMaterialCommand = new RelayCommand(CreateOrUpdateMaterial, CanCreateOrUpdateMaterial);
        return _createOrUpdateMaterialCommand;
      }
    }

    /// <summary>
    /// Gets the select producer command.
    /// </summary>
    /// <remarks>
    /// Opens dialog for selecting producer <see cref="Contractor"/>.
    /// </remarks>
    public ICommand SelectProducerCommand
    {
      get
      {
        if (_selectProducerComman == null)
          _selectProducerComman = new RelayCommand(SelectProducer);
        return _selectProducerComman;
      }
    }

    private void SelectProducer()
    {
      string errorCaption = "Wybranie producenta!";
      try
      {
        MaterialAndContractors.Producer = ModalDialogService.SelectContractor(ModalDialogService, ServiceFactory);
        RaisePropertyChanged("Producer");
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

    /// <summary>
    /// Gets the select deliverer command.
    /// </summary>
    /// <remarks>
    /// Opens dialog for selecting deliverer <see cref="Contractor"/>.
    /// </remarks>
    public ICommand SelectDelivererCommand
    {
      get
      {
        if (_selectDelivererComman == null)
          _selectDelivererComman = new RelayCommand(SelectDeliverer);
        return _selectDelivererComman;
      }
    }

    private void SelectDeliverer()
    {
      string errorCaption = "Wybranie dostawcy!";
      try
      {
        MaterialAndContractors.Deliverer = ModalDialogService.SelectContractor(ModalDialogService, ServiceFactory);
        RaisePropertyChanged(MaterialAndContractorsPropertyName);
        RaisePropertyChanged("Deliverer");
        RaisePropertyChanged("MaterialAndContractors.Deliverer");
        RaisePropertyChanged("Contractor");
        RaisePropertyChanged("UpdateMaterialViewModel");
        
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

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nowy materiał."
                 : "Edytuj materiał.";
      }
    }

    #region MaterialAndContractors

    /// <summary>
    /// The <see cref="MaterialAndContractors" /> property's name.
    /// </summary>
    public const string MaterialAndContractorsPropertyName = "MaterialAndContractors";

    private MaterialAndContractorsPackage _materialAndContractors;
    

    /// <summary>
    /// Gets the MaterialAndContractors property.
    /// MaterialAndContractors which will be created or updated.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public MaterialAndContractorsPackage MaterialAndContractors
    {
      get { return _materialAndContractors; }

      set
      {
        if (_materialAndContractors == value)
        {
          return;
        }
        _materialAndContractors = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(MaterialAndContractorsPropertyName);
      }
    }

    #endregion

    /// <summary>
    /// Determines whether <see cref="CreateOrUpdateMaterialCommand"/> can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="CreateOrUpdateMaterialCommand"/> can be execute; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateOrUpdateMaterial()
    {
      //TODO: validate
      return true;
    }


    /// <summary>
    /// Creates or updates the material in the system.
    /// </summary>
    private void CreateOrUpdateMaterial()
    {
      string errorCaption = "Zatwierdzanie danych o materiale!";
      try
      {
        if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
        {
          using (IMaterialsService service = ServiceFactory.GetMaterialsService())
          {
            service.UpdateMaterial(MaterialAndContractors.GetMaterialPrimitiveWithReference());
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
  }
}