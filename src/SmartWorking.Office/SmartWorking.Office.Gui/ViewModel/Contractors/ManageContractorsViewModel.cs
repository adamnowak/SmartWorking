﻿using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  /// <summary>
  /// View model for <see cref="ManageContractors"/> dialog. 
  /// </summary>
  public class ManageContractorsViewModel : ModalDialogViewModelBase
  {
    private ICommand _createContractorCommand;
    private ICommand _selectContractorCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageContractorsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageContractorsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableContractor = new SelectableViewModelBase<Contractor>();
      LoadContractors();
    }

    /// <summary>
    /// Gets the selectable contractor. List of contractors and one which is selected.
    /// </summary>
    public SelectableViewModelBase<Contractor> SelectableContractor { get; private set; }

    

    /// <summary>
    /// Gets the create contractor command.
    /// </summary>
    public ICommand CreateContractorCommand
    {
      get
      {
        if (_createContractorCommand == null)
          _createContractorCommand = new RelayCommand(() => ModalDialogService.CreateContractor(ModalDialogService, ServiceFactory));
        return _createContractorCommand;
      }
    }

    public override string Title
    {
      get { return "Wybierz kontrahenta."; }
    }

    

    private void LoadContractors()
    {
      using (IContractorsService contractorService = ServiceFactory.GetContractorsService())
      {
        SelectableContractor.LoadItems(contractorService.GetContractors(string.Empty));
      }
    }














    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    public ICommand SelectContractorCommand
    {
      get
      {
        if (_selectContractorCommand == null)
          _selectContractorCommand = new RelayCommand(SelectContractor);
        return _selectContractorCommand;
      }
    }
    private void SelectContractor()
    {
      CloseModalDialog();
    }



  }
}