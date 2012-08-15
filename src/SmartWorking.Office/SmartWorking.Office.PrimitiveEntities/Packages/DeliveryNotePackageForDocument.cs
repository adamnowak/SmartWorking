using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartWorking.Office.PrimitiveEntities.Packages
{
  public class DeliveryNotePackageForDocument
  {
    public ClientPrimitive Client { get; set; }
    public BuildingPrimitive Building { get; set; }
    public DeliveryNotePrimitive DeliveryNote { get; set; }
    public OrderPrimitive Order { get; set; }    
    public RecipePackage RecipePackage { get; set; }
    public CarPrimitive Car { get; set; }
    public DriverPrimitive Driver { get; set; }
    private ICollection<DeliveryNotePackage> _deliveryNotePackageList;
    public ICollection<DeliveryNotePackage> DeliveryNotePackageList
    {
      get
      {
        if (_deliveryNotePackageList == null)
        {
          _deliveryNotePackageList = new ObservableCollection<DeliveryNotePackage>();
        }
        return _deliveryNotePackageList;
      }
      set
      {
        _deliveryNotePackageList = value;
      }
    }

  }
}
