using System.Windows.Controls;
using System.Windows.Input;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup
{
  /// <summary>
  /// Interaction logic for ReportsGroupControl.xaml
  /// </summary>
  public partial class ReportsGroupControl : UserControl
  {
    public ReportsGroupControl()
    {
      InitializeComponent();
    }

    private void calendar_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      
      base.OnPreviewMouseUp(e);
      if (Mouse.Captured is Calendar || Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
      {
        Mouse.Capture(null);
      }
    
    }
  }
}
