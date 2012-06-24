using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SmartWorking.Office.Gui.View.Shared
{
  /// <summary>
  /// Extents functionality of <see cref="DataGrid"/>.
  /// </summary>
  public static class DataGridExtension
  {
    /// <summary>
    /// Specifies dependency property which represents columns in <see cref="DataGrid"/>.
    /// </summary>
    public static readonly DependencyProperty ColumnsProperty = DependencyProperty.RegisterAttached("Columns",
                                                                                                    typeof (
                                                                                                      ObservableCollection
                                                                                                      <DataGridColumn>),
                                                                                                    typeof (
                                                                                                      DataGridExtension
                                                                                                      ),
                                                                                                    new UIPropertyMetadata
                                                                                                      (new ObservableCollection
                                                                                                         <DataGridColumn
                                                                                                         >(),
                                                                                                       OnDataGridColumnsPropertyChanged));

    /// <summary>
    /// Gets the columns.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns></returns>
    public static ObservableCollection<DataGridColumn> GetColumns(DependencyObject obj)
    {
      return (ObservableCollection<DataGridColumn>) obj.GetValue(ColumnsProperty);
    }

    /// <summary>
    /// Sets the columns.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <param name="value">The value.</param>
    public static void SetColumns(DependencyObject obj, ObservableCollection<DataGridColumn> value)
    {
      obj.SetValue(ColumnsProperty, value);
    }


    /// <summary>
    /// Called when property of <see cref="DataGridColumn"/> changes.
    /// </summary>
    /// <param name="d">The d.</param>
    /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
    private static void OnDataGridColumnsPropertyChanged(DependencyObject d,
                                                         DependencyPropertyChangedEventArgs e)
    {
      if (d is DataGrid)
      {
        var myGrid = d as DataGrid;

        var Columns = (ObservableCollection<DataGridColumn>) e.NewValue;

        if (Columns != null)
        {
          myGrid.Columns.Clear();

          if (Columns != null && Columns.Count > 0)
          {
            foreach (DataGridColumn dataGridColumn in Columns)
            {
              myGrid.Columns.Add(dataGridColumn);
            }
          }


          Columns.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs args)
                                         {
                                           if (args.NewItems != null)
                                           {
                                             foreach (DataGridColumn column in args.NewItems.Cast<DataGridColumn>())
                                             {
                                               myGrid.Columns.Add(column);
                                             }
                                           }

                                           if (args.OldItems != null)
                                           {
                                             foreach (DataGridColumn column in args.OldItems.Cast<DataGridColumn>())
                                             {
                                               myGrid.Columns.Remove(column);
                                             }
                                           }
                                         };
        }
      }
    }
  }
}