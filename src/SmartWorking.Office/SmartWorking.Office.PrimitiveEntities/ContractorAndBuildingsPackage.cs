using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.PrimitiveEntities
{
  public class ContractorAndBuildingsPackage
  {
    private ICollection<BuildingPrimitive> _buildings;

    public ContractorPrimitive Contractor { get; set; }
    
    public ICollection<BuildingPrimitive> Buildings
    {
      get
      {
        if (_buildings == null)
        {
          _buildings = new ObservableCollection<BuildingPrimitive>();
        }
        return _buildings;        
      }
      set
      {
        _buildings = value;
      }
    }
  }
}
