using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  public abstract class ModalDialogViewModelBase : ViewModelBase, IModalDialogViewModel
  {
    private ICommand _cancelCommand;

    public ModalDialogViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      ModalDialogService = modalDialogService;
      ServiceFactory = serviceFactory;
      IsCanceled = true;
    }

    public IServiceFactory ServiceFactory { get; set; }

    public ICommand CancelCommand
    {
      get
      {
        if (_cancelCommand == null)
          _cancelCommand = new RelayCommand(Cancel);
        return _cancelCommand;
      }
    }

    public IModalDialogService ModalDialogService { get; private set; }

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
    public bool IsCanceled { get; private set; }

    #endregion

    public void CloaseModalDialog(bool isCanceled = false)
    {
      IsCanceled = isCanceled;
      OnRequestClose();
    }

    private void OnRequestClose()
    {
      EventHandler handler = RequestClose;
      if (handler != null)
        handler(this, EventArgs.Empty);
    }

    private void Cancel()
    {
      CloaseModalDialog(true);
    }

    internal void DoRaisePropertyChanged(string propertyName)
    {
      RaisePropertyChanged(propertyName);
    }
  }
}