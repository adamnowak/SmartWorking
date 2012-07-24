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
    public ClientBuildingPackage ClientBuildingPackage { get; set; }
    public RecipePrimitive Recipe { get; set; }
  }
}
