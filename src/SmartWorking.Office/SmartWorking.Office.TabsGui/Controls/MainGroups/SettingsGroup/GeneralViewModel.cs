using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class GeneralViewModel : TabControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public GeneralViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
    }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "General"; }
    }

    #region CreateDbDumpCommand
    private ICommand _createDBDumpCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand CreateDbDumpCommand
    {
      get
      {
        if (_createDBDumpCommand == null)
          _createDBDumpCommand = new RelayCommand(CreateDBDumpCommand, CanCreateDBDumpCommand);
        return _createDBDumpCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanCreateDBDumpCommand()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void CreateDBDumpCommand()
    {
      string errorCaption = "TODO!";
      try
      {
        string pathName = "dump" + DateTime.Now.ToFileTime() + ".txt";

        ModalDialogProvider.ShowProgress(new DBDumpProgressActionViewModel(MainViewModel, ServiceFactory, pathName) { Text = "Tworzenie bakcup'u...." });
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }
    #endregion //CreateDbDumpCommand


    #region TestCommand
    private ICommand _testCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand TestCommand
    {
      get
      {
        if (_testCommand == null)
          _testCommand = new RelayCommand(Test, CanTest);
        return _testCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanTest()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void Test()
    {
      string errorCaption = "TODO!";
      try
      {
        MessageBoxResult messageBoxResult = ModalDialogProvider.ShowMessageBox(ModalDialogProvider, ServiceFactory, MessageBoxImage.Question, "caption",
                                           "message", MessageBoxButton.OKCancel, "info");
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }
    #endregion //TestCommand
  }
}
