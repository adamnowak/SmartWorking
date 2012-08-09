using System.Collections.ObjectModel;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup
{
  public enum PeriodTypeValues
  {
    Daily = 1,
    Monthly = 2,
    Custom = 3
  }

  public class PeriodTypes  
  {

    public static string GetString(PeriodTypeValues periodTypeValues)
    {
      switch (periodTypeValues)
      {
        case PeriodTypeValues.Daily:
          return "Dzienny";

        case PeriodTypeValues.Monthly:
          return "Miesięczny";
        case PeriodTypeValues.Custom:
          return "Okresowy";
          
      }
      return "NotDefined";
    }

    private PeriodTypes()
    {
      Items = new ObservableCollection<DescriptionIndexted<PeriodTypeValues>>();
    }

    private static PeriodTypes _instance;

    public static PeriodTypes Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PeriodTypes();
          _instance.LoadItems();
        }
        return _instance;
      }
    }

    public ObservableCollection<DescriptionIndexted<PeriodTypeValues>> Items { get; private set; }

    private void LoadItems()
    {
      Items.Add(new DescriptionIndexted<PeriodTypeValues> { Id = PeriodTypeValues.Daily, Description = "Daily" });
      Items.Add(new DescriptionIndexted<PeriodTypeValues> { Id = PeriodTypeValues.Monthly, Description = "Monthly" });
      Items.Add(new DescriptionIndexted<PeriodTypeValues> { Id = PeriodTypeValues.Custom, Description = "Custom" });
    }
  }
}