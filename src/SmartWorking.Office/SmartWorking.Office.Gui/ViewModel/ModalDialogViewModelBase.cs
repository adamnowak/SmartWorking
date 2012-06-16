using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Base class for View Model in MVVM pattern (using MVVMLight). Implements <see cref="IModalDialogViewModel"/> interface.
  /// </summary>
  public abstract class ModalDialogViewModelBase: DialogViewModelBase, IModalDialogViewModel
  {
    private ICommand _cancelCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogViewModelBase"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    protected ModalDialogViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      
    }
  }
}