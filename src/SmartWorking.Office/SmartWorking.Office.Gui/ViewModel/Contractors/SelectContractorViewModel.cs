using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  public enum SelectContractorViewMode
  {
    SelectContractor,
    SelectBuilding
  }

  public class SelectContractorViewModel : ModalDialogViewModelBase
  {
    private ICommand _selectContractorCommand;
    private ICommand _createContractorCommand;

    public SelectContractorViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableContractor = new SelectableViewModelBase<Contractor>();
      LoadContractors();
    }

    public SelectableViewModelBase<Contractor> SelectableContractor { get; private set; }

    public SelectContractorViewMode ViewMode { get; set; }

    public ICommand SelectContractorCommand
    {
      get
      {
        if (_selectContractorCommand == null)
          _selectContractorCommand = new RelayCommand(SelectContractor);
        return _selectContractorCommand;
      }
    }

    public ICommand CreateContractorCommand
    {
      get
      {
        if (_createContractorCommand == null)
          _createContractorCommand = new RelayCommand(CreateContractor, CanCreateContractor);
        return _createContractorCommand;
      }
    }

    private void CreateContractor()
    {
      Contractor newContractor = ModalDialogService.CreateContractor(ModalDialogService, ServiceFactory);
      if (newContractor != null)
      {
        SelectableContractor.Items.Add(newContractor);
        SelectableContractor.SelectedItem = newContractor;
        CloaseModalDialog();
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
        SelectableContractor.LoadItems(contractorService.GetContractors());
      }
    }

    private void SelectContractor()
    {
      CloaseModalDialog();
    }

    private bool CanCreateContractor()
    {
      //TODO: validate
      return true;
    }
  }
}