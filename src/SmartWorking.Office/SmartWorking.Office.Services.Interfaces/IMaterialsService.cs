using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;

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
    [WebInvoke(Method = "GET", UriTemplate = "/GetMaterialList?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<MaterialPrimitive> GetMaterialList(string filter, ListItemsFilterValues listItemsFilterValue);

    /// <summary>
    /// Gets the materials filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>
    /// List of material filtered by <paramref name="filter"/>. The result has the information about material in stock.
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetMaterialAndContractorsPackageList?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<MaterialAndContractorsPackage> GetMaterialAndContractorsPackageList(string filter, ListItemsFilterValues listItemsFilterValue);

    
    /// <summary>
    /// Updates the material.
    /// </summary>
    /// <param name="material">The material which will be updated.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CreateOrUpdateMaterial",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateMaterial(MaterialPrimitive material);

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

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UndeleteMaterial",
      RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UndeleteMaterial(MaterialPrimitive material);

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