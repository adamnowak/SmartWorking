using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class DriverAndCarsPackage
  {
    public DriverPrimitive Driver { get; set; }

    private ICollection<CarPrimitive> _cars;
    public ICollection<CarPrimitive> Cars
    {
      get
      {
        if (_cars == null)
        {
          _cars = new ObservableCollection<CarPrimitive>();
        }
        return _cars;
      }
      set
      {
        _cars = value;
      }
    }
  }
}
