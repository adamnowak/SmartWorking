using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using SmartWorking.Office.Entities;

using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.MetaDates;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{

  /// <summary>
  /// Implementation of <see cref="ICarsService"/>.
  /// </summary>
  public class UsersService : IUsersService
  {
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {

    }

    internal string GenerateSalt()
    {
      byte[] buf = new byte[16];
      (new RNGCryptoServiceProvider()).GetBytes(buf);
      return Convert.ToBase64String(buf);
    }

    internal string EncodePassword(string pass, string salt)
    {    
      byte[] bIn = Encoding.Unicode.GetBytes(pass);
      byte[] bSalt = Convert.FromBase64String(salt);
      byte[] bAll = new byte[bSalt.Length + bIn.Length];
      byte[] bRet = null;

      Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
      Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);
      
      HashAlgorithm s = HashAlgorithm.Create("SHA1");
      // Hardcoded "SHA1" instead of Membership.HashAlgorithmType
      bRet = s.ComputeHash(bAll);
      
      return Convert.ToBase64String(bRet);
    }

    public List<UserAndRolesPackage> GetUserAndRolesPackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<User> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Users.Include("Roles").ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Users.Include("Roles").Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Users.Include("Roles").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Users.Include("Roles").Where(x => (x.Name.StartsWith(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Users.Include("Roles").Where(x => !x.Deleted.HasValue && (x.Name.StartsWith(filter))).ToList()
                      : ctx.Users.Include("Roles").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.Name.StartsWith(filter))).ToList();
           List<UserAndRolesPackage> toReturn = result.Select(x => x.GetUserAndRolesPackage()).ToList();
           foreach(UserAndRolesPackage userAndRolesPackage in toReturn)
           {
             if (userAndRolesPackage != null)
             {
               userAndRolesPackage.PasswordConfirm = string.Empty;
               userAndRolesPackage.User.Password = string.Empty;
               userAndRolesPackage.User.PasswordSalz = string.Empty;
             }
           }
          return toReturn;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public void CreateOrUpdateUserAndRolesPackage(UserAndRolesPackage userPackage)
    {
      try
      {
        if (userPackage != null && userPackage.User != null)
        {
          using (SmartWorkingEntities context = new SmartWorkingEntities())
          {
            User existingObject = context.Users.Include("Roles").Where(x => x.Id == userPackage.User.Id).FirstOrDefault();

            //no record of this item in the DB, item being passed in has a PK
            if (existingObject == null && userPackage.User.Id > 0)
            {
              throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
            }
            //Item has no PK value, must be new

            //Item has no PK value, must be new);
            if (userPackage.User.Id <= 0)
            {
              User user = userPackage.User.GetEntity();
              user.PasswordSalz = GenerateSalt();
              user.Password = EncodePassword(user.Password, user.PasswordSalz);
              context.Users.AddObject(user);
              foreach (RolePrimitive rolePrimitive in userPackage.Roles)
              {
                Role role = rolePrimitive.GetEntity();
                role.Users.Add(user);               
              }
            }
            //Item was retrieved, and the item passed has a valid ID, do an update
            else
            {
              List<RolePrimitive> existingElements = existingObject.Roles.Select(x => x.GetPrimitive()).ToList();
              List<RolePrimitive> newElements = userPackage.Roles.ToList();
              List<RolePrimitive> theSameElements = newElements.Where(x => existingElements.Select(y => y.Id).Contains(x.Id)).ToList();

              existingElements.RemoveAll(x => theSameElements.Select(y => y.Id).Contains(x.Id));
              newElements.RemoveAll(x => theSameElements.Select(y => y.Id).Contains(x.Id));

              //remove 
              if (existingElements.Count() > 0)
              {
                List<int> existingRecipeComponentIds = existingElements.Select(x => x.Id).ToList();
                List<RolePrimitive> recipeComponentListToDelete =
                  context.Roles.Where(x => existingRecipeComponentIds.Contains(x.Id)).Select(y => y.GetPrimitive()).ToList();

                foreach (RolePrimitive recipeComponent in recipeComponentListToDelete)
                {
                  context.Roles.DeleteObject(recipeComponent.GetEntity());
                }
              }

              //add
              foreach (RolePrimitive newRecipeComponent in newElements)
              {
                context.Roles.AddObject(newRecipeComponent.GetEntity());
              }

              //if is empty don't change password
              if (string.IsNullOrEmpty(userPackage.User.Password))
              {
                userPackage.User.Password = existingObject.Password;
              }
              else
              {
                userPackage.User.Password = EncodePassword(userPackage.User.Password, existingObject.PasswordSalz);  
              }
              
              context.Users.ApplyCurrentValues(userPackage.User.GetEntity());
            }

            context.SaveChanges();

            
          }
        }
        else
        {
          throw new Exception("str_Inpute parameter was wrong.");
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public UserAndRolesPackage ValidateUser(string userName, string password)
    {
      try
      {
        if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password)) 
        {
          using (SmartWorkingEntities context = new SmartWorkingEntities())
          {
            User existingObject =
              context.Users.Include("Roles").Where(x => x.Name == userName).FirstOrDefault();
            if (existingObject != null)
            {

              string passwordToCheck = EncodePassword(password, existingObject.PasswordSalz);
              string passwordInDb = existingObject.Password;
              if (passwordInDb == passwordToCheck)
              {
                return existingObject.GetUserAndRolesPackage();
              }
            }
          }
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
      return null;

    }

    public void DeleteUser(UserPrimitive userPackage)
    {
      throw new NotImplementedException();
    }

    public void CreateRole(RolePrimitive rolePrimitive)
    {
      throw new NotImplementedException();
    }

    public void DeleteRole(RolePrimitive rolePrimitive)
    {
      throw new NotImplementedException();
    }

    public List<RolePrimitive> GetRoles(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Role> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Roles.ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Roles.Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Roles.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Roles.Where(x => (x.Name.StartsWith(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Roles.Where(x => !x.Deleted.HasValue && (x.Name.StartsWith(filter))).ToList()
                      : ctx.Roles.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.Name.StartsWith(filter))).ToList();
          return result.Select(x => x.GetPrimitive()).ToList();         
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }
  }
}