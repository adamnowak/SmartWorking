using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public static class GetPackageCopierHelper
  {
    public static CarAndDriverPackage GetPackageCopy(this CarAndDriverPackage packageToCopy)
    {
      CarAndDriverPackage package = new CarAndDriverPackage();
      package.Driver = packageToCopy.Driver.GetPrimitiveCopy();
      package.Car = packageToCopy.Car.GetPrimitiveCopy();
      return package;
    }

    public static DriverAndCarsPackage GetPackageCopy(this DriverAndCarsPackage packageToCopy)
    {
      DriverAndCarsPackage package = new DriverAndCarsPackage();
      package.Driver = packageToCopy.Driver;

      foreach (CarPrimitive carPrimitive in packageToCopy.Cars)
      {
        package.Cars.Add(carPrimitive.GetPrimitiveCopy());  
      }
      return package;
    }
    public static MaterialAndContractorsPackage GetPackageCopy(this MaterialAndContractorsPackage packageToCopy)
    {
      MaterialAndContractorsPackage package = new MaterialAndContractorsPackage();
      package.Material = packageToCopy.Material.GetPrimitiveCopy();
      package.Deliverer = packageToCopy.Deliverer.GetPrimitiveCopy();
      package.Producer = packageToCopy.Producer.GetPrimitiveCopy();
      return package;
    }
  }
}
