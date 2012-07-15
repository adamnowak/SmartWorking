using System;
using System.Windows;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.MessageBox;
using MessageBoxClass = SmartWorking.Office.TabsGui.Shared.View.MessageBox.MessageBox;

namespace SmartWorking.Office.TabsGui.Shared.View
{
  public class ModalDialogService : IModalDialogService
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
    public MessageBoxResult ShowMessageBox(IModalDialogService modalDialogService, IServiceFactory serviceFactory,
                                           MessageBoxImage icon, string caption, string message, MessageBoxButton button,
                                           string info)
    {
      var viewModel = new MessageBoxViewModel(modalDialogService, serviceFactory, icon, caption, message, button, info);
      return MessageBoxHelper<MessageBoxClass>.ShowDialog(viewModel);
    }

    #endregion
  }
}