using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  /// <summary>
  /// View model for <see cref="ManageContractors"/> dialog. 
  /// </summary>
  public class ManageContractorsViewModel : ModalDialogViewModelBase
  {
    private ICommand _createContractorCommand;
    private ICommand _deleteContractorCommand;
    private ICommand _editContractorCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageContractorsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageContractorsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableContractor = new SelectableViewModelBase<ContractorPrimitive>();
      LoadContractors();
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the selectable contractor. List of contractors and one which is selected.
    /// </summary>
    public SelectableViewModelBase<ContractorPrimitive> SelectableContractor { get; private set; }


    /// <summary>
    /// Gets the create contractor command.
    /// </summary>
    /// <remarks>Opens dialog to creating <see cref="Contractor"/>.</remarks>
    public ICommand CreateContractorCommand
    {
      get
      {
        if (_createContractorCommand == null)
          _createContractorCommand = new RelayCommand(CreateContractor);
        return _createContractorCommand;
      }
    }

    /// <summary>
    /// Gets the edit contractor command.
    /// </summary>
    /// <remarks>Opens dialog to editing <see cref="Contractor"/>.</remarks>
    public ICommand EditContractorCommand
    {
      get
      {
        if (_editContractorCommand == null)
          _editContractorCommand = new RelayCommand(
            EditContractor,
            () => SelectableContractor != null && SelectableContractor.SelectedItem != null);
        return _editContractorCommand;
      }
    }

    /// <summary>
    /// Gets the delete contractor command.
    /// </summary>
    /// <remarks>
    /// Deletes <see cref="Contractor"/> if user confirmed action. 
    /// Command cannot be execute if any Building of this Contractor is connected with any <see cref="DeliveryNote"/>.
    /// </remarks>
    public ICommand DeleteContractorCommand
    {
      get
      {
        if (_deleteContractorCommand == null)
          _deleteContractorCommand = new RelayCommand(DeleteContractor,
                                                      CanDeleteContractor);
        return _deleteContractorCommand;
      }
    }


    public override string Title
    {
      get { return "Wybierz kontrahenta."; }
    }

    /// <summary>
    /// Creates the contractor.
    /// </summary>
    private void CreateContractor()
    {
      string errorCaption = "Tworzenie danych o kontrahencie!";
      try
      {
        ModalDialogService.CreateContractor(ModalDialogService, ServiceFactory);
        LoadContractors();
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

    private void EditContractor()
    {
      string errorCaption = "Edycja danych o kontrahencie!";
      try
      {
        ModalDialogService.EditContractor(ModalDialogService, ServiceFactory,
                                          SelectableContractor.SelectedItem);
        LoadContractors();
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

    private void DeleteContractor()
    {
      string errorCaption = "Usuwanie danych o kontrahencie!";
      try
      {
        //TODO: 
        //MessageBox with question
        //if yes deletes all building of this contractor and this contractor
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

    private bool CanDeleteContractor()
    {
      if (SelectableContractor != null && SelectableContractor.SelectedItem != null)
      {
        //TODO: return true if all building of this contractor can be deleted.
      }
      return false;
    }


   

    private void LoadContractors()
    {
      string errorCaption = "Pobranie danych o kontrahentach!";
      try
      {
        ContractorPrimitive selectedItem = SelectableContractor.SelectedItem;
        using (IContractorsService contractorService = ServiceFactory.GetContractorsService())
        {
          SelectableContractor.LoadItems(contractorService.GetContractors(string.Empty));
        }
        if (selectedItem != null)
        {
          ContractorPrimitive selectionFromItems =
            SelectableContractor.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableContractor.SelectedItem = selectionFromItems;
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

  }
}