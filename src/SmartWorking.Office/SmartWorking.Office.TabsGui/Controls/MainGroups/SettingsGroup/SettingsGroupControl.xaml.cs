using System;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup
{
  /// <summary>
  /// Interaction logic for SettingsGroupControl.xaml
  /// </summary>
  public partial class SettingsGroupControl : UserControl
  {
    public SettingsGroupControl()
    {
      InitializeComponent();
      LoadLicense();
    }

    private void LoadLicense()
    {
      try
      {
        Paragraph paragraph = new Paragraph();
        paragraph.Inlines.Add(System.IO.File.ReadAllText("license.txt"));
        LicenseDocument = new FlowDocument(paragraph);
        FlowDocReader.Document = LicenseDocument;

      }
      catch (Exception)
      {
        
        //todo:
      }
      
    }

    public FlowDocument LicenseDocument { get; private set; }
  }
}
