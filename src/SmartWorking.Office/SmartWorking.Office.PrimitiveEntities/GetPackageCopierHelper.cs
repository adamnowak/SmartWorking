using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public static class GetPackageCopierHelper
  {
    public static DriverAndCarPackage GetPackageCopy(this DriverAndCarPackage packageToCopy)
    {
      DriverAndCarPackage package = new DriverAndCarPackage();
      package.Driver = packageToCopy.Driver.GetPrimitiveCopy();
      package.Car = packageToCopy.Car.GetPrimitiveCopy();
      return package;
    }
  }
}
