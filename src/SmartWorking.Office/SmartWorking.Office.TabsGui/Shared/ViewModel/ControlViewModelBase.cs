using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public abstract class ControlViewModelBase : ViewModelBase, IControlViewModel
  {
    public ControlViewModelBase(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      MainViewModel = mainViewModel;
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

    public IMainViewModel MainViewModel { get; private set;  }

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

    #region EditingMode
    /// <summary>
    /// The <see cref="EditingMode" /> property's name.
    /// </summary>
    public const string EditingModePropertyName = "EditingMode";

    private EditingMode _editingMode;

    /// <summary>
    /// Gets the EditingMode property.
    /// Gets the editing mode of the control.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public EditingMode EditingMode
    {
      get
      {
        return _editingMode;
      }

      set
      {
        if (_editingMode == value)
        {
          return;
        }
        _editingMode = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(EditingModePropertyName);
        RaisePropertyChanged(IsReadOnlyPropertyName);
      }
    }
    #endregion //EditingMode

    /// <summary>
    /// The <see cref="EditingMode" /> property's name.
    /// </summary>
    public const string IsReadOnlyPropertyName = "IsReadOnly";
    /// <summary>
    /// Gets a value indicating whether this instance is read only.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
    /// </value>
    public virtual bool IsReadOnly
    {
      get { return EditingMode == ViewModel.EditingMode.Display; }
    }
  }
}
