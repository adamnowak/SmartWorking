using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
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
    /// Gets the materials filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>
    /// List of material filtered by <paramref name="filter"/>. The result has the information about material in stock.
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetMaterials?filter={filter}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<MaterialPrimitive> GetMaterials(string filter);

    /// <summary>
    /// Updates the material.
    /// </summary>
    /// <param name="material">The material which will be updated.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateMaterial",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UpdateMaterial(MaterialPrimitive material);

    /// <summary>
    /// Deletes the material.
    /// </summary>
    /// <param name="material">The material which will be deleted.</param>
    /// <remarks>Information about material in stock will be also deleted.</remarks>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteMaterial",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteMaterial(MaterialPrimitive material);

    /// <summary>
    /// Updates the information about material in stock.
    /// </summary>
    /// <param name="material">The material for which the information about stock will be updated.</param>
    /// <param name="amountMaterialInStock">The new material in stock.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateMaterialStock", 
      RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, 
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UpdateMaterialStock(MaterialStockPrimitive materialStockPrimitive);
  }
}