﻿using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Materials;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Recipes
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class RecipeDetailsViewModel : EditableControlViewModelBase<RecipePackage>
  {
    public RecipeDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      MaterialListToAddViewModel = new MaterialListViewModel(MainViewModel, null, ModalDialogService, ServiceFactory);
      RecipeComponentDetailsViewModel = new RecipeComponentDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      RecipeComponentListViewModel = new RecipeComponentListViewModel(MainViewModel, RecipeComponentDetailsViewModel, ModalDialogService, ServiceFactory);
    }

    public RecipeComponentListViewModel RecipeComponentListViewModel { get; private set; }
    public RecipeComponentDetailsViewModel RecipeComponentDetailsViewModel { get; private set; }
    public MaterialListViewModel MaterialListToAddViewModel { get; private set; }
    private List<MaterialAndContractorsPackage> AllMaterials { get; set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_CarDetails"; }
    }

    protected override void EditItemCommandExecute()
    {
     
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSaveItem()
    {
      if (base.OnSaveItem())
      {
        //using (IContractorsService service = ServiceFactory.GetContractorsService())
        //{
        //  service.CreateOrUpdateContractor(Item);
        //}
        return true;
      }
      return false;
    }

    

    public override void Refresh()
    {
      base.Refresh();
      LoadAllMaterials();
      SetMaterialsToAdd();
    }

    private void SetMaterialsToAdd()
    {
      if (Item != null && AllMaterials != null)
      {
        MaterialListToAddViewModel.Items.LoadItems(
          AllMaterials.Where(
            x =>
            !Item.RecipeComponentAndMaterialList.Select(y => y.MaterialAndContractors.Material.Id).Contains(x.Material.Id)));
      }
    }

    private void LoadAllMaterials()
    {
      using (IMaterialsService service = ServiceFactory.GetMaterialsService())
      {
        AllMaterials = service.GetMaterialAndContractorsPackageList(MaterialListToAddViewModel.Filter, MaterialListToAddViewModel.ListItemsFilter);
      }
    }


    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    protected override void OnItemChanged(RecipePackage oldItem)
    {
      if (Item != null)
      {
        base.OnItemChanged(oldItem);
        SetMaterialsToAdd();
        RecipeComponentListViewModel.Items.LoadItems(Item.RecipeComponentAndMaterialList);
      }
    }
  }
}