using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class DeliveryNoteReportPackage
  {
    public OrderPrimitive Order { get; set; }
    public DeliveryNotePrimitive DeliveryNote { get; set; }
    public CarPrimitive Car { get; set; }
    public DriverPrimitive Driver { get; set; }
    public BuildingPrimitive Building { get; set; }
    public RecipePrimitive Recipe { get; set; }
    public ClientPrimitive Client { get; set; }
  }
}
