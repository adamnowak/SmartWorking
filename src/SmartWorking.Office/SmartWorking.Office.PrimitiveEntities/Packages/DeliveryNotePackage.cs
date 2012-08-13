namespace SmartWorking.Office.PrimitiveEntities.Packages
{
  public class DeliveryNotePackage
  {
    public OrderPrimitive Order { get; set; }
    public DeliveryNotePrimitive DeliveryNote { get; set; }
    public CarAndDriverPackage CarAndDriver { get; set; }
    public DriverPrimitive Driver { get; set; }
  }
}
