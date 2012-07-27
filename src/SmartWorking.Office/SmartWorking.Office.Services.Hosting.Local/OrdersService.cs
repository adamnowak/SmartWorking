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
  /// Implementation of <see cref="IOrdersService"/>.
  /// </summary>
  public class OrdersService : IOrdersService
  {
    /// <summary>
    /// Gets the <see cref="Order"/> filtered be <paramref name="filter"/> and <paramref name="showCanceledOrders"/>.
    /// </summary>
    /// <param name="filter">Used to filtering result. Loaded <see cref="Order"/> object will contain this string.</param>
    /// <param name="showCanceledOrders">if set to <c>true</c> then loaded <see cref="Order"/> object  will contain <see cref="Order"/> which are deactivated; otherwise not.</param>
    /// <returns>
    /// List of <see cref="Order"/> filtered by <paramref name="filter"/> and <paramref name="showCanceledOrders"/>.
    /// </returns>
    public List<OrderPrimitive> GetOrders(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Order> result;
          //if (string.IsNullOrWhiteSpace(filter))
          //{
          //  if (showCanceledOrders)
          //  {
          //    result = ctx.Orders.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").ToList();
          //  }
          //  else
          //  {
          //    result = ctx.Orders.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => x.Canceled != DateTime.MinValue).ToList();
          //  }
          //}
          //else
          //{
          //  if (showCanceledOrders)
          //  {
          //    result = ctx.Orders.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => (x.Building.City + " " + x.Building.Street).Contains(filter)).ToList();
          //  }
          //  else
          //  {
          //    result = ctx.Orders.Include("Building.Contractor").Include("Recipe").Include("Driver").Include("Car").Where(x => x.Canceled != DateTime.MinValue && (x.Building.City + " " + x.Building.Street).Contains(filter)).ToList();
          //  }

          //}
          //return result.Select(x => x.GetPrimitive()).ToList();
          return null;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public List<OrderPackage> GetOrderPackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Order> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Orders.Include("Recipe").Include("ClientBuilding.Client").Include("ClientBuilding.Building").ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Orders.Include("Recipe").Include("ClientBuilding.Client").Include("ClientBuilding.Building").Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Orders.Include("Recipe").Include("ClientBuilding.Client").Include("ClientBuilding.Building").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Orders.Include("Recipe").Include("ClientBuilding.Client").Include("ClientBuilding.Building").Where(x => x.ClientBuilding != null && x.ClientBuilding.Client != null && x.ClientBuilding.Client.Name.StartsWith(filter)).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Orders.Include("Recipe").Include("ClientBuilding.Client").Include("ClientBuilding.Building").Where(x => !x.Deleted.HasValue && x.ClientBuilding != null && x.ClientBuilding.Client != null && x.ClientBuilding.Client.Name.StartsWith(filter)).ToList()
                      : ctx.Orders.Include("Recipe").Include("ClientBuilding.Client").Include("ClientBuilding.Building").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && x.ClientBuilding != null && x.ClientBuilding.Client != null && x.ClientBuilding.Client.Name.StartsWith(filter)).ToList();
          return result.Select(x => x.GetOrderPackage()).ToList(); ;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }    
    }

   

    public void CreateOrUpdateOrderPackage(OrderPackage item)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Order order = item.Order.GetEntity();// orderPrimitive.GetEntity();

          Order existingObject = context.Orders.Where(x => x.Id == order.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && order.Id > 0)
          {
            throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
          }

          //Item has no PK value, must be new);
          if (order.Id <= 0)
          {
            context.Orders.AddObject(order);
          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
            context.Orders.ApplyCurrentValues(order);
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
    /// Deletes the <see cref="Order"/>.
    /// </summary>
    /// <param name="order">The delivery note which will be canceled.</param>
    public void CanceledOrder(OrderPrimitive orderPrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Order order = orderPrimitive.GetEntity();

          Order existingObject = context.Orders.Where(x => x.Id == order.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null)
          {
            throw new Exception("Only exists delivery note can be canceled.");
          }

          order.Canceled = DateTime.Now;
          context.Orders.ApplyCurrentValues(order);          

          context.SaveChanges();          
        }
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
  }
}