using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IMaterialsService"/>.
  /// </summary>
  public class MaterialsService : IMaterialsService
  {
    #region IMaterialsService Members

    /// <summary>
    /// Gets the materials filtered by <paramref name="materialNameFilter"/>.
    /// </summary>
    /// <param name="materialNameFilter">The material name filter.</param>
    /// <returns>
    /// List of material filtered by <paramref name="materialNameFilter"/>. The result has the information about material in stock.
    /// </returns>
    public List<MaterialPrimitive> GetMaterials(string materialNameFilter)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Material> result =
            (string.IsNullOrWhiteSpace(materialNameFilter))
              ? ctx.Materials.Include("MaterialStocks").ToList()
              : ctx.Materials.Include("MaterialStocks").Where(x => x.Name.StartsWith(materialNameFilter)).ToList();
          return result.Select(x => x.GetPrimitive()).ToList(); ;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the material.
    /// </summary>
    /// <param name="material">The material which will be updated.</param>
    public void UpdateMaterial(MaterialPrimitive materialPrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Material material = materialPrimitive.GetEntity();

          Material existingObject = context.Materials.Where(x => x.Id == material.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && material.Id > 0)
          {
            //log
            return;
          }
          //Item has no PK value, must be new
          else if (material.Id <= 0)
          {
            context.Materials.AddObject(material);
          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
            context.Materials.ApplyCurrentValues(material);
          }

          context.SaveChanges();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Deletes the material.
    /// </summary>
    /// <param name="material">The material which will be deleted.</param>
    public void DeleteMaterial(MaterialPrimitive materialPrimitive)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the information about material in stock.
    /// </summary>
    /// <param name="materialStockPrimitive">The material stock primitive.</param>
    public void UpdateMaterialStock(MaterialStockPrimitive materialStockPrimitive)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
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