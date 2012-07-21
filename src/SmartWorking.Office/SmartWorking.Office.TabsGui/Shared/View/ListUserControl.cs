using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SmartWorking.Office.TabsGui.Controls.Cars;

namespace SmartWorking.Office.TabsGui.Shared.View
{
  public class ListUserControl : UserControl
  {
    #region FiltersVisibility
    /// <summary>
    /// The <see cref="FiltersVisibility" /> dependency property's name.
    /// </summary>
    public const string FiltersVisibilityPropertyName = "FiltersVisibility";

    /// <summary>
    /// Gets or sets the value of the <see cref="FiltersVisibility" />
    /// property. This is a dependency property.
    /// </summary>
    public Visibility FiltersVisibility
    {
      get
      {
        return (Visibility)GetValue(FiltersVisibilityProperty);
      }
      set
      {
        SetValue(FiltersVisibilityProperty, value);
      }
    }

    /// <summary>
    /// Identifies the <see cref="FiltersVisibility" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty FiltersVisibilityProperty = DependencyProperty.Register(
        FiltersVisibilityPropertyName,
        typeof(Visibility),
        typeof(ListUserControl),
        new UIPropertyMetadata(Visibility.Visible));
    #endregion //FiltersVisibility
  }
}
