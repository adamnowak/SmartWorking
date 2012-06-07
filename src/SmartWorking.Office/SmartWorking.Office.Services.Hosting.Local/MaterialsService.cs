using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
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
    public List<Material> GetMaterials(string materialNameFilter)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Material> result =
          (string.IsNullOrWhiteSpace(materialNameFilter))
            ? ctx.Materials.Include("MaterialStocks").ToList()
            : ctx.Materials.Include("MaterialStocks").Where(x => x.Name.StartsWith(materialNameFilter)).ToList();
        return result;
      }
    }

    /// <summary>
    /// Updates the material.
    /// </summary>
    /// <param name="material">The material which will be updated.</param>
    public void UpdateMaterial(Material material)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        ctx.Materials.ApplyCurrentValues(material);
        ctx.SaveChanges();
      }
    }

    /// <summary>
    /// Deletes the material.
    /// </summary>
    /// <param name="material">The material which will be deleted.</param>
    public void DeleteMaterial(Material material)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the information about material in stock.
    /// </summary>
    /// <param name="material">The material for which the information about stock will be updated.</param>
    /// <param name="amountMaterialInStock">The new material in stock.</param>
    public void UpdateMaterialInStock(Material material, float amountMaterialInStock)
    {
      throw new NotImplementedException();
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