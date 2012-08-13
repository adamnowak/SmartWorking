using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.Entities;

using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
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
    public List<MaterialPrimitive> GetMaterialList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Material> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Materials.ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Materials.Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Materials.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Materials.Where(x => (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Materials.Where(x => !x.Deleted.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList()
                      : ctx.Materials.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList();  
          return result.Select(x => x.GetPrimitive()).ToList(); 
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public List<MaterialAndContractorsPackage> GetMaterialAndContractorsPackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Material> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Materials.Include("Producer").Include("Deliverer").ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Materials.Include("Producer").Include("Deliverer").Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Materials.Include("Producer").Include("Deliverer").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Materials.Include("Producer").Include("Deliverer").Where(x => (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Materials.Include("Producer").Include("Deliverer").Where(x => !x.Deleted.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList()
                      : ctx.Materials.Include("Producer").Include("Deliverer").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter))).ToList();          
          return result.Select(x => x.GetMaterialAndContractorsPackage()).ToList(); 

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
    public void CreateOrUpdateMaterial(MaterialPrimitive materialPrimitive)
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
            throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
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
        using (var context = new SmartWorkingEntities())
        {
          Material material = context.Materials.Where(x => x.Id == materialPrimitive.Id).FirstOrDefault();
          if (material != null)
          {
            material.Deleted = DateTime.Now;
            context.SaveChanges();
          }
          else
          {
            throw new Exception("This car does not exist in db.");
          }
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public void UndeleteMaterial(MaterialPrimitive materialPrimitive)
    {
      try
      {
        using (var context = new SmartWorkingEntities())
        {
          Material material = context.Materials.Where(x => x.Id == materialPrimitive.Id).FirstOrDefault();
          if (material != null)
          {
            material.Deleted = null;
            context.SaveChanges();
          }
          else
          {
            throw new Exception("This car does not exist in db.");
          }
        }
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