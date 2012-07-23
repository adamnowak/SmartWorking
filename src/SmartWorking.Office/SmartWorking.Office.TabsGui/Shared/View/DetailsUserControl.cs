using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SmartWorking.Office.TabsGui.Controls.Cars;

namespace SmartWorking.Office.TabsGui.Shared.View
{
  public class DetailsUserControl : UserControl
  {
    //not used yet!!!!!
    #region IsReadOnlyDependencyProperty
    /// <summary>
    /// The <see cref="IsReadOnly" /> dependency property's name.
    /// </summary>
    public const string IsReadOnlyPropertyName = "IsReadOnly";

    /// <summary>
    /// Gets or sets the value of the <see cref="IsReadOnly" />
    /// property. This is a dependency property.
    /// </summary>
    public bool IsReadOnly
    {
      get
      {
        return (bool )GetValue(IsReadOnlyProperty);
      }
      set
      {
        SetValue(IsReadOnlyProperty, value);
      }
    }

    /// <summary>
    /// Identifies the <see cref="IsReadOnly" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
        IsReadOnlyPropertyName,
        typeof(bool ),
        typeof(DetailsUserControl),
        new UIPropertyMetadata(false));
    #endregion //IsReadOnlyDependencyProperty
  }
}
