﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using SmartWorking.Office.Gui.ViewModel.Shared.MessageBox;

namespace SmartWorking.Office.Gui.View.Shared.MessageBox
{
  /// <summary>
  /// Provides methods for displaying modal dialogs from the View Model.
  /// </summary>
  /// <typeparam name="TWindow">The type of the modal window.</typeparam>
  public class MessageBoxHelper<TWindow>
    where TWindow : Control, new()
  {
    /// <summary>
    /// Shows the dialog and returns its result.
    /// </summary>
    /// <param name="viewModel">The view model which will be assigned to the dialog.</param>
    /// <returns>True if OK was clicked; otherwise false. Null means unspecified value.</returns>
    public static MessageBoxResult ShowDialog(IMessageBoxViewModel viewModel)
    {
      var window = new MessageBoxHelperWindow();
      var helper = new WindowInteropHelper(window);
      helper.Owner = Process.GetCurrentProcess().MainWindowHandle;
      window.Content = new TWindow();
      window.DataContext = viewModel;
      window.Title = "Smart Working  (office) - " + viewModel.Title;

      //if (window.Content is Control)
      //{
      //  window.Height = ((Control) window.Content).Height;
      //  window.Width = ((Control) window.Content).Width;
      //}
      // When the ViewModel asks to be closed, 
      // close the window.
      EventHandler handler = null;
      handler = delegate
                  {
                    viewModel.RequestClose -= handler;
                    window.Close();
                  };
      viewModel.RequestClose += handler;
      window.ShowDialog();

      return viewModel.Result;
    }
  }
}