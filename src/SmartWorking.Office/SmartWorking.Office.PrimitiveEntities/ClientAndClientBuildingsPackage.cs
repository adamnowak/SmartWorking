using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class ClientAndClientBuildingsPackage
  {
    

    public ClientPrimitive Client { get; set; }

    private ICollection<ClientBuildingAndBuildingPackage> _clientBuildings;
    public ICollection<ClientBuildingAndBuildingPackage> ClientBuildings
    {
      get
      {
        if (_clientBuildings == null)
        {
          _clientBuildings = new ObservableCollection<ClientBuildingAndBuildingPackage>();
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
