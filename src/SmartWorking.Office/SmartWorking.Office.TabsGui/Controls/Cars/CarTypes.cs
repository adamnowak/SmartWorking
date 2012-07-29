using System.Collections.ObjectModel;
using SmartWorking.Office.TabsGui.Properties;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  public interface IDescriptionIndexted
  {
    int Id { get; }
    string Description { get; }
  }

  public class CarType : IDescriptionIndexted
  {
    public int Id { get; set; }
    public string Description { get; set; }
  }


  public class CarTypes  
  {
    private CarTypes()
    {
      Items = new ObservableCollection<CarType>();
    }

    private static CarTypes _instance;

    public static CarTypes Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CarTypes();
          _instance.LoadItems();
        }
        return _instance;
      }
    }

    public ObservableCollection<CarType> Items { get; private set; }

    private void LoadItems()
    {

      Items.Add(new CarType { Id = 1, Description = Resources.CarTypes_ConcreteTruckMixer });
      Items.Add(new CarType { Id = 2, Description = Resources.CarTypes_ConcreteTruckMixerWithPump });
      Items.Add(new CarType { Id = 3, Description = Resources.CarTypes_DumpTruck });
      Items.Add(new CarType { Id = 4, Description = Resources.CarTypes_Another });
    }
  }
}