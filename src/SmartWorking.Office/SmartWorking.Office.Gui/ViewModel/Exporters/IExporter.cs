using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.PrimitiveEntities.Reports;

namespace SmartWorking.Office.Gui.ViewModel.Exporters
{
  public interface IExporter
  {
    void DriversCarsReportExport(DriversCarsReportPackage driversCarsReportPackage, DateTime startTime, DateTime endTime, string path);
  }
}
