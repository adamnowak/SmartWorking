﻿using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  public abstract class WindowViewModelBase : DialogViewModelBase
  {
    public WindowViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      
    }

    /// <summary>
    /// Shows <see cref="MessageBox"/> dialog with information about <paramref name="faultException"/>.
    /// </summary>
    /// <param name="caption">The caption.</param>
    /// <param name="faultException">The fault exception.</param>
    protected void ShowError(string caption, FaultException<ExceptionDetail> faultException)
    {
      if (faultException != null)
      {
        ModalDialogService.ShowMessageBox(ModalDialogService, ServiceFactory, MessageBoxImage.Error, caption,
                                          faultException.Message,
                                          MessageBoxButton.OK,
                                          (faultException.Detail != null && faultException.Detail.InnerException != null)
                                            ? faultException.Detail.InnerException.Message
                                            : string.Empty);
      }
    }

    /// <summary>
    /// Shows <see cref="MessageBox"/> dialog with information about <paramref name="exception"/>.
    /// </summary>
    /// <param name="caption">The caption.</param>
    /// <param name="exception">The exception which information will be display on <see cref="MessageBox"/>.</param>
    protected void ShowError(string caption, Exception exception)
    {
      if (exception != null)
      {
        ModalDialogService.ShowMessageBox(ModalDialogService, ServiceFactory, MessageBoxImage.Error, caption,
                                          exception.Message,
                                          MessageBoxButton.OK,
                                          (exception.InnerException != null)
                                            ? exception.InnerException.Message
                                            : string.Empty);
      }
    }

    /// <summary>
    /// Shows <see cref="MessageBox"/> dialog with information about <paramref name="communicationException"/>.
    /// </summary>
    /// <param name="caption">The caption.</param>
    /// <param name="communicationException">The <see cref="CommunicationException"/> which information will be display on <see cref="MessageBox"/>.</param>
    protected void ShowError(string caption, CommunicationException communicationException)
    {
      if (communicationException != null)
      {
        ModalDialogService.ShowMessageBox(ModalDialogService, ServiceFactory, MessageBoxImage.Error, caption,
                                          communicationException.Message,
                                          MessageBoxButton.OK,
                                          (communicationException.InnerException != null)
                                            ? communicationException.InnerException.Message
                                            : string.Empty);
      }
    }
  }

  /// <summary>
  /// Base class for View Model in MVVM pattern (using MVVMLight). Implements <see cref="IModalDialogViewModel"/> interface.
  /// </summary>
  public abstract class ModalDialogViewModelBase: WindowViewModelBase, IModalDialogViewModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DialogViewModelBase"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    protected ModalDialogViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      
    }

    /// <summary>
    /// Initializes view model properties.
    /// </summary>
    public virtual void Initialize()
    {      
    }

    
  }
}