using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface IRecipesService : IDisposable
  {
    [OperationContract]
    List<Recipe> GetRecipes();

    [OperationContract]
    void UpdateRecipe(Recipe recipeToUpdate);


    // TODO: Add your service operations here
  }
}