using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.PrimitiveEntities
{
  public class RecipeComponentAndMaterialPackage
  {
    public MaterialPrimitive Material { get; set; }

    public RecipeComponentPrimitive RecipeComponent { get; set; }    
  }
}
