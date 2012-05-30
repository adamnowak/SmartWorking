using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  public class RecipesService : IRecipesService
  {
    public List<Recipe> GetRecipes()
    {
      using (var ctx = new SmartWorkingEntities())
      {
        return ctx.Recipes.ToList();
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
  }
}
