using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartWorking.Office.PrimitiveEntities.Packages
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
