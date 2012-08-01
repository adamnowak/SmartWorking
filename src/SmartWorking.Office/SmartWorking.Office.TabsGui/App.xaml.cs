using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using WPFLocalizeExtension.Engine;

namespace SmartWorking.Office.TabsGui
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public App()
    {
      var ci = new CultureInfo("pl-PL");
      
      LocalizeDictionary.Instance.Culture = ci;

      Thread.CurrentThread.CurrentCulture = ci;
      Thread.CurrentThread.CurrentUICulture = ci;


      //FrameworkElement.LanguageProperty.OverrideMetadata(
      //          typeof(FrameworkElement),
      //          new FrameworkPropertyMetadata(
      //              XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
      
    }
  }
}
