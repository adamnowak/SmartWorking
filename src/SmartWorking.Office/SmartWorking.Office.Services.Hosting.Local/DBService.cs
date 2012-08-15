using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.Entities;

using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IOrdersService"/>.
  /// </summary>
  public class DBService : IDBService
  {
    
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {

    }

    public DBBackUpPackage GetBackUpData()
    {
      try
      {
        
        DBBackUpPackage result = new DBBackUpPackage();
        using (var ctx = new SmartWorkingEntities())
        {
          foreach (var entity in ctx.Buildings.AsEnumerable())
          {
            result.BuildingList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.Cars.AsEnumerable())
          {
            result.CarList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.ClientBuildings.AsEnumerable())
          {
            result.ClientBuildingList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.Clients.AsEnumerable())
          {
            result.ClientList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.Contractors.AsEnumerable())
          {
            result.ContractorList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.DeliveryNotes.AsEnumerable())
          {
            result.DeliveryNoteList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.Drivers.AsEnumerable())
          {
            result.DriverList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.Materials.AsEnumerable())
          {
            result.MaterialList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.MaterialStocks.AsEnumerable())
          {
            result.MaterialStockList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.Orders.AsEnumerable())
          {
            result.OrderList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.RecipeComponents.AsEnumerable())
          {
            result.RecipeComponentList.Add(entity.GetPrimitive());
          }

          foreach (var entity in ctx.Recipes.AsEnumerable())
          {
            result.RecipeList.Add(entity.GetPrimitive());
          }
        }
        return result;
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }
  }
}