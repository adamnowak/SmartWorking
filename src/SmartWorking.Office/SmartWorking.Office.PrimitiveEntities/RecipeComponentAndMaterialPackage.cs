using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace SmartWorking.Office.PrimitiveEntities
{
  public class RecipeComponentAndMaterialPackage
  {
    public MaterialAndContractorsPackage MaterialAndContractors { get; set; }

    public RecipeComponentPrimitive RecipeComponent { get; set; }    
  }
}
