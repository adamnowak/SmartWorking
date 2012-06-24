using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Reports;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IReportsService"/>.
  /// </summary>
  public class ReportsService : IReportsService
  {
    #region IReportService Members

    
    public ReportPackage<CarPrimitive, DriverPrimitive>  GetCarsAndDriversReport(DateTime startTime, DateTime endTime) 
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          //List<Material> result =
          //  (string.IsNullOrWhiteSpace(materialNameFilter))
          //    ? ctx.Materials.Include("MaterialStocks").ToList()
          //    : ctx.Materials.Include("MaterialStocks").Where(x => x.Name.StartsWith(materialNameFilter)).ToList();
          //return result.Select(x => x.GetPrimitive()).ToList(); ;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
      return null;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
    }

    #endregion
  }
}