using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartWorking.Office.PrimitiveEntities.Packages
{
  public class RecipePackage
  {
    public RecipePrimitive Recipe { get; set; }

    private ICollection<RecipeComponentAndMaterialPackage> _recipeComponentAndMaterialList;
    public ICollection<RecipeComponentAndMaterialPackage> RecipeComponentAndMaterialList
    {
      get
      {
        if (_recipeComponentAndMaterialList == null)
        {
          _recipeComponentAndMaterialList = new ObservableCollection<RecipeComponentAndMaterialPackage>();
        }
        return _recipeComponentAndMaterialList;
      }
      set { _recipeComponentAndMaterialList = value; }
    }
  }
}
