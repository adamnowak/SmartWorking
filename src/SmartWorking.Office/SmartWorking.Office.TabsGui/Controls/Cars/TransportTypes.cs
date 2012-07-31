using System.Collections.ObjectModel;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  


  public class TransportTypes 
  {
    private TransportTypes()
    {
      Items = new ObservableCollection<DescriptionIndexted>();
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

    public ObservableCollection<DescriptionIndexted> Items { get; private set; }

    private void LoadItems()
    {
      Items.Add(new DescriptionIndexted { Id = 1, Description = Resources.TransportTypes_Own });
      Items.Add(new DescriptionIndexted { Id = 2, Description = Resources.TransportTypes_Rent });
      Items.Add(new DescriptionIndexted { Id = 3, Description = Resources.TransportTypes_Client });
    }
  }
}