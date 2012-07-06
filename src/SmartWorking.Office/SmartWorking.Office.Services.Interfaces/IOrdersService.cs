﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on <see cref="Order"/>.
  /// </summary>
  [ServiceContract]
  public interface IOrdersService : IDisposable
  {
    /// <summary>
    /// Gets the <see cref="Order"/> filtered be <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </summary>
    /// <param name="filter">Used to filtering result. Loaded <see cref="Order"/> object will contain this string.</param>
    /// <param name="showCanceled">if set to <c>true</c> then loaded <see cref="Order"/> object  will contain <see cref="Order"/> which are deactivated; otherwise not.</param>        
    /// <returns>
    /// List of <see cref="Order"/> filtered by <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetOrders/?filter={filter}&getCanceled={getCanceled}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<OrderPrimitive> GetOrders(string filter, bool getCanceled);

    /// <summary>
    /// Gets the <see cref="Order"/> filtered be <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </summary>
    /// <param name="filter">Used to filtering result. Loaded <see cref="Order"/> object will contain this string.</param>
    /// <param name="getCanceled">if set to <c>true</c> [get canceled].</param>
    /// <returns>
    /// List of <see cref="Order"/> filtered by <paramref name="filter"/> and <paramref name="showCanceled"/>.
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetOrderPackageList/?filter={filter}&getCanceled={getCanceled}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<OrderPackage> GetOrderPackageList(string filter, bool getCanceled);

    /// <summary>
    /// Updates the <see cref="Order"/>.
    /// </summary>
    /// <param name="order">The delivery note which will be updated.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateOrder",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    int UpdateOrder(OrderPrimitive order);

    /// <summary>
    /// Deletes the <see cref="Order"/>.
    /// </summary>
    /// <param name="order">The delivery note which will be canceled.</param>
    /// <remarks>
    /// <see cref="Order"/> cannot be deleted.
    /// </remarks>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CanceledOrder",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CanceledOrder(OrderPrimitive order);
  }
}