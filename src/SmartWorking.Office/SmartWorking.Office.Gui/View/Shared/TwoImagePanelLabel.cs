using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SmartWorking.Office.Gui.View.Shared
{
  public class TwoImagePanelLabel : PanelLabel 
  {
    #region Image2

    /// <summary>
    /// The <see cref="Image" /> dependency property's name.
    /// </summary>
    public const string Image2PropertyName = "Image2";

    /// <summary>
    /// Identifies the <see cref="Image" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty Image2Property = DependencyProperty.Register(
      Image2PropertyName,
      typeof (BitmapImage),
      typeof(TwoImagePanelLabel),
      new UIPropertyMetadata(null));

    /// <summary>
    /// Gets or sets the value of the <see cref="Image" />
    /// property. This is a dependency property.
    /// This image appears on button.
    /// </summary>
    public BitmapImage Image2
    {
      get { return (BitmapImage) GetValue(Image2Property); }
      set { SetValue(Image2Property, value); }
    }

    #endregion
  }
}