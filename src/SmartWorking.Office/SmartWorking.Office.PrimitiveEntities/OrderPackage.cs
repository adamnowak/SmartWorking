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
    public ClientBuildingAndBuildingPackage ClientBuildingPackage { get; set; }
    public RecipePrimitive Recipe { get; set; }
    private ICollection<DeliveryNotePrimitive> _deliveryNotes;
    public ICollection<DeliveryNotePrimitive> DeliveryNotes
    {
      get
      {
        if (_deliveryNotes == null)
        {
          _deliveryNotes = new ObservableCollection<DeliveryNotePrimitive>();
        }
        return _deliveryNotes;
      }
      set
      {
        _deliveryNotes = value;
      }
    }
  }
}
