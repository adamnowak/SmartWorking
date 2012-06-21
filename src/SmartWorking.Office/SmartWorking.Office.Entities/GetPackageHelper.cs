using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Entities
{
  public static class GetPackageHelper
  {
    public static ContractorAndBuildingsPackage GetContractorAndBuildingsPackage(this Contractor contractor)
    {
      ContractorAndBuildingsPackage result = new ContractorAndBuildingsPackage();
      result.Contractor = contractor.GetPrimitive();
      foreach (Building building in contractor.Buildings)
      {
        result.Buildings.Add(building.GetPrimitive());
      }
      return result;
    }
  }
}
