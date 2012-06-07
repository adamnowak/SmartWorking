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
                                ? ctx.Recipes.Include("RecipeSpecification.Material").ToList()
                                : ctx.Recipes.Include("RecipeSpecification.Material").Where(
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
      using (var ctx = new SmartWorkingEntities())
      {
        ctx.Recipes.ApplyCurrentValues(recipe);
        ctx.SaveChanges();
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
    /// Adds the material to recipe.
    /// </summary>
    /// <param name="recipe">The recipe to which material will be added.</param>
    /// <param name="material">The material which will be added.</param>
    /// <param name="amountOfMaterial">The amount of material which is included in recipe.</param>
    public void AddMaterialToRecipe(Recipe recipe, Material material, float amountOfMaterial)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the amount material in recipe.
    /// </summary>
    /// <param name="recipe">The recipe.</param>
    /// <param name="material">The material.</param>
    /// <param name="amountOfMaterial">The amount of material which will be updated.</param>
    public void UpdateMaterialInRecipe(Recipe recipe, Material material, float amountOfMaterial)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the material from recipe.
    /// </summary>
    /// <param name="recipe">The recipe from which material will be deleted..</param>
    /// <param name="material">The material which will be deleted from recipe.</param>
    public void DeleteMaterialFromRecipe(Recipe recipe, Material material)
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