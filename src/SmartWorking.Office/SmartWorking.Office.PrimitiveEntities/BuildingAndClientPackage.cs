using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class BuildingAndClientPackage
  {
    public BuildingPrimitive Building { get; set; }

    public ClientPrimitive Client { get; set; }
  }
}
