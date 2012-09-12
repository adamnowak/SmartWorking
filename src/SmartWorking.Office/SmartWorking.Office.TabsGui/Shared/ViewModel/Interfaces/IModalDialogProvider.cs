using System;
using System.Windows;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup;
using SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  /// <summary>
  /// Provides functionality of opening modal dialogs.
  /// </summary>
  public interface IModalDialogProvider
  { 
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
    MessageBoxResult ShowMessageBox(IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory,
                                    MessageBoxImage icon,
                                    string caption, string message, MessageBoxButton button, string info);

    #endregion

    void ShowProgress(IProgressActionViewModel progressActionViewModel);
    //IMainViewModel MainViewModel { get; set; }
    void ShowLogginDialog(IMainViewModel mainViewModel);

    bool ShowInputDialog(string caption, string textLabel, ref string initialText, bool canTextBeEmpty);
  }
}