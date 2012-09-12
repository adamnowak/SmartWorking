using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.ViewModel;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.MessageBox
{
  

  /// <summary>
  /// View model for <see cref="MessageBox"/> dialog. 
  /// </summary>
  public class InputModalDialogViewModel : ModalDialogViewModelBase
  {

    private ICommand _okCommand;

    public override string Title
    {
      get { return "InputDialog"; }
    }

    protected override void Cancel()
    {
      
      base.Cancel();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageBoxDialogViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="icon">The icon.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="message">The message.</param>
    /// <param name="button">The button.</param>
    /// <param name="info">The info.</param>
    public InputModalDialogViewModel(IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(modalDialogProvider, serviceFactory)
    {
    
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
                                 CloseModalDialog(false);
                               }, CanOkCommand);
        return _okCommand;
      }
    }

    public bool CanTextBeEmpty { get; set; }

    private bool CanOkCommand()
    {
      return (!CanTextBeEmpty ) ? !string.IsNullOrEmpty(Text) : true;
    }

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

      set
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
    /// The <see cref="TextLabel" /> property's name.
    /// </summary>
    public const string TextLabelPropertyName = "TextLabel";

    private string _textLabel;

    /// <summary>
    /// Gets the Message property.
    /// Represents message which will appear on message box.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string TextLabel
    {
      get { return _textLabel; }

      set
      {
        if (_textLabel == value)
        {
          return;
        }
        _textLabel = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(TextLabelPropertyName);
      }
    }

    #endregion //Message


    #region Text

    /// <summary>
    /// The <see cref="Text" /> property's name.
    /// </summary>
    public const string TextPropertyName = "Text";

    private string _text;

    /// <summary>
    /// Gets the Info property.
    /// Represents information which can be displayed additionally on message box.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string Text
    {
      get { return _text; }

      set
      {
        if (_text == value)
        {
          return;
        }
        _text = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(TextPropertyName);
      }
    }

    #endregion //Info

  }
}