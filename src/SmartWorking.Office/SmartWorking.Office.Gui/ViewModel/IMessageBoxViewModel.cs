using System.Windows;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Interface for message box view model.
  /// </summary>
  public interface IMessageBoxViewModel : IDialogViewModel
  {
    /// <summary>
    /// Gets the result which depends what chose user on message box window.
    /// </summary>
    MessageBoxResult Result { get; }
  }
}