using System.Windows.Controls;
using System.Windows.Input;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  /// <summary>
  /// Interface for view model for each control.
  /// </summary>
  public interface ITabControlViewModel : IControlViewModel
  {
    /// <summary>
    /// Gets or sets the selected tab.
    /// </summary>
    /// <value>
    /// The selected tab.
    /// </value>
    TabItem SelectedTab { get; set; }

    /// <summary>
    /// Gets the tab changed command.
    /// </summary>
    ICommand TabChangedCommand { get; }
  }
}