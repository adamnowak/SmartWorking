using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartWorking.Office.PrimitiveEntities.Packages
{
  public class OrderPackage
  {    
    public OrderPrimitive Order { get; set; }
    public ClientPrimitive Client { get; set; }
    public ClientBuildingAndBuildingPackage ClientBuildingPackage { get; set; }
    public RecipePrimitive Recipe { get; set; }
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
