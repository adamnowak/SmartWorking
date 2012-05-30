using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;

using SmartWorking.Office.Gui.View.Contractors;
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
    public SelectableViewModelBase<Contractor> SelectableContractor { get; private set; }

    public SelectContractorViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableContractor = new SelectableViewModelBase<Contractor>();
      LoadContractors();
    }

    public SelectContractorViewMode ViewMode { get; set; }

    private void LoadContractors()
    {
      using (var contractorService = ServiceFactory.GetContractorsService())
      {
        SelectableContractor.LoadItems(contractorService.GetContractors());
      }
    }

    private ICommand _selectCommand;

    public ICommand SelectCommand
    {
      get
      {
        if (_selectCommand == null)
          _selectCommand = new RelayCommand(SelectContractor, CanCreate);
        return _selectCommand;
      }
    }

    private void SelectContractor()
    {
      CloaseModalDialog();
    }

    private bool CanCreate()
    {
      //TODO: validate
      return true;
    }


    public override string Title
    {
      get { return "Wybierz kontrahenta."; }
    }


  }
}