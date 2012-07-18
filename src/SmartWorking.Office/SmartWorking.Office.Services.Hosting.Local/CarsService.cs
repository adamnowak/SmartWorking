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
    public List<CarPrimitive> GetCars(string carsFilter)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Car> result =
            (string.IsNullOrWhiteSpace(carsFilter))
              ? ctx.Cars.ToList()
              : ctx.Cars.Where(x => x.RegistrationNumber.StartsWith(carsFilter)).ToList();
          return result.Select(x => x.GetPrimitive()).ToList(); ;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }

    }

    public List<CarAndDriverPackage> GetCarAndDriverPackageList(string filter)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Car> result =
            (string.IsNullOrWhiteSpace(filter))
              ? ctx.Cars.Include("Driver").ToList()
              : ctx.Cars.Include("Driver").Where(x => x.Name.StartsWith(filter)).ToList();
          return result.Select(x => x.GetDriverAndCarPackage()).ToList(); ;
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
    public void UpdateCar(CarPrimitive carPrimitive)
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
            //TODO:
            return;
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
        throw new NotImplementedException();
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