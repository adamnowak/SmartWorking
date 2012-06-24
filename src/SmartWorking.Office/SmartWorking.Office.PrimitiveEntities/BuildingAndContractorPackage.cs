using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class BuildingAndContractorPackage
  {
    public BuildingPrimitive Building { get; set; }

    public ContractorPrimitive Contractor { get; set; }
  }
}
