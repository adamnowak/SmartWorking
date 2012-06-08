﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Recipe.
  /// </summary>
  [ServiceContract]
  public interface IRecipesService : IDisposable
  {
    /// <summary>
    /// Gets the recipes filtered be <paramref name="recipesFilter"/>.
    /// </summary>
    /// <param name="recipesFilter">The recipes filter.</param>
    /// <returns>List of Recipe filtered by <paramref name="recipesFilter"/>. Recipe contains list of Material contains to this Recipe.</returns>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    List<Recipe> GetRecipes(string recipesFilter);

    /// <summary>
    /// Updates the recipe.
    /// </summary>
    /// <param name="recipe">The recipe which will be updated.</param>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void UpdateRecipe(Recipe recipe);

    /// <summary>
    /// Deletes the recipe.
    /// </summary>
    /// <param name="recipe">The recipe which will be deleted.</param>
    /// <remarks>Only recipe which is not used can be deleted.</remarks>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void DeleteRecipe(Recipe recipe);

    /// <summary>
    /// Adds the material to recipe.
    /// </summary>
    /// <param name="recipe">The recipe to which material will be added.</param>
    /// <param name="material">The material which will be added.</param>
    /// <param name="amountOfMaterial">The amount of material which is included in recipe.</param>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void AddMaterialToRecipe(Recipe recipe, Material material, float amountOfMaterial);

    /// <summary>
    /// Updates the amount material in recipe.
    /// </summary>
    /// <param name="recipe">The recipe.</param>
    /// <param name="material">The material.</param>
    /// <param name="amountOfMaterial">The amount of material which will be updated.</param>
    /// <remarks>Only amount of material will be updated.</remarks>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void UpdateMaterialInRecipe(Recipe recipe, Material material, float amountOfMaterial);

    /// <summary>
    /// Deletes the material from recipe.
    /// </summary>
    /// <param name="recipe">The recipe from which material will be deleted..</param>
    /// <param name="material">The material which will be deleted from recipe.</param>
    [OperationContract]
    [ApplyDataContractResolver]
    [CyclicReferencesAware(true)]
    void DeleteMaterialFromRecipe(Recipe recipe, Material material);
  }
}