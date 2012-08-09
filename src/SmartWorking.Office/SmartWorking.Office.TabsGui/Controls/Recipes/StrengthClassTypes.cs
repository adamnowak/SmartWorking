using System.Collections.ObjectModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Enums;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.Recipes
{

  public class StrengthClassTypes
  {
    private StrengthClassTypes()
    {
      Items = new ObservableCollection<DescriptionIndexted>();
    }

    private static StrengthClassTypes _instance;

    public static StrengthClassTypes Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StrengthClassTypes();
          _instance.LoadItems();
        }
        return _instance;
      }
    }

    public ObservableCollection<DescriptionIndexted> Items { get; private set; }

    private void LoadItems()
    {
      Items.Add(new DescriptionIndexted { Id = (int)StrengthClassTypeEnum.Slow, Description = "Wolny" });
      Items.Add(new DescriptionIndexted { Id = (int)StrengthClassTypeEnum.Moderate, Description = "Umiarkowany" });
      Items.Add(new DescriptionIndexted { Id = (int)StrengthClassTypeEnum.Fast, Description = "Szybki" });
      Items.Add(new DescriptionIndexted { Id = (int)StrengthClassTypeEnum.Another, Description = "Inny" });
    }
  }
}