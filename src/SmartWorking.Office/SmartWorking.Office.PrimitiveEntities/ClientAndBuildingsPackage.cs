using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class ClientAndBuildingsPackage
  {
    

    public ClientPrimitive Client { get; set; }

    private ICollection<ClientBuildingPackage> _clientBuildings;
    public ICollection<ClientBuildingPackage> ClientBuildings
    {
      get
      {
        if (_clientBuildings == null)
        {
          _clientBuildings = new ObservableCollection<ClientBuildingPackage>();
        }
        return _clientBuildings;        
      }
      set
      {
        _clientBuildings = value;
      }
    }
  }
}
