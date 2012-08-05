using System;
using System.Globalization;
using System.Windows.Data;

namespace SmartWorking.Office.TabsGui.Converters
{
  /// <summary>
  /// Converts <see cref="DialogMode"/> to Visibility.
  /// </summary>  
  public class ComparingMultiExConverter : IMultiValueConverter
  {
    #region IMultiValueConverter Members

    /// <summary>
    /// Compare two first element in values array and return values[2] if the elements are equal; otherwise values[3].
    /// </summary>
    /// <param name="values">The array of values that the source bindings in the <see cref="T:System.Windows.Data.MultiBinding"/> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue"/> indicates that the source binding has no value to provide for conversion.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>
    /// If <paramref name="values[0]"/> is equal <paramref name="values[1]"/> then returns <paramref name="values[2]"/>; otherwise <paramref name="values[3]"/>.
    /// If number of elements in values array is less than 4 than returns <c>null</c>.
    /// </returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      if (values.Length == 0)
        return null;
      for (int i = 0; i < values.Length - 1;i++ )
      {
        if (i < values.Length - 2 )
        {
          if (values[i] is bool && (bool)values[i])
          {
            return values[i+1];
          }
        }
      }
      return values[values.Length - 1];
    }

    /// <summary>
    /// Converts a binding target value to the source binding values.
    /// </summary>
    /// <param name="value">The value that the binding target produces.</param>
    /// <param name="targetTypes">The array of types to convert to. The array length indicates the number and types of values that are suggested for the method to return.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>
    /// An array of values that have been converted from the target value back to the source values.
    /// </returns>
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}