using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Gui.View.Shared.Parts
{
  public class ContractorSelection : ContentControl
  {
    #region Contractor
    /// <summary>
    /// The <see cref="Contractor" /> dependency property's name.
    /// </summary>
    public const string ContractorPropertyName = "Contractor";

    /// <summary>
    /// Gets or sets the value of the <see cref="Contractor" />
    /// property. This is a dependency property.
    /// </summary>
    public ContractorPrimitive Contractor
    {
      get
      {
        return (ContractorPrimitive)GetValue(ContractorProperty);
      }
      set
      {
        SetValue(ContractorProperty, value);
      }
    }

    /// <summary>
    /// Identifies the <see cref="Contractor" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty ContractorProperty = DependencyProperty.Register(
        ContractorPropertyName,
        typeof(ContractorPrimitive),
        typeof(ContractorSelection),
        new UIPropertyMetadata(null));
    #endregion

    #region HeaderDescription
    /// <summary>
    /// The <see cref="HeaderDescription" /> dependency property's name.
    /// </summary>
    public const string HeaderDescriptionPropertyName = "HeaderDescription";

    /// <summary>
    /// Gets or sets the value of the <see cref="HeaderDescription" />
    /// property. This is a dependency property.
    /// </summary>
    public string HeaderDescription
    {
      get
      {
        return (string)GetValue(HeaderDescriptionProperty);
      }
      set
      {
        SetValue(HeaderDescriptionProperty, value);
      }
    }

    /// <summary>
    /// Identifies the <see cref="HeaderDescription" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderDescriptionProperty = DependencyProperty.Register(
        HeaderDescriptionPropertyName,
        typeof(string),
        typeof(ContractorSelection),
        new UIPropertyMetadata(string.Empty));
    #endregion

    #region ButtonDescription
    /// <summary>
    /// The <see cref="ButtonDescription" /> dependency property's name.
    /// </summary>
    public const string ButtonDescriptionPropertyName = "ButtonDescription";

    /// <summary>
    /// Gets or sets the value of the <see cref="ButtonDescription" />
    /// property. This is a dependency property.
    /// </summary>
    public string ButtonDescription
    {
      get
      {
        return (string)GetValue(ButtonDescriptionProperty);
      }
      set
      {
        SetValue(ButtonDescriptionProperty, value);
      }
    }

    /// <summary>
    /// Identifies the <see cref="ButtonDescription" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty ButtonDescriptionProperty = DependencyProperty.Register(
        ButtonDescriptionPropertyName,
        typeof(string),
        typeof(ContractorSelection),
        new UIPropertyMetadata(string.Empty));
    #endregion

    #region ButtonImage
    /// <summary>
    /// The <see cref="ButtonImage" /> dependency property's name.
    /// </summary>
    public const string ButtonImagePropertyName = "ButtonImage";

    /// <summary>
    /// Gets or sets the value of the <see cref="ButtonImage" />
    /// property. This is a dependency property.
    /// </summary>
    public BitmapImage ButtonImage
    {
      get
      {
        return (BitmapImage)GetValue(ButtonImageProperty);
      }
      set
      {
        SetValue(ButtonImageProperty, value);
      }
    }

    /// <summary>
    /// Identifies the <see cref="ButtonImage" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty ButtonImageProperty = DependencyProperty.Register(
        ButtonImagePropertyName,
        typeof(BitmapImage),
        typeof(ContractorSelection),
        new UIPropertyMetadata(null));
    #endregion

    #region ButtonCommand
    /// <summary>
    /// The <see cref="ButtonCommand" /> dependency property's name.
    /// </summary>
    public const string ButtonCommandPropertyName = "ButtonCommand";

    /// <summary>
    /// Gets or sets the value of the <see cref="ButtonCommand" />
    /// property. This is a dependency property.
    /// </summary>
    public ICommand ButtonCommand
    {
      get
      {
        return (ICommand)GetValue(ButtonCommandProperty);
      }
      set
      {
        SetValue(ButtonCommandProperty, value);
      }
    }

    /// <summary>
    /// Identifies the <see cref="ButtonCommand" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register(
        ButtonCommandPropertyName,
        typeof(ICommand),
        typeof(ContractorSelection),
        new UIPropertyMetadata(null));
    #endregion
  }
}
