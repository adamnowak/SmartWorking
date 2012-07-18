using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  /// <summary>
  /// Interaction logic for CarListControl.xaml
  /// </summary>
  public partial class CarListControl : UserControl
  {
    public CarListControl()
    {
      InitializeComponent();
    }

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
        typeof(CarListControl),
        new UIPropertyMetadata(Visibility.Visible));
  }
}
