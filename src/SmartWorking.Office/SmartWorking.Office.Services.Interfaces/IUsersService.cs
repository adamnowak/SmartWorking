using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Car.
  /// </summary>
  [ServiceContract]
  public interface IUsersService : IDisposable
  {
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetUsers",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    List<UserAndRolesPackage> GetUserAndRolesPackageList(string filter, ListItemsFilterValues listItemsFilterValue);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateUser",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateUserAndRolesPackage(UserAndRolesPackage userPackage);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/ValidateUser",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    UserAndRolesPackage ValidateUser(string userName, string password);
    
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteUser",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteUser(UserPrimitive userPackage);

    

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CreateRole",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateRole(RolePrimitive rolePrimitive); 

    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteRole",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteRole(RolePrimitive rolePrimitive);
   
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRoles",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    List<RolePrimitive> GetRoles(string filter, ListItemsFilterValues listItemsFilterValue);
  }
}