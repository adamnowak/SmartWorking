using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public abstract class ControlViewModelBase : ViewModelBase, IControlViewModel
  {
    public ControlViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      ModalDialogService = modalDialogService;
      ServiceFactory = serviceFactory;
      EditingMode = EditingMode.Display;
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

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    public abstract void Refresh();

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Gets the modal dialog service.
    /// </summary>
    public IModalDialogService ModalDialogService { get; private set; }

    /// <summary>
    /// Gets the service factory.
    /// </summary>
    public IServiceFactory ServiceFactory { get; private set; }

    /// <summary>
    /// Gets the editing mode of the control.
    /// </summary>
    public EditingMode EditingMode { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is editing.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is editing; otherwise, <c>false</c>.
    /// </value>
    public virtual bool IsEditing
    {
      get { return EditingMode == EditingMode.New || EditingMode == EditingMode.Edit; }
    }
  }
}
