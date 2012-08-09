using System;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup
{
  public interface  IReport
  {
    FlowDocument GenerateReport(DateTime startTime, DateTime endTime, PeriodTypeValues period);
    //TODO:
    void ExportToExcel(DateTime startTime, DateTime endTime, PeriodTypeValues period);
  }
}