using System.Collections.ObjectModel;
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
      Items.Add(new DescriptionIndexted {Id = 1, Description = "Wolny"});
      Items.Add(new DescriptionIndexted { Id = 2, Description = "Umiarkowany" });
      Items.Add(new DescriptionIndexted { Id = 3, Description = "Szybki" });
      Items.Add(new DescriptionIndexted { Id = 4, Description = "Inny" });
    }
  }
}