using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Enums;
using SmartWorking.Office.PrimitiveEntities.Packages;
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
    public List<RecipePrimitive> GetRecipes(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Recipe> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Recipes.ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Recipes.Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Recipes.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Recipes.Where(x => (x.Code.StartsWith(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Recipes.Where(x => !x.Deleted.HasValue && (x.Code.StartsWith(filter))).ToList()
                      : ctx.Recipes.Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.Code.StartsWith(filter))).ToList();
          return result.Select(x => x.GetPrimitive()).ToList();


          //todo po symbolu cemnetu
          //ctx.Recipes.Where(x => (x.Code.Contains(filter) || 
          //          x.RecipeComponents.Where(
          //          y => ((y.Material.MaterialType.HasValue && y.Material.MaterialType.Value == (int)MaterialTypeEnum.Concrete) && 
          //            (y.Material.InternalName.Contains(filter)))).Count() > 0
          //            )).ToList()
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
          List<Recipe> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Recipes.Include("RecipeComponents.Material.Producer").Include("RecipeComponents.Material.Deliverer").ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Recipes.Include("RecipeComponents.Material.Producer").Include("RecipeComponents.Material.Deliverer").Where(x => !x.Deleted.HasValue).ToList()
                      : ctx.Recipes.Include("RecipeComponents.Material.Producer").Include("RecipeComponents.Material.Deliverer").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue).ToList()
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Recipes.Include("RecipeComponents.Material.Producer").Include("RecipeComponents.Material.Deliverer").Where(x => (x.Code.StartsWith(filter))).ToList()
                  : (listItemsFilterValue == ListItemsFilterValues.IncludeDeactive)
                      ? ctx.Recipes.Include("RecipeComponents.Material.Producer").Include("RecipeComponents.Material.Deliverer").Where(x => !x.Deleted.HasValue && (x.Code.StartsWith(filter))).ToList()
                      : ctx.Recipes.Include("RecipeComponents.Material.Producer").Include("RecipeComponents.Material.Deliverer").Where(x => !x.Deleted.HasValue && !x.Deactivated.HasValue && (x.Code.StartsWith(filter))).ToList();
          
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
        if (recipePackage != null && recipePackage.Recipe != null)
        {
          using (SmartWorkingEntities context = new SmartWorkingEntities())
          {
            Recipe existingObject = context.Recipes.Include("RecipeComponents").Where(x => x.Id == recipePackage.Recipe.Id).FirstOrDefault();

            //no record of this item in the DB, item being passed in has a PK
            if (existingObject == null && recipePackage.Recipe.Id > 0)
            {
              throw new FaultException<ExceptionDetail>(new ExceptionDetail(new Exception("Błąd zapisu do bazy")),
                                                        "Obiekt nie istniał w bazie, a jego Id jest większe od 0.");
            }
            //Item has no PK value, must be new

            //Item has no PK value, must be new);
            if (recipePackage.Recipe.Id <= 0)
            {
              Recipe recipe = recipePackage.Recipe.GetEntity();
              context.Recipes.AddObject(recipe);
              foreach (RecipeComponentAndMaterialPackage recipeComponentAndMaterialPackage in recipePackage.RecipeComponentAndMaterialList)
              {                
                  RecipeComponentPrimitive recipeComponentPrimitive =
                    recipeComponentAndMaterialPackage.GetRecipeComponentPrimitiveWithReference();
                  if (recipeComponentPrimitive != null)
                  {
                    recipeComponentPrimitive.Id = 0;
                    RecipeComponent recipeComponent= recipeComponentPrimitive.GetEntity();
                    recipeComponent.Recipe = recipe;
                    context.RecipeComponents.AddObject(recipeComponent);
                  }
              }
            }
            //Item was retrieved, and the item passed has a valid ID, do an update
            else
            {
              List<RecipeComponentPrimitive> existingRecipeComponents = existingObject.RecipeComponents.Select(x => x.GetPrimitive()).ToList();
              List<RecipeComponentPrimitive> newRecipeComponents = recipePackage.GetRecipeComponentListWithReference().ToList();
              List<RecipeComponentPrimitive> theSameElements = newRecipeComponents.Where(x => existingRecipeComponents.Select(y => y.Id).Contains(x.Id)).ToList();

              existingRecipeComponents.RemoveAll(x => theSameElements.Select(y => y.Id).Contains(x.Id));
              newRecipeComponents.RemoveAll(x => theSameElements.Select(y => y.Id).Contains(x.Id));

              //remove 
              if (existingRecipeComponents.Count() > 0)
              {
                List<int> existingRecipeComponentIds = existingRecipeComponents.Select(x => x.Id).ToList();
                List<RecipeComponent> recipeComponentListToDelete =
                  context.RecipeComponents.Where(x => existingRecipeComponentIds.Contains(x.Id)).ToList();

                foreach (RecipeComponent recipeComponent in recipeComponentListToDelete)
                {
                  context.RecipeComponents.DeleteObject(recipeComponent);
                }
              }

              //add
              foreach (RecipeComponentPrimitive newRecipeComponent in newRecipeComponents)
              {
                context.RecipeComponents.AddObject(newRecipeComponent.GetEntity());
              }

              context.Recipes.ApplyCurrentValues(recipePackage.Recipe.GetEntity());
            }

            context.SaveChanges();

            //TODO: FOR THE FUTURE
            //if (recipePackage.Recipe.Id > 0)
            //{
            //  existingObject.Deleted = DateTime.Now;
            //  context.Recipes.ApplyCurrentValues(existingObject);
            //}            
            //Recipe recipe = recipePackage.Recipe.GetEntity();
            //recipe.Id = 0;
            //context.Recipes.AddObject(recipe);
            //foreach (
            //  RecipeComponentAndMaterialPackage recipeComponentAndMaterialPackage in
            //    recipePackage.RecipeComponentAndMaterialList)
            //{
            //  recipeComponentAndMaterialPackage.RecipeComponent.Id = 0;
            //  RecipeComponent recipeComponent =
            //    recipeComponentAndMaterialPackage.GetRecipeComponentPrimitiveWithReference().GetEntity();
            //  recipeComponent.Recipe = recipe;
            //  context.RecipeComponents.AddObject(recipeComponent);
            //}
            //context.SaveChanges();
          }
        }
        else
        {
          throw new Exception("str_Inpute parameter was wrong.");
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
        if (recipePrimitive != null)
        {
          using (SmartWorkingEntities context = new SmartWorkingEntities())
          {
            Recipe recipe = context.Recipes.Where(x => x.Id == recipePrimitive.Id).FirstOrDefault();
            if (recipe != null)
            {
              recipe.Deleted = DateTime.Now;
              context.SaveChanges();
            }
            else
            {
              throw new Exception("This car does not exist in db.");
            }

            context.SaveChanges();
          }
        }
        else
        {
          throw new Exception("str_Inpute parameter was wrong.");
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    public void UndeleteRecipe(RecipePrimitive recipePrimitive)
    {
      try
      {
        if (recipePrimitive != null)
        {
          using (SmartWorkingEntities context = new SmartWorkingEntities())
          {
            Recipe recipe = context.Recipes.Where(x => x.Id == recipePrimitive.Id).FirstOrDefault();
            if (recipe != null)
            {
              recipe.Deleted = null;
              context.SaveChanges();
            }
            else
            {
              throw new Exception("This car does not exist in db.");
            }

            context.SaveChanges();
          }
        }
        else
        {
          throw new Exception("str_Inpute parameter was wrong.");
        }
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