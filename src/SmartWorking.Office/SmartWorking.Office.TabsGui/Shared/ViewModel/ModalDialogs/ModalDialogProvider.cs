using System;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup;
using SmartWorking.Office.TabsGui.Shared.View;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.MessageBox;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs
{
  public class ModalDialogProvider : ViewModelBase, IModalDialogProvider
  {
    public IServiceFactory ServiceFactory { get; private set; }
    private DispatcherFrame frame;

    public ModalDialogProvider(IServiceFactory serviceFactory)
    {
      frame = new DispatcherFrame();
      ServiceFactory = serviceFactory;
      VisibleModalDialog = VisibleModalDialogEnum.NoneModalDialog;

      MessageBoxDialogViewModel = new MessageBoxDialogViewModel(this, ServiceFactory);
      MessageBoxDialogViewModel.RequestClose += new EventHandler(MessageBoxViewModel_RequestClose);

      ProgressBarViewModel = new ProgressBarViewModel(this, ServiceFactory);
      ProgressBarViewModel.RequestClose += new EventHandler(ProgressBarViewModel_RequestClose);

      PrintPreviewViewModel = new PrintPreviewViewModel(this, ServiceFactory);
      //PrintPreviewViewModel.RequestClose += new EventHandler(PrintPreviewViewModel_RequestClose);

      LogginModalDialogViewModel = new LogginModalDialogViewModel(this, ServiceFactory);
      LogginModalDialogViewModel.RequestClose += new EventHandler(LogginModalDialogViewModel_RequestClose);

      InputModalDialogViewModel = new InputModalDialogViewModel(this, ServiceFactory);
      InputModalDialogViewModel.RequestClose += new EventHandler(InputDialogViewModel_RequestClose);
    }

    void InputDialogViewModel_RequestClose(object sender, EventArgs e)
    {
      if (frame != null)
        frame.Continue = false;
    }

    
    

    void LogginModalDialogViewModel_RequestClose(object sender, EventArgs e)
    {
      if (frame != null)
        frame.Continue = false;
    }

    void PrintPreviewViewModel_RequestClose(object sender, EventArgs e)
    {
      if (frame != null)
        frame.Continue = false;
    }

    void ProgressBarViewModel_RequestClose(object sender, EventArgs e)
    {
      if (frame != null)
        frame.Continue = false;
    }

    void MessageBoxViewModel_RequestClose(object sender, EventArgs e)
    {
      if (frame != null)
        frame.Continue = false;
    }
    #region Modal dialogs
    #region VisibleModalDialog
    /// <summary>
    /// The <see cref="VisibleModalDialog" /> property's name.
    /// </summary>
    public const string VisibleModalDialogPropertyName = "VisibleModalDialog";

    private VisibleModalDialogEnum _visibleModalDialogEnum;

    /// <summary>
    /// Gets the VisibleModalDialog property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public VisibleModalDialogEnum VisibleModalDialog
    {
      get
      {
        return _visibleModalDialogEnum;
      }

      set
      {
        if (_visibleModalDialogEnum == value)
        {
          return;
        }
        _visibleModalDialogEnum = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(VisibleModalDialogPropertyName);
      }
    }
    #endregion //VisibleModalDialog

    public MessageBoxDialogViewModel MessageBoxDialogViewModel { get; private set; }
    public ProgressBarViewModel ProgressBarViewModel { get; private set; }
    public PrintPreviewViewModel PrintPreviewViewModel { get; private set; }
    public LogginModalDialogViewModel LogginModalDialogViewModel { get; private set; }
    public InputModalDialogViewModel InputModalDialogViewModel { get; private set; }

    #endregion //Modal dialogs


    #region MessageBoxControl

    /// <summary>
    /// Shows the message box.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="icon">The icon.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="message">The message.</param>
    /// <param name="button">The button.</param>
    /// <param name="info">The info.</param>
    /// <returns>Result depends button which was pressed.</returns>
    public MessageBoxResult ShowMessageBox(IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory,
                                           MessageBoxImage icon, string caption, string message, MessageBoxButton button,
                                           string info)
    {
      //MessageBoxDialogViewModel = new MessageBoxDialogViewModel(modalDialogProvider, serviceFactory);
      MessageBoxDialogViewModel.Result = MessageBoxResult.None;
      MessageBoxDialogViewModel.Icon = icon;
      MessageBoxDialogViewModel.Caption = caption;
      MessageBoxDialogViewModel.Message = message;
      MessageBoxDialogViewModel.Button = button;
      MessageBoxDialogViewModel.Info = info;

      VisibleModalDialog = VisibleModalDialogEnum.MessageBoxModalDialog;
      frame.Continue = true;
      System.Windows.Threading.Dispatcher.PushFrame(frame); // blocks gui message pump & creates nested pump
      VisibleModalDialog = VisibleModalDialogEnum.NoneModalDialog;
      return MessageBoxDialogViewModel.Result;
    }
    //public IMainViewModel MainViewModel { get;  set; }

    #endregion

    public void ShowProgress(IProgressActionViewModel progressActionViewModel)
    {
      VisibleModalDialog = VisibleModalDialogEnum.ProgressBarModalDialog;

      ProgressBarViewModel.ProgressActionViewModel = progressActionViewModel;
      ProgressBarViewModel.ShowProgress();
      frame.Continue = true;
      System.Windows.Threading.Dispatcher.PushFrame(frame); // blocks gui message pump & creates nested pump
      VisibleModalDialog = VisibleModalDialogEnum.NoneModalDialog;
    }


    public void ShowLogginDialog(IMainViewModel mainViewModel)
    {
      LogginModalDialogViewModel.Status = string.Empty;
      LogginModalDialogViewModel.Password = string.Empty;
      VisibleModalDialog = VisibleModalDialogEnum.LogginModalDialog;
      bool failedLoggin = true;
    
    
      while (failedLoggin)
      {
        frame.Continue = true;        
        System.Windows.Threading.Dispatcher.PushFrame(frame); // blocks gui message pump & creates nested pump

        if (!LogginModalDialogViewModel.IsCanceled)
        {

          if (mainViewModel.SetAccessByUserPassword(LogginModalDialogViewModel.UserId,
                                                    LogginModalDialogViewModel.Password))
          {
            VisibleModalDialog = VisibleModalDialogEnum.NoneModalDialog;
            failedLoggin = false;
          }
          else
          {
            LogginModalDialogViewModel.Status = "Logowanie nie powiodło się.";
          }
        }
      }
    }

    public bool ShowInputDialog(string caption, string textLabel, ref string initialText, bool canTextBeEmpty)
    {
      InputModalDialogViewModel.Caption = caption;
      InputModalDialogViewModel.Text = initialText;
      InputModalDialogViewModel.TextLabel = textLabel;
      InputModalDialogViewModel.CanTextBeEmpty = canTextBeEmpty;
      VisibleModalDialog = VisibleModalDialogEnum.InputModalDialog;
      frame.Continue = true;
      System.Windows.Threading.Dispatcher.PushFrame(frame); // blocks gui message pump & creates nested pump
      VisibleModalDialog = VisibleModalDialogEnum.NoneModalDialog;
      initialText = InputModalDialogViewModel.Text;
      return !InputModalDialogViewModel.IsCanceled;
    }
  }
}