using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SmartWorking.Office.Gui.View.Shared
{
  /// <summary>
  /// Represents button with comment and image.
  /// </summary>
  public class DescriptionButton : Button
  {
    #region Comment

    /// <summary>
    /// The <see cref="Comment" /> dependency property's name.
    /// </summary>
    public const string CommentPropertyName = "Comment";

    /// <summary>
    /// Identifies the <see cref="Comment" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty CommentProperty = DependencyProperty.Register(
      CommentPropertyName,
      typeof (string),
      typeof (DescriptionButton),
      new UIPropertyMetadata(string.Empty));

    /// <summary>
    /// Gets or sets the value of the <see cref="Comment" />
    /// property. This is a dependency property.
    /// This string appear as comment for main Content.
    /// </summary>
    public string Comment
    {
      get { return (string) GetValue(CommentProperty); }
      set { SetValue(CommentProperty, value); }
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
      typeof (DescriptionButton),
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