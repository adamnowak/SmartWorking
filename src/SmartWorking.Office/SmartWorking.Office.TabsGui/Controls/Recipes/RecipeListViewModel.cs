﻿using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Recipes
{
  public class RecipeListViewModel : ListingEditableControlViewModel<RecipePackage>
  {
    public RecipeListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<RecipePackage> editingViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogProvider, serviceFactory)
    {
    }

    public override string Name
    {
      get { return Resources.RecipeListViewModel_Name; }
    }

    protected override void  OnLoadItems()
    {
      RecipePackage selectedItem = Items.SelectedItem;
      using (IRecipesService service = ServiceFactory.GetRecipesService())
      {
        Items.LoadItems(service.GetRecipePackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        RecipePackage selectionFromItems =
          Items.Items.Where(x => x.Recipe.Id == selectedItem.Recipe.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void OnAddItem()
    {
      base.OnAddItem();
      EditingViewModel.Item = new RecipePackage() {Recipe = new RecipePrimitive()};
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void OnAddCloneItem()
    {
      base.OnAddCloneItem();
      RecipePackage clone = null;
      if (Items.SelectedItem != null)
      {
        clone = Items.SelectedItem.GetPackageCopy();
      }
      if (clone != null)
      {
        clone.Recipe.Id = 0;
        foreach (RecipeComponentAndMaterialPackage recipeComponentAndMaterialPackage in clone.RecipeComponentAndMaterialList)
        {
          recipeComponentAndMaterialPackage.RecipeComponent.Id = 0;
        }
      }
      else
      {
        clone = new RecipePackage() { Recipe = new RecipePrimitive() };
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override bool OnItemDeletedFlagChanged()
    {
      if (base.OnItemDeletedFlagChanged())
      {
        if (EditingViewModel.Item != null && EditingViewModel.Item.Recipe != null)
        {
          using (IRecipesService service = ServiceFactory.GetRecipesService())
          {
            if (EditingViewModel.Item.Recipe.IsDeleted)
            {
              service.UndeleteRecipe(EditingViewModel.Item.Recipe);
            }
            else
            {
              service.DeleteRecipe(EditingViewModel.Item.Recipe);
            }
          }
        }
        Refresh();
        return true;
      }
      return false;
    }
  }
}
