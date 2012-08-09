using System.Collections.ObjectModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Enums;
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
      Items.Add(new DescriptionIndexted { Id = (int)TransportTypeEnum.Own, Description = Resources.TransportTypes_Own });
      Items.Add(new DescriptionIndexted { Id = (int)TransportTypeEnum.Rent, Description = Resources.TransportTypes_Rent });
      Items.Add(new DescriptionIndexted { Id = (int)TransportTypeEnum.Client, Description = Resources.TransportTypes_Client });
    }
  }
}