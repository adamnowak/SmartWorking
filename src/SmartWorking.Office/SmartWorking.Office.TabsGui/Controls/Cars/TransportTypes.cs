using System.Collections.ObjectModel;

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
      Items.Add(new TransportType { Id = 1, Description = "str_Transport własny" });
      Items.Add(new TransportType { Id = 2, Description = "str_Transport wynajęty" });
      Items.Add(new TransportType { Id = 3, Description = "str_Odbiór własny" });
    }
  }
}