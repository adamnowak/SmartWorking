using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup
{
  public class ProgressActionViewModelBase : ViewModelBase, IProgressActionViewModel
  {
    public ProgressActionViewModelBase()
    {
      ActionStatus = ProgressActionStatusEnum.NotStarted;
    }

    public ProgressActionStatusEnum ActionStatus { get; protected set; }

    public virtual void Action()
    {
      try
      {
        OnAction();
        ActionStatus = ProgressActionStatusEnum.Completed;
      }
      catch (Exception e)
      {
        Exception = e;
        ActionStatus = ProgressActionStatusEnum.Error;
      }
    }

   
    public void Error(Exception exception)
    {
      try
      {
        OnError(exception);
      }
      catch (Exception e)
      { 
        Exception = e;
      }
      ActionStatus = ProgressActionStatusEnum.Error;
    }

    
    public void Completed()
    {
      try
      {
        OnCompleted();
        ActionStatus = ProgressActionStatusEnum.Completed;
      }
      catch (Exception e)
      {
        ActionStatus = ProgressActionStatusEnum.Error;
        Exception = e;
      }
    }

    ICommand IProgressActionViewModel.Cancel
    {
      get { throw new NotImplementedException(); }
    }

    protected virtual void OnAction()
    {
    }

    protected virtual void OnError(Exception exception)
    {
    }

    public virtual void OnCompleted()
    {
    }

    protected virtual void OnCancel()
    {
    }

    #region CancelCommand
    private ICommand _cancelCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand CancelCommand
    {
      get
      {
        if (_cancelCommand == null)
          _cancelCommand = new RelayCommand(Cancel, CanCancel);
        return _cancelCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanCancel()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void Cancel()
    {
      string errorCaption = "TODO!";
      try
      {
        OnCancel();
        ActionStatus = ProgressActionStatusEnum.Canceled;
      }      
      catch (Exception e)
      {
        ActionStatus = ProgressActionStatusEnum.Error;
        Exception = e;
      }
    }

    

    #endregion //CancelCommand

    public Exception Exception { get; set; }

    public string Text { get; set; }
  }
}