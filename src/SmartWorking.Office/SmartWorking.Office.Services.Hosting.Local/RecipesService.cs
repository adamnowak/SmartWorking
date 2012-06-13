using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IRecipesService"/>.
  /// </summary>
  public class RecipesService : IRecipesService
  {
    #region IRecipesService Members

    /// <summary>
    /// Gets the recipes filtered be <paramref name="recipesFilter"/>.
    /// </summary>
    /// <param name="recipesFilter">The recipes filter.</param>
    /// <returns>
    /// List of Recipe filtered by <paramref name="recipesFilter"/>. Recipe contains list of Material contains to this Recipe.
    /// </returns>
    public List<Recipe> GetRecipes(string recipesFilter)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Recipe> result = (string.IsNullOrWhiteSpace(recipesFilter))
                                ? ctx.Recipes.Include("RecipeComponents.Material").ToList()
                                : ctx.Recipes.Include("RecipeComponents.Material").Where(
                                  x => x.Name.StartsWith(recipesFilter)).ToList();
        return result;
      }
    }

    /// <summary>
    /// Updates the recipe.
    /// </summary>
    /// <param name="recipe">The recipe to update.</param>
    public void UpdateRecipe(Recipe recipe)
    {
      using (SmartWorkingEntities context = new SmartWorkingEntities())
      {
        Recipe existingObject = context.Recipes.Where(x => x.Id == recipe.Id).FirstOrDefault();

        //no record of this item in the DB, item being passed in has a PK
        if (existingObject == null && recipe.Id > 0)
        {
          //TODO:
          return;
        }
        //Item has no PK value, must be new
        else if (recipe.Id <= 0)
        {
          context.Recipes.AddObject(recipe);
        }
        //Item was retrieved, and the item passed has a valid ID, do an update
        else
        {
          context.Recipes.ApplyCurrentValues(recipe);
        }

        context.SaveChanges();
      }
    }

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    /// <param name="recipe">The recipe which will be deleted.</param>
    public void DeleteRecipe(Recipe recipe)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the amount material in recipe.
    /// </summary>
    /// <param name="recipeComponent">The recipe component.</param>
    public void UpdateRecipeComponent(RecipeComponent recipeComponent)
    {
      using (SmartWorkingEntities context = new SmartWorkingEntities())
      {
        RecipeComponent existingObject = context.RecipeComponents.Where(x => x.Id == recipeComponent.Id).FirstOrDefault();

        //no record of this item in the DB, item being passed in has a PK
        if (existingObject == null && recipeComponent.Id > 0)
        {
          //TODO:
          return;
        }
        //Item has no PK value, must be new
        if (recipeComponent.Id <= 0)
        {
          context.RecipeComponents.AddObject(recipeComponent.CopyWithOutReferences());
        }
        //Item was retrieved, and the item passed has a valid ID, do an update
        else
        {
          context.RecipeComponents.ApplyCurrentValues(recipeComponent.CopyWithOutReferences());
        }

        context.SaveChanges();
      }
    }

    /// <summary>
    /// Deletes the material from recipe.
    /// </summary>
    /// <param name="recipeComponent">The recipe component.</param>
    public void DeleteRecipeComponent(RecipeComponent recipeComponent)
    {
      throw new NotImplementedException();
    }


    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
    }

    #endregion
  }
}