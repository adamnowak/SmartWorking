using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;
using SmartWorking.Office.TabsGui.Shared.View.MessageBox;
using SmartWorking.Office.TabsGui.Shared.ViewModel.MessageBox;

namespace SmartWorking.Office.TabsGui.Shared.View
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
      Control content = new TWindow();
      window.Content = content;
      window.DataContext = viewModel;
      window.Title = "str_Smart Working  (office) - " + viewModel.Title;

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

      // Checking if this thread has access to the object.
      //if (window.Dispatcher.CheckAccess())
      //{
      //  // This thread has access so it can update the UI thread.
      //  window.ShowDialog();
      //}
      //else
      //{
        // This thread does not have access to the UI thread.
        // Place the update method on the Dispatcher of the UI thread.      
      //window.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => window.ShowDialog()));
      //}



      //This implementation is from GUI (previous version)
      //EventHandler handler = null;
      //handler = delegate
      //{
      //  viewModel.RequestClose -= handler;
      //  window.Close();
      //};
      //viewModel.RequestClose += handler;
      //viewModel.Initialize();
      //if (!viewModel.Closing)
      //  window.ShowDialog();



      //TODO: do sprawdzenia; wyrzucic window.DataContext = viewModel; i w tej metodzie bindowac DataContext
      //content.Initialized += new EventHandler(content_Initialized);


      Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal,new Action(() => window.ShowDialog()));

      return viewModel.Result;
    }    
  }
}