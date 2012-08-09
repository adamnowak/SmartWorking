
namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public class SmartWorkingConfiguration
  {
    private SmartWorkingConfiguration()
    {
    }

    private static SmartWorkingConfiguration _instance;

    public static SmartWorkingConfiguration Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new SmartWorkingConfiguration();          
        }
        return _instance;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether delivery note will be shown on preview dialog before save and printing.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [preview delivery note]; otherwise, <c>false</c>.
    /// </value>
    public bool PreviewDeliveryNote { get; set; }
  }
}