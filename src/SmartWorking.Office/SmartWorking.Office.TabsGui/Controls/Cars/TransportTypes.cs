using System.Collections.ObjectModel;
using SmartWorking.Office.TabsGui.Properties;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  public class TransportType : IDescriptionIndexted
  {
    public int Id { get; set; }
    public string Description { get; set; }
  }


  public class TransportTypes 
  {
    private TransportTypes()
    {
      Items = new ObservableCollection<TransportType>();
    }

    private static TransportTypes _instance;

    public static TransportTypes Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new TransportTypes();
          _instance.LoadItems();
        }
        return _instance;
      }
    }

    public ObservableCollection<TransportType> Items { get; private set; }

    private void LoadItems()
    {
      Items.Add(new TransportType { Id = 1, Description = Resources.TransportTypes_Own });
      Items.Add(new TransportType { Id = 2, Description = Resources.TransportTypes_Rent });
      Items.Add(new TransportType { Id = 3, Description = Resources.TransportTypes_Client });
    }
  }
}