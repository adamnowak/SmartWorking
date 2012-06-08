using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Material.
  /// </summary>
  [ServiceContract]
  public interface IMaterialsService : IDisposable
  {
    /// <summary>
    /// Gets the materials filtered by <paramref name="materialNameFilter"/>.
    /// </summary>
    /// <param name="materialNameFilter">The material name filter.</param>
    /// <returns>List of material filtered by <paramref name="materialNameFilter"/>. The result has the information about material in stock.</returns>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    List<Material> GetMaterials(string materialNameFilter);

    /// <summary>
    /// Updates the material.
    /// </summary>
    /// <param name="material">The material which will be updated.</param>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void UpdateMaterial(Material material);

    /// <summary>
    /// Deletes the material.
    /// </summary>
    /// <param name="material">The material which will be deleted.</param>
    /// <remarks>Information about material in stock will be also deleted.</remarks>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void DeleteMaterial(Material material);

    /// <summary>
    /// Updates the information about material in stock.
    /// </summary>
    /// <param name="material">The material for which the information about stock will be updated.</param>
    /// <param name="amountMaterialInStock">The new material in stock.</param>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void UpdateMaterialInStock(Material material, float amountMaterialInStock);
  }
}