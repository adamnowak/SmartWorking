using System.Windows.Input;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  /// <summary>
  /// 
  /// </summary>
  public interface ITabItemViewModel : IControlViewModel
  {


    /// <summary>
    /// Gets the refresh command (refresh tab item - each element which is read only).
    /// </summary>
    ICommand RefreshCommand { get; }
  }
}