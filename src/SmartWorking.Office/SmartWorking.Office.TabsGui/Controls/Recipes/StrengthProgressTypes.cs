using System.Collections.ObjectModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Enums;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.Recipes
{

  public class StrengthProgressTypes
  {
    private StrengthProgressTypes()
    {
      Items = new ObservableCollection<DescriptionIndexted>();
    }

    private static StrengthProgressTypes _instance;

    public static StrengthProgressTypes Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StrengthProgressTypes();
          _instance.LoadItems();
        }
        return _instance;
      }
    }

    public ObservableCollection<DescriptionIndexted> Items { get; private set; }

    private void LoadItems()
    {
      Items.Add(new DescriptionIndexted { Id = (int)StrengthClassTypeEnum.Slow, Description = Resources.StrengthProgressTypes_LoadItems_Slow });
      Items.Add(new DescriptionIndexted { Id = (int)StrengthClassTypeEnum.Moderate, Description = Resources.StrengthProgressTypes_LoadItems_Moderate });
      Items.Add(new DescriptionIndexted { Id = (int)StrengthClassTypeEnum.Fast, Description = Resources.StrengthProgressTypes_LoadItems_Fast });
      Items.Add(new DescriptionIndexted { Id = (int)StrengthClassTypeEnum.Another, Description = Resources.StrengthProgressTypes_LoadItems_Another });
    }
  }
}