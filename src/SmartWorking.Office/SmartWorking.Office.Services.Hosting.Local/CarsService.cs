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
  /// Implementation of <see cref="ICarsService"/>.
  /// </summary>
  public class CarsService : ICarsService
  {
    /// <summary>
    /// Gets the cars filtered be <paramref name="carsFilter"/>.
    /// </summary>
    /// <param name="carsFilter">The cars filter used to result filtering.</param>
    /// <returns>
    /// List of Car filtered by <paramref name="carsFilter"/>.
    /// </returns>
    public List<CarPrimitive> GetCars(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Car> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Cars.ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Cars.Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Cars.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Cars.Where(x => (x.InternalName.Contains(filter) || x.RegistrationNumber.Contains(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Cars.Where(x => !x.Deleted.HasValue && (x.InternalName.Contains(filter) || x.RegistrationNumber.Contains(filter))).ToList()
                      : ctx.Cars.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.InternalName.Contains(filter) || x.RegistrationNumber.Contains(filter))).ToList();
          return result.Select(x => x.GetPrimitive()).ToList(); ;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }

    }

    public List<CarAndDriverPackage> GetCarAndDriverPackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Car> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Cars.Include("Driver").ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Cars.Include("Driver").Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Cars.Include("Driver").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Cars.Include("Driver").Where(x => (x.InternalName.Contains(filter) || x.RegistrationNumber.Contains(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Cars.Include("Driver").Where(x => !x.Deleted.HasValue && (x.InternalName.Contains(filter) || x.RegistrationNumber.Contains(filter))).ToList()
                      : ctx.Cars.Include("Driver").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.InternalName.Contains(filter) || x.RegistrationNumber.Contains(filter))).ToList();
          return result.Select(x => x.GetCarAndDriverPackage()).ToList(); 
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the car.oo
    /// </summary>
    /// <param name="carPrimitive">The car primitive.</param>
    public void CreateOrUpdateCar(CarPrimitive carPrimitive)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Car car = carPrimitive.GetEntity();
          Car existingObject = context.Cars.Where(x => x.Id == car.Id).FirstOrDefault();

          //no record of this item in the DB, item being passed in has a PK
          if (existingObject == null && car.Id > 0)
          {
            throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
          }
          //Item has no PK value, must be new
          else if (car.Id <= 0)
          {
            context.Cars.AddObject(car);
          }
          //Item was retrieved, and the item passed has a valid ID, do an update
          else
          {
            context.Cars.ApplyCurrentValues(car);
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
    /// Deletes the car.
    /// </summary>
    /// <param name="carPrimitive">The car primitive.</param>
    public void DeleteCar(CarPrimitive carPrimitive)
    {
      try
      {
        //TODO: if is not used in any DeliveryNotes than delete.
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Car car = context.Cars.Where(x => x.Id == carPrimitive.Id).FirstOrDefault();
          if (car != null)
          {
            car.Deleted = DateTime.Now;
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

    public void UndeleteCar(CarPrimitive carPrimitive)
    {
      try
      {
        //TODO: if is not used in any DeliveryNotes than delete.
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Car car = context.Cars.Where(x => x.Id == carPrimitive.Id).FirstOrDefault();
          if (car != null)
          {
            car.Deleted = null;
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
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {

    }
  }
}