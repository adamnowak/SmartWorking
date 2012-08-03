using System.Collections.ObjectModel;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup
{
  public class MonthTypes  
  {
    private MonthTypes()
    {
      Items = new ObservableCollection<DescriptionIndexted>();
    }

    private static MonthTypes _instance;

    public static MonthTypes Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new MonthTypes();
          _instance.LoadItems();
        }
        return _instance;
      }
    }

    public ObservableCollection<DescriptionIndexted> Items { get; private set; }

    private void LoadItems()
    {
      Items.Add(new DescriptionIndexted { Id = 1, Description = "January" });
      Items.Add(new DescriptionIndexted { Id = 2, Description = "February" });
      Items.Add(new DescriptionIndexted { Id = 3, Description = "March" });
      Items.Add(new DescriptionIndexted { Id = 4, Description = "April" });
      Items.Add(new DescriptionIndexted { Id = 5, Description = "May" });
      Items.Add(new DescriptionIndexted { Id = 6, Description = "June" });
      Items.Add(new DescriptionIndexted { Id = 7, Description = "July" });
      Items.Add(new DescriptionIndexted { Id = 8, Description = "August" });
      Items.Add(new DescriptionIndexted { Id = 9, Description = "Septembber" });
      Items.Add(new DescriptionIndexted { Id = 10, Description = "October" });
      Items.Add(new DescriptionIndexted { Id = 11, Description = "November" });
      Items.Add(new DescriptionIndexted { Id = 12, Description = "December" });
    }
  }
}