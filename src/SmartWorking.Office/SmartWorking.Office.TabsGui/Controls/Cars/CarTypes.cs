using System.Collections.ObjectModel;
using SmartWorking.Office.PrimitiveEntities.Enums;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  public class CarTypes  
  {
    private CarTypes()
    {
      Items = new ObservableCollection<DescriptionIndexted>();
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

    public ObservableCollection<DescriptionIndexted> Items { get; private set; }

    private void LoadItems()
    {

      Items.Add(new DescriptionIndexted { Id = (int)CarTypeEnum.ConcreteTruckMixer, Description = Resources.CarTypes_ConcreteTruckMixer });
      Items.Add(new DescriptionIndexted { Id = (int)CarTypeEnum.ConcreteTruckMixerWithPump, Description = Resources.CarTypes_ConcreteTruckMixerWithPump });
      Items.Add(new DescriptionIndexted { Id = (int)CarTypeEnum.DumpTruck, Description = Resources.CarTypes_DumpTruck });
      Items.Add(new DescriptionIndexted { Id = (int)CarTypeEnum.Another, Description = Resources.CarTypes_Another });
    }
  }
}