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
  }
}
