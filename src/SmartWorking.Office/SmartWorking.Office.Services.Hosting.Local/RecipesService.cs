using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  public class RecipesService : IRecipesService
  {
    #region IRecipesService Members

    public List<Recipe> GetRecipes()
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Recipe> result = ctx.Recipes.ToList();

        //only in local (when WCF is used then Deserialization set ChangeTracker.ChangeTrackingEnabled on true)
        foreach (Recipe r in result)
        {
          r.StartTracking();
        }
        //end only in local 

        return result;
      }
    }

    public void UpdateRecipe(Recipe recipeToUpdate)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        ctx.Recipes.ApplyChanges(recipeToUpdate);
        ctx.SaveChanges();
      }
    }

    public void Dispose()
    {
    }

    #endregion
  }
}