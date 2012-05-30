using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;

namespace SmartWorking.Office.Gui.ViewModel
{
  //public class CommandHelper
  //{
  //  private ModalDialogViewModelBase ModalDialogViewModelBase { get; set; }
  //  public CommandHelper(ModalDialogViewModelBase modalDialogViewModelBase)
  //  {
  //    ModalDialogViewModelBase = modalDialogViewModelBase;
  //  }

  //  #region SelectContractorCommand

  //  #endregion
    
   
    
  //  #region CreateContractorCommand
  //   public Contractor Contractor
  //  {
  //    get; set;
  //  }
    
  //  private ICommand _createContractorCommand;


  //  public ICommand CreateContractorCommand
  //  {
  //    get
  //    {
  //      if (_createContractorCommand == null)
  //        _createContractorCommand = new RelayCommand(CreateContractor, CanCreateContractor);
  //      return _createContractorCommand;
  //    }
  //  }

  //  private bool CanCreateContractor()
  //  {
  //    //TODO: validate _contractorToUpdate
  //    return true;
  //  }

  //  private void CreateContractor()
  //  {
  //    using (var contractorService = new ContractorsService.ContractorsServiceClient())
  //    {
  //      contractorService.UpdateContractor(Contractor);
  //    }
  //    ModalDialogViewModelBase.CloaseModalDialog();
  //  }

  //  //public ICommand GetCreateContractorContractorCommand(Contractor contractorToUpdate)
  //  //{
  //  //  Contractor = contractorToUpdate;
  //  //  return CreateContractorContractorCommand;
  //  //}

  //  #endregion
  //}
}
