using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;

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
    [WebInvoke(Method = "GET", UriTemplate = "/GetRecipes/?filter={filter}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<RecipePrimitive> GetRecipes(string filter);

    /// <summary>
    /// Gets the <see cref="RecipePackage"/> list filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The contractor name filter.</param>
    /// <returns>
    /// List of contractors filtered by <paramref name="filter"/>. 
    /// </returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetRecipesPackage/?filter={filter}",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    List<RecipePackage> GetRecipesPackage(string filter);

    /// <summary>
    /// Updates the recipe.
    /// </summary>
    /// <param name="recipe">The recipe which will be updated.</param>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateRecipe",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UpdateRecipe(RecipePrimitive recipe);

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


    /// <summary>
    /// Updates the amount material in recipe.
    /// </summary>
    /// <param name="recipe">The recipe.</param>
    /// <param name="recipeComponent">The recipe component.</param>
    /// <remarks>
    /// Only amount of material will be updated.
    /// </remarks>
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/UpdateRecipeComponent",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void UpdateRecipeComponent(RecipeComponentPrimitive recipeComponent);

    /// <summary>
    /// Deletes the material from recipe.
    /// </summary>
    /// <param name="recipeComponent">The recipe component.</param>
    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteRecipeComponent",
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped)]
    void DeleteRecipeComponent(RecipeComponentPrimitive recipeComponent);
  }
}