using System;
using SmartWorking.Office.Gui.ViewModel;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs;

namespace SmartWorking.Office.TabsGui.Shared.View
{
  public class ProgressBarViewModel : ModalDialogViewModelBase
  {
    public IProgressActionViewModel ProgressActionViewModel { get; set; }

    public ProgressBarViewModel(IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(modalDialogProvider, serviceFactory)
    {
    }

    public override string Title
    {
      get { return "Progress"; }
    }

    #region ProgressText
    /// <summary>
    /// The <see cref="ProgressText" /> property's name.
    /// </summary>
    public const string ProgressTextPropertyName = "ProgressText";

    private string _progressText;

    /// <summary>
    /// Gets the ProgressText property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string ProgressText
    {
      get
      {
        return _progressText;
      }

      set
      {
        if (_progressText == value)
        {
          return;
        }
        _progressText = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(ProgressTextPropertyName);
      }
    }
    #endregion //ProgressText

    private void OnError(Exception exception)
    {
      ProgressActionViewModel.Error(exception);
      this.CloseModalDialog(true);
    }

    private void OnComplete(object obj)
    {
      ProgressActionViewModel.Completed();
      this.CloseModalDialog();
    }

    public void ShowProgress()
    {
      if (ProgressActionViewModel != null)
      {
        ProgressText = ProgressActionViewModel.Text;
        AsyncDelegateCommand asyncDelegateCommand = new AsyncDelegateCommand(ProgressActionViewModel.Action,
                                                                             () => true, OnComplete, OnError);
        asyncDelegateCommand.Execute(null);

      }
    }
  }
}