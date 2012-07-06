using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class MaterialAndContractorsPackage
  {
    public MaterialPrimitive Material { get; set; }

    public ContractorPrimitive Producer { get; set; }

    public ContractorPrimitive Deliverer { get; set; }       
  }
}
