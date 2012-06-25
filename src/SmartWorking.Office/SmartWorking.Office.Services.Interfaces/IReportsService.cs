using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Reports;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to create reports.
  /// </summary>
  [ServiceContract]
  public interface IReportsService : IDisposable
  {
    /// <summary>
    /// Gets the recipes filtered be <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The recipes filter.</param>
    /// <returns>List of Recipe filtered by <paramref name="filter"/>. Recipe contains list of Material contains to this Recipe.</returns>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/GetDriversCarsDataReport/?startTime={startTime}#endTime={endTime}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped)]
    DriversCarsReportPackage GetDriversCarsDataReport(DateTime startTime, DateTime endTime); 
  }
}