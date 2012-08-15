using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Recipe.
  /// </summary>
  [ServiceContract]
  public interface IRecipesService : IDisposable
  {
    /// <summary>
    /// Gets the recipes filtered be <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The recipes filter.</param>
    /// <returns>List of Recipe filtered by <paramref name="filter"/>. Recipe contains list of Material contains to this Recipe.</returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRecipes/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<RecipePrimitive> GetRecipes(string filter, ListItemsFilterValues listItemsFilterValue);

    /// <summary>
    /// Gets the <see cref="RecipePackage"/> list filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The contractor name filter.</param>
    /// <returns>
    /// List of contractors filtered by <paramref name="filter"/>. 
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRecipePackageList/?filter={filter}&listFilter={listItemsFilterValue}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<RecipePackage> GetRecipePackageList(string filter, ListItemsFilterValues listItemsFilterValue);

    /// <summary>
    /// Gets the recipe package according <paramref name="recipeId"/>.
    /// </summary>
    /// <param name="recipeId">The recipe id.</param>
    /// <returns><see cref="RecipePackage"/> for recipe with <paramref name="recipeId"/>.</returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRecipePackage/?Id={recipeId}",
      RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    RecipePackage GetRecipePackage(int recipeId);

    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/CreateOrUpdateRecipePackage",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void CreateOrUpdateRecipePackage(RecipePackage item);

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    /// <param name="recipe">The recipe which will be deleted.</param>
    /// <remarks>Only recipe which is not used can be deleted.</remarks>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteRecipe",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteRecipe(RecipePrimitive recipe);

    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/UndeleteRecipe",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UndeleteRecipe(RecipePrimitive car);
   
  }
}