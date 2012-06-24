using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartWorking.Office.Gui.View.Shared
{
  /// <summary>
  /// Attached properties for <see cref="DataGrid"/>.
  /// </summary>
  public static class DataGridCommands
  {
    #region DataGridDoubleClickCommand

    //http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/632ea875-a5b8-4d47-85b3-b30f28e0b827
    /// <summary>
    /// De
    /// </summary>
    public static readonly DependencyProperty DataGridDoubleClickProperty =
      DependencyProperty.RegisterAttached("DataGridDoubleClickCommand", typeof (ICommand), typeof (DataGridCommands),
                                          new PropertyMetadata(
                                            new PropertyChangedCallback(AttachOrRemoveDataGridDoubleClickEvent)));

    public static ICommand GetDataGridDoubleClickCommand(DependencyObject obj)
    {
      return (ICommand) obj.GetValue(DataGridDoubleClickProperty);
    }

    public static void SetDataGridDoubleClickCommand(DependencyObject obj, ICommand value)
    {
      obj.SetValue(DataGridDoubleClickProperty, value);
    }

    public static void AttachOrRemoveDataGridDoubleClickEvent(DependencyObject obj,
                                                              DependencyPropertyChangedEventArgs args)
    {
      var dataGrid = obj as DataGrid;
      if (dataGrid != null)
      {
        var cmd = (ICommand) args.NewValue;

        if (args.OldValue == null && args.NewValue != null)
        {
          dataGrid.MouseDoubleClick += ExecuteDataGridDoubleClick;
        }
        else if (args.OldValue != null && args.NewValue == null)
        {
          dataGrid.MouseDoubleClick -= ExecuteDataGridDoubleClick;
        }
      }
    }

    private static void ExecuteDataGridDoubleClick(object sender, MouseButtonEventArgs args)
    {
      var obj = sender as DependencyObject;
      var cmd = (ICommand) obj.GetValue(DataGridDoubleClickProperty);
      if (cmd != null)
      {
        if (cmd.CanExecute(obj))
        {
          cmd.Execute(obj);
        }
      }
    }

    #endregion
  }
}