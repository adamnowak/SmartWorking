using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SmartWorking.Office.Gui.View.Shared
{
  public class PanelLabel : ContentControl
  {
    #region Header

    /// <summary>
    /// The <see cref="HeaderStyle" /> dependency property's name.
    /// </summary>
    public const string HeaderStylePropertyName = "HeaderStyle";

    /// <summary>
    /// The <see cref="Header" /> dependency property's name.
    /// </summary>
    public const string HeaderPropertyName = "Header";

    /// <summary>
    /// Identifies the <see cref="HeaderStyle" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderStyleProperty = DependencyProperty.Register(
      HeaderStylePropertyName,
      typeof (Style),
      typeof (PanelLabel),
      new UIPropertyMetadata(null));

    /// <summary>
    /// Identifies the <see cref="Header" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
      HeaderPropertyName,
      typeof (string),
      typeof (PanelLabel),
      new UIPropertyMetadata(string.Empty));

    /// <summary>
    /// Gets or sets the value of the <see cref="HeaderStyle" />
    /// property. This is a dependency property.
    /// </summary>
    public Style HeaderStyle
    {
      get { return (Style) GetValue(HeaderStyleProperty); }
      set { SetValue(HeaderStyleProperty, value); }
    }

    /// <summary>
    /// Gets or sets the value of the <see cref="Header" />
    /// property. This is a dependency property.
    /// </summary>
    public string Header
    {
      get { return (string) GetValue(HeaderProperty); }
      set { SetValue(HeaderProperty, value); }
    }

    #endregion

    #region Description

    /// <summary>
    /// The <see cref="Description" /> dependency property's name.
    /// </summary>
    public const string DescriptionPropertyName = "Description";

    /// <summary>
    /// Identifies the <see cref="Description" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
      DescriptionPropertyName,
      typeof (string),
      typeof (PanelLabel),
      new UIPropertyMetadata(string.Empty));

    /// <summary>
    /// Gets or sets the value of the <see cref="Description" />
    /// property. This is a dependency property.
    /// </summary>
    public string Description
    {
      get { return (string) GetValue(DescriptionProperty); }
      set { SetValue(DescriptionProperty, value); }
    }

    #endregion

    #region Image

    /// <summary>
    /// The <see cref="Image" /> dependency property's name.
    /// </summary>
    public const string ImagePropertyName = "Image";

    /// <summary>
    /// Identifies the <see cref="Image" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
      ImagePropertyName,
      typeof (BitmapImage),
      typeof (PanelLabel),
      new UIPropertyMetadata(null));

    /// <summary>
    /// Gets or sets the value of the <see cref="Image" />
    /// property. This is a dependency property.
    /// This image appears on button.
    /// </summary>
    public BitmapImage Image
    {
      get { return (BitmapImage) GetValue(ImageProperty); }
      set { SetValue(ImageProperty, value); }
    }

    #endregion
  }
}