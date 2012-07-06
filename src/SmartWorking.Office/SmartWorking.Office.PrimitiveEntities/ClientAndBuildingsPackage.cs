﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class ClientAndBuildingsPackage
  {
    private ICollection<BuildingPrimitive> _buildings;

    public ClientPrimitive Client { get; set; }
    
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