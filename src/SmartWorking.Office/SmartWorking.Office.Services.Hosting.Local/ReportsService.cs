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


    public DriversCarsReportPackage GetDriversCarsDataReport(DateTime startTime, DateTime endTime)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          DriversCarsReportPackage result = new DriversCarsReportPackage();
          List<DeliveryNote> allDeliveryNotes =
            ctx.DeliveryNotes.Include("Car").Include("Driver").Where(x => !x.Canceled.HasValue && x.DateDrawing >= startTime && x.DateDrawing <= endTime).ToList();
          foreach (DeliveryNote deliveryNote in allDeliveryNotes)
          {
            if (deliveryNote.Car != null)
            {
              if (result.ColumntElements.Where(x => x.Id == deliveryNote.Car.Id).FirstOrDefault() == null)
              {
                result.ColumntElements.Add(deliveryNote.Car.GetPrimitive());
              }
            }
            if (deliveryNote.Driver != null)
            {
              if (result.RowElements.Where(x => x.Id == deliveryNote.Driver.Id).FirstOrDefault() == null)
              {
                result.RowElements.Add(deliveryNote.Driver.GetPrimitive());
              }
            }

            ReportRow row = result.RowValues.Where(x => x.Id == deliveryNote.Driver_Id).FirstOrDefault();
            if (row == null)
            {
              row = new ReportRow();
              row.Id = deliveryNote.Driver_Id.Value;
              row.ReportValues.Add(new ReportValue()
                               {Id = deliveryNote.Car_Id.Value, Amount = deliveryNote.Amount, NoOfTransports = 1});
              result.RowValues.Add(row);
            }
            else
            {
              ReportValue reportValue = row.ReportValues.Where(x => x.Id == deliveryNote.Car_Id.Value).FirstOrDefault();
              if (reportValue == null)
              {
                reportValue = new ReportValue();
                reportValue.Id = deliveryNote.Car_Id.Value;
                reportValue.Amount = deliveryNote.Amount;
                reportValue.NoOfTransports = 1; 
                row.ReportValues.Add(reportValue);
              }
              else
              {
                reportValue.Amount += deliveryNote.Amount;
                reportValue.NoOfTransports += 1;
              }
            }
            
          }
          return result;
        }
      }
      catch(Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }


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