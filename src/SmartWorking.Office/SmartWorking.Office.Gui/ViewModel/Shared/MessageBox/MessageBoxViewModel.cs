using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Shared.MessageBox
{
  /// <summary>
  /// View model for <see cref="MessageBox"/> dialog. 
  /// </summary>
  public class MessageBoxViewModel : DialogViewModelBase, IMessageBoxViewModel
  {
    private ICommand _noCommand;
    private ICommand _okCommand;
    private ICommand _yesCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageBoxViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="icon">The icon.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="message">The message.</param>
    /// <param name="button">The button.</param>
    /// <param name="info">The info.</param>
    public MessageBoxViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                               MessageBoxImage icon, string caption, string message, MessageBoxButton button,
                               string info)
      : base(modalDialogService, serviceFactory)
    {
      Icon = icon;
      Caption = caption;
      Message = message;
      Button = button;
      Info = info;
      Result = MessageBoxResult.Cancel;
    }

    /// <summary>
    /// Gets the "Ok" button command.
    /// </summary>
    public ICommand OkCommand
    {
      get
      {
        if (_okCommand == null)
          _okCommand =
            new RelayCommand(() =>
                               {
                                 Result = MessageBoxResult.OK;
                                 CloseModalDialog(true);
                               });
        return _okCommand;
      }
    }

    /// <summary>
    /// Gets the "Yes" button command.
    /// </summary>
    public ICommand YesCommand
    {
      get
      {
        if (_yesCommand == null)
          _yesCommand =
            new RelayCommand(() =>
                               {
                                 Result = MessageBoxResult.Yes;
                                 CloseModalDialog(true);
                               });
        return _yesCommand;
      }
    }

    /// <summary>
    /// Gets the "No" button command.
    /// </summary>
    public ICommand NoCommand
    {
      get
      {
        if (_noCommand == null)
          _noCommand =
            new RelayCommand(() =>
                               {
                                 Result = MessageBoxResult.No;
                                 CloseModalDialog(true);
                               });
        return _noCommand;
      }
    }

    #region IMessageBoxViewModel Members

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get { return Caption; }
    }

    #endregion

    #region Icon

    /// <summary>
    /// The <see cref="Icon" /> property's name.
    /// </summary>
    public const string IconPropertyName = "Icon";

    private MessageBoxImage _messageBoxImage;

    /// <summary>
    /// Gets the Icon property. Depends from this value another icon will be displayed on messagebox.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public MessageBoxImage Icon
    {
      get { return _messageBoxImage; }

      private set
      {
        if (_messageBoxImage == value)
        {
          return;
        }
        _messageBoxImage = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(IconPropertyName);
      }
    }

    #endregion //Icon

    #region Caption

    /// <summary>
    /// The <see cref="Caption" /> property's name.
    /// </summary>
    public const string CaptionPropertyName = "Caption";

    private string _caption;

    /// <summary>
    /// Gets the Caption property.
    /// Represents caption which will appear on message box.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string Caption
    {
      get { return _caption; }

      private set
      {
        if (_caption == value)
        {
          return;
        }
        _caption = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(CaptionPropertyName);
      }
    }

    #endregion //Caption

    #region Message

    /// <summary>
    /// The <see cref="Message" /> property's name.
    /// </summary>
    public const string MessagePropertyName = "Message";

    private string _message;

    /// <summary>
    /// Gets the Message property.
    /// Represents message which will appear on message box.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string Message
    {
      get { return _message; }

      private set
      {
        if (_message == value)
        {
          return;
        }
        _message = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(MessagePropertyName);
      }
    }

    #endregion //Message

    #region Button

    /// <summary>
    /// The <see cref="Button" /> property's name.
    /// </summary>
    public const string ButtonPropertyName = "Button";

    private MessageBoxButton _button;

    /// <summary>
    /// Gets the Button property.
    /// Defines button which will appear on message box.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public MessageBoxButton Button
    {
      get { return _button; }

      private set
      {
        if (_button == value)
        {
          return;
        }
        _button = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(ButtonPropertyName);
      }
    }

    #endregion //Button

    #region Info

    /// <summary>
    /// The <see cref="Info" /> property's name.
    /// </summary>
    public const string InfoPropertyName = "Info";

    private string _info;

    /// <summary>
    /// Gets the Info property.
    /// Represents information which can be displayed additionally on message box.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string Info
    {
      get { return _info; }

      private set
      {
        if (_info == value)
        {
          return;
        }
        _info = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(InfoPropertyName);
      }
    }

    #endregion //Info

    #region Result

    /// <summary>
    /// The <see cref="Result" /> property's name.
    /// </summary>
    public const string ResultPropertyName = "Result";

    private MessageBoxResult _messageBoxResult;


    /// <summary>
    /// Gets the Result property.
    /// Hold information which button was pressed by user.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public MessageBoxResult Result
    {
      get { return _messageBoxResult; }

      set
      {
        if (_messageBoxResult == value)
        {
          return;
        }
        _messageBoxResult = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(ResultPropertyName);
      }
    }

    #endregion //Result
  }
}