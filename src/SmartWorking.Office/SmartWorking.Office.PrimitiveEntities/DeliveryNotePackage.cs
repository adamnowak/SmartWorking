using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class DeliveryNotePackage
  {
    public OrderPrimitive Order { get; set; }
    public DeliveryNotePrimitive DeliveryNote { get; set; }
    public CarAndDriverPackage CarAndDriver { get; set; }
    public DriverPrimitive Driver { get; set; }
  }
}
