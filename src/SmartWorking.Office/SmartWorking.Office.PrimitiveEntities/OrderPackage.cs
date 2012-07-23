using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class OrderPackage
  {
    public OrderPrimitive Order { get; set; }    
    public ClientBuildingPackage BuildingAndContractor { get; set; }
    public RecipePrimitive Recipe { get; set; }
  }
}
