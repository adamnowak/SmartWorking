﻿using System;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Base class for View Model in MVVM pattern (using MVVMLight). Implements <see cref="IModalDialogViewModel"/> interface.
  /// </summary>
  public abstract class ModalDialogViewModelBase : ViewModelBase, IModalDialogViewModel
  {

    
    private ICommand _cancelCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogViewModelBase"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    protected ModalDialogViewModelBase(IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
    {
      ModalDialogProvider = modalDialogProvider;
      ServiceFactory = serviceFactory;
      IsCanceled = true;
    }



    /// <summary>
    /// Gets or sets the service factory.
    /// </summary>
    /// <value>
    /// The service factory.
    /// </value>
    public IServiceFactory ServiceFactory { get; protected set; }

    /// <summary>
    /// Gets the cancel command.
    /// </summary>
    /// <remarks>This command close the dialog and set <see cref="IsCanceled"/> to <c>true</c>.</remarks>
    public ICommand CancelCommand
    {
      get
      {
        if (_cancelCommand == null)
          _cancelCommand = new RelayCommand(Cancel);
        return _cancelCommand;
      }
    }

    /// <summary>
    /// Gets the modal dialog service.
    /// </summary>
    public IModalDialogProvider ModalDialogProvider { get; protected set; }

    #region IDialogViewModel Members

    /// <summary>
    /// Raise when request about close dialog occurs.
    /// </summary>
    public event EventHandler RequestClose;

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public abstract string Title { get; }

    /// <summary>
    /// Gets a value indicating whether main operation on dialog was canceled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if  main operation on dialog was canceled; otherwise, <c>false</c>.
    /// </value>
    public bool IsCanceled { get; private set; }


    /// <summary>
    /// Gets a value indicating whether this <see cref="DialogViewModelBase"/> is closing.
    /// </summary>
    /// <value>
    ///   <c>true</c> if closing; otherwise, <c>false</c>.
    /// </value>
    public bool Closing { get; private set; }

    #endregion

    /// <summary>
    /// Closes the modal dialog and set <see cref="IsCanceled"/> to <paramref name="isCanceled"/>.
    /// </summary>
    /// <param name="isCanceled">if set to <c>true</c> [is canceled].</param>
    public void CloseModalDialog(bool isCanceled = false)
    {
      IsCanceled = isCanceled;
      OnRequestClose();
      Closing = true;
    }

    /// <summary>
    /// Called when <see cref="RequestClose"/> occurred.
    /// </summary>
    private void OnRequestClose()
    {
      EventHandler handler = RequestClose;
      if (handler != null)
        handler(this, EventArgs.Empty);
    }

    /// <summary>
    /// Close dialog and set <see cref="IsCanceled"/> to <c>true</c>.
    /// </summary>
    protected virtual void Cancel()
    {
      CloseModalDialog(true);
    }
  }
}