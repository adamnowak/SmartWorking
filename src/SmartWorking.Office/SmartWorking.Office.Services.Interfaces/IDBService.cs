using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.PrimitiveEntities.Reports;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to create reports.
  /// </summary>
  [ServiceContract]
  public interface IDBService : IDisposable
  {
    DBBackUpPackage GetBackUpData();
  }
}