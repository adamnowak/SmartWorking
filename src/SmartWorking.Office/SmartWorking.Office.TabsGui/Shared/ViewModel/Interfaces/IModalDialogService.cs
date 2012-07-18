using System.Windows;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  /// <summary>
  /// Provides functionality of opening modal dialogs.
  /// </summary>
  public interface IModalDialogService
  { 
    #region MessageBox

    /// <summary>
    /// Shows the message box.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    /// <param name="icon">The icon.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="message">The message.</param>
    /// <param name="button">The button.</param>
    /// <param name="info">The info.</param>
    /// <returns>Result depends button which was pressed.</returns>
    MessageBoxResult ShowMessageBox(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                    MessageBoxImage icon,
                                    string caption, string message, MessageBoxButton button, string info);

    #endregion
  }
}