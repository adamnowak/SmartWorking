using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.ViewModel;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.View
{
  public class LogginModalDialogViewModel : ModalDialogViewModelBase
  {
    public LogginModalDialogViewModel(IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(modalDialogProvider, serviceFactory)
    {
    }
    public override string Title
    {
      get { return "Loggin"; }
    }

    #region LogginCommand
    private ICommand _logginCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand LogginCommand
    {
      get
      {
        if (_logginCommand == null)
          _logginCommand = new RelayCommand(Loggin, CanLoggin);
        return _logginCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanLoggin()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void Loggin()
    {
        CloseModalDialog();     
    }
    #endregion //LogginCommand

    #region Password
    /// <summary>
    /// The <see cref="Password" /> property's name.
    /// </summary>
    public const string PasswordPropertyName = "Password";

    private string _password;

    /// <summary>
    /// Gets the Password property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string Password
    {
      get
      {
        return _password;
      }

      set
      {
        if (_password == value)
        {
          return;
        }
        _password = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(PasswordPropertyName);
      }
    }
    #endregion //Password

    #region UserId
    /// <summary>
    /// The <see cref="UserId" /> property's name.
    /// </summary>
    public const string UserIdPropertyName = "UserId";

    private string _userId;

    /// <summary>
    /// Gets the UserId property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string UserId
    {
      get
      {
        return _userId;
      }

      set
      {
        if (_userId == value)
        {
          return;
        }
        _userId = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(UserIdPropertyName);
      }
    }
    #endregion //UserId

    #region Status
    /// <summary>
    /// The <see cref="Status" /> property's name.
    /// </summary>
    public const string StatusPropertyName = "Status";

    private string _status;

    /// <summary>
    /// Gets the Status property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string Status
    {
      get
      {
        return _status;
      }

      set
      {
        if (_status == value)
        {
          return;
        }
        _status = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(StatusPropertyName);
        RaisePropertyChanged(IsStatusShownPropertyName);
      }
    }
    #endregion //Status

    #region IsStatusShown
    /// <summary>
    /// The <see cref="IsStatusShown" /> property's name.
    /// </summary>
    public const string IsStatusShownPropertyName = "IsStatusShown";

    /// <summary>
    /// Gets the IsStatusShown property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool IsStatusShown
    {
      get
      {
        return !string.IsNullOrEmpty(Status) && Status.Length > 0;
      }

      
    }
    #endregion //IsStatusShown
  }
}