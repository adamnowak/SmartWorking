using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class DeliveryNotePackage
  {
    //public OrderPackage OrderPackage { get; set; }
    public DeliveryNotePrimitive DeliveryNote { get; set; }
    public CarPrimitive Car { get; set; }
    public DriverPrimitive Driver { get; set; }
  }
}
