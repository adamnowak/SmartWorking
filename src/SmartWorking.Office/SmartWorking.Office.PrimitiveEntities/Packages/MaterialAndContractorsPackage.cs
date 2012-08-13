namespace SmartWorking.Office.PrimitiveEntities.Packages
{
  public class MaterialAndContractorsPackage
  {
    public MaterialPrimitive Material { get; set; }

    public ContractorPrimitive Producer { get; set; }

    public ContractorPrimitive Deliverer { get; set; }       
  }
}
