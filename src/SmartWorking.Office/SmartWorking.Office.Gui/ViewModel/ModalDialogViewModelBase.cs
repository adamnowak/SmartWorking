using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  public abstract class ModalDialogViewModelBase : ViewModelBase, IModalDialogViewModel
  {
    public ModalDialogViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      ModalDialogService = modalDialogService;
      ServiceFactory = serviceFactory;
    }

    public IServiceFactory ServiceFactory { get; set; }

    //private CommandHelper _commandHelper;

    //public CommandHelper CommandHelper
    //{
    //  get
    //  {
    //    if (_commandHelper == null)
    //      _commandHelper = new CommandHelper(this);
    //    return _commandHelper;
    //  }
    //}

    #region IModalDialogViewModel Members

    public event EventHandler RequestClose;

    public abstract string Title { get; }

    #endregion

    public void CloaseModalDialog()
    {
      OnRequestClose();
    }

    private void OnRequestClose()
    {
      EventHandler handler = RequestClose;
      if (handler != null)
        handler(this, EventArgs.Empty);
    }

    public bool Canceled { get; private set; }

    private ICommand _cancelCommand;

    public ICommand CancelCommand
    {
      get
      {
        if (_cancelCommand == null)
          _cancelCommand = new RelayCommand(Cancel);
        return _cancelCommand;
      }
    }

    private void Cancel()
    {
      Canceled = true;
      CloaseModalDialog();
    }

    public IModalDialogService ModalDialogService { get; private set; }

    internal void DoRaisePropertyChanged(string propertyName)
    {
      RaisePropertyChanged(propertyName);
    }
  }
}