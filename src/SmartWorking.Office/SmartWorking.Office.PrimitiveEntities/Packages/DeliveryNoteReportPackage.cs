namespace SmartWorking.Office.PrimitiveEntities.Packages
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
