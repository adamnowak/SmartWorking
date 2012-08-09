using System.Collections.ObjectModel;
using SmartWorking.Office.PrimitiveEntities.Enums;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.Materials
{
  public class MaterialTypes  
  {
    private MaterialTypes()
    {
      Items = new ObservableCollection<DescriptionIndexted>();
    }

    private static MaterialTypes _instance;

    public static MaterialTypes Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new MaterialTypes();
          _instance.LoadItems();
        }
        return _instance;
      }
    }

    public ObservableCollection<DescriptionIndexted> Items { get; private set; }

    private void LoadItems()
    {
      Items.Add(new DescriptionIndexted { Id = (int)MaterialTypeEnum.Concrete, Description = Resources.MaterialTypes_LoadItems_Concrete });
      Items.Add(new DescriptionIndexted { Id = (int)MaterialTypeEnum.Aggregate, Description = Resources.MaterialTypes_LoadItems_Aggregate });
      Items.Add(new DescriptionIndexted { Id = (int)MaterialTypeEnum.Supplement, Description = Resources.MaterialTypes_LoadItems_Supplement });
      Items.Add(new DescriptionIndexted { Id = (int)MaterialTypeEnum.Admixture, Description = Resources.MaterialTypes_LoadItems_Admixture });
      Items.Add(new DescriptionIndexted { Id = (int)MaterialTypeEnum.Water, Description = Resources.MaterialTypes_LoadItems_Water });
    }
  }
}