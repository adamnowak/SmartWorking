using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;
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
    public List<RecipePrimitive> GetRecipes(string recipesFilter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Recipe> result = (string.IsNullOrWhiteSpace(recipesFilter))
                                  ? ctx.Recipes.ToList()
                                  : ctx.Recipes.Where(
                                    x => x.Name.StartsWith(recipesFilter)).ToList();
          return result.Select(x => x.GetPrimitive()).ToList();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Gets the <see cref="RecipePackage"/> list filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The contractor name filter.</param>
    /// <returns>
    /// List of contractors filtered by <paramref name="filter"/>.
    /// </returns>
    public List<RecipePackage> GetRecipePackageList(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Recipe> result = (string.IsNullOrWhiteSpace(filter))
                                  ? ctx.Recipes.Include("RecipeComponents.Material.Producer").Include("RecipeComponents.Material.Deliverer").ToList()
                                  : ctx.Recipes.Include("RecipeComponents.Material.Producer").Include("RecipeComponents.Material.Deliverer")
                                                                                                      .Where(x => x.Name.StartsWith(filter)).ToList();
          return result.Select(x => x.GetRecipesPackage()).ToList();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public void CreateOrUpdateRecipePackage(RecipePackage recipePackage)
    {
      try
      {
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          

            Recipe recipe = recipePackage.Recipe.GetEntity();

            Recipe existingObject = context.Recipes.Where(x => x.Id == recipe.Id).FirstOrDefault();

            //no record of this item in the DB, item being passed in has a PK
            if (existingObject == null && recipe.Id > 0)
            {
              throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
            }
            //Item has no PK value, must be new


            if (recipe.Id > 0)
            {
              existingObject.Deleted = DateTime.Now;
              context.Recipes.ApplyCurrentValues(existingObject);

            }

            recipe.Id = 0;
            context.Recipes.AddObject(recipe);
            foreach (
              RecipeComponentAndMaterialPackage recipeComponentAndMaterialPackage in
                recipePackage.RecipeComponentAndMaterialList)
            {
              recipeComponentAndMaterialPackage.RecipeComponent.Id = 0;
              RecipeComponent recipeComponent = recipeComponentAndMaterialPackage.RecipeComponent.GetEntity();
              recipeComponent.Recipe = recipe;
              context.RecipeComponents.AddObject(recipeComponent);
            }

            context.SaveChanges();
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    /// <param name="recipe">The recipe which will be deleted.</param>
    public void DeleteRecipe(RecipePrimitive recipePrimitive)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
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