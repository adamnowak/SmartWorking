using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class ClientBuildingPackage
  {
    public ClientBuildingPrimitive ClientBuilding { get; set; }

    public BuildingPrimitive Building { get; set; }

    public ClientPrimitive Client { get; set; }
  }
}
