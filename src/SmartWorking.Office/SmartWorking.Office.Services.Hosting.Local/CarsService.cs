using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  
  /// <summary>
  /// Implementation of <see cref="ICarsService"/>.
  /// </summary>
  public class CarsService : ICarsService
  {
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {

    }

    /// <summary>
    /// Gets the cars filtered be <paramref name="carsFilter"/>.
    /// </summary>
    /// <param name="carsFilter">The cars filter used to result filtering.</param>
    /// <returns>
    /// List of Car filtered by <paramref name="carsFilter"/>.
    /// </returns>
    public List<Car> GetCars(string carsFilter)
    {
      try
      {
        throw new Exception("test", new Exception("innerTest"));
        //return new List<Car>() { new Car() };
        using (var ctx = new SmartWorkingEntities())
        {
          List<Car> result =
            (string.IsNullOrWhiteSpace(carsFilter))
              ? ctx.Cars.ToList()
              : ctx.Cars.Where(x => x.RegistrationNumber.StartsWith(carsFilter)).ToList();
          return result;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
      
    }

    /// <summary>
    /// Updates the car.
    /// </summary>
    /// <param name="car">The car which will be updated.</param>
    public void UpdateCar(Car car)
    {
      using (SmartWorkingEntities context = new SmartWorkingEntities())
      {
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

    /// <summary>
    /// Deletes the car.
    /// </summary>
    /// <param name="car">The car which will be deleted.</param>
    public void DeleteCar(Car car)
    {
      throw new NotImplementedException();
    }
  }
}