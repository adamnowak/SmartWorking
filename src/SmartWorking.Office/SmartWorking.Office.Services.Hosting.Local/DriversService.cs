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
  /// Implementation of <see cref="IRecipesService"/>.
  /// </summary>
  public class DriversService : IDriversService
  {
    
    /// <summary>
    /// Gets the drivers filtered be <paramref name="driversFilter"/>.
    /// </summary>
    /// <param name="driversFilter">The drivers filter used to result filtering.</param>
    /// <returns>
    /// List of Drivers filtered by <paramref name="driversFilter"/>.
    /// </returns>
    public List<DriverPrimitive> GetDrivers(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Driver> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Drivers.ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Drivers.Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Drivers.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Drivers.Where(x => (x.InternalName.Contains(filter) || x.Name.Contains(filter) || x.Surname.Contains(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Drivers.Where(x => !x.Deleted.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter) || x.Surname.Contains(filter))).ToList()
                      : ctx.Drivers.Where(
                        x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter) || x.Surname.Contains(filter))).ToList();        
          return result.Select(x => x.GetPrimitive()).ToList(); 
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public List<DriverAndCarsPackage> GetDriverAndCarsPackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Driver> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Drivers.Include("Cars").ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Drivers.Include("Cars").Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Drivers.Include("Cars").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Drivers.Include("Cars").Where(x => (x.InternalName.Contains(filter) || x.Name.Contains(filter) || x.Surname.Contains(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Drivers.Include("Cars").Where(x => !x.Deleted.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter) || x.Surname.Contains(filter))).ToList()
                      : ctx.Drivers.Include("Cars").Where(
                        x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.InternalName.Contains(filter) || x.Name.Contains(filter) || x.Surname.Contains(filter))).ToList();
          return result.Select(x => x.GetDriverAndCarsPackage()).ToList();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the driver.
    /// </summary>
    /// <param name="driver">The driver which will be updated.</param>
    public void CreateOrUpdateDriver(DriverPrimitive driverPrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Driver driver = driverPrimitive.GetEntity();

          Driver existingObject = context.Drivers.Where(x => x.Id == driver.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && driver.Id > 0)
          {
            throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
          }
          //Item has no PK value, must be new
          else if (driver.Id <= 0)
          {
            context.Drivers.AddObject(driver);
          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
            context.Drivers.ApplyCurrentValues(driver);
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
    /// Deletes the recipe.
    /// </summary>
    /// <param name="driver">The driver which will be deleted.</param>
    public void DeleteDriver(DriverPrimitive driverPrimitive)
    {
      try
      {
        //TODO: if is not used in any DeliveryNotes than delete.
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Driver driver = context.Drivers.Where(x => x.Id == driverPrimitive.Id).FirstOrDefault();
          if (driver != null)
          {
            driver.Deleted = DateTime.Now;
            
            //'disconnect' driver from car
            foreach (Car car in context.Cars.Where(x => x.Driver_Id == driverPrimitive.Id))
            {
              car.Driver = null;
            }

            context.SaveChanges();
          }
          else
          {
            throw new Exception("This driver does not exist in db.");
          }
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public void UndeleteDriver(DriverPrimitive driverPrimitive)
    {
      try
      {
        //TODO: if is not used in any DeliveryNotes than delete.
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Driver driver = context.Drivers.Where(x => x.Id == driverPrimitive.Id).FirstOrDefault();
          if (driver != null)
          {
            driver.Deleted = null;
            context.SaveChanges();
          }
          else
          {
            throw new Exception("This driver does not exist in db.");
          }
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