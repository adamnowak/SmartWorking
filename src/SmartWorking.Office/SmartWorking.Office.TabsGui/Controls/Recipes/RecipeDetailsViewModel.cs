using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
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
      RecipeComponentListViewModel.Items.SelectedItemChanged += new EventHandler<SelectedItemChangedEventArgs<RecipeComponentAndMaterialPackage>>(Items_SelectedItemChanged);
    }

    void Items_SelectedItemChanged(object sender, SelectedItemChangedEventArgs<RecipeComponentAndMaterialPackage> e)
    {//'override' because RecipeComponentDetailsViewModel is in display mode
      if (RecipeComponentDetailsViewModel != null && e != null)
      {
        RecipeComponentDetailsViewModel.Item = e.NewValue;
      }
    }

    /// <summary>
    /// Gets the recipe component list view model o control displaying materials in recipe.
    /// </summary>
    public RecipeComponentListViewModel RecipeComponentListViewModel { get; private set; }

    /// <summary>
    /// Gets the recipe component details view model of selected recipe component on control served by RecipeComponentListViewModel.
    /// </summary>
    public RecipeComponentDetailsViewModel RecipeComponentDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the material list view model of control displaying materials to add to recipe.
    /// </summary>
    public MaterialListViewModel MaterialListToAddViewModel { get; private set; }

    /// <summary>
    /// Gets or sets all materials available in database (according filters).
    /// </summary>
    /// <value>
    /// All materials available in database (according filters).
    /// </value>
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
      //RecipeComponentDetailsViewModel.EditingMode = EditingMode.Edit;
      //RecipeComponentDetailsViewModel.Item = RecipeComponentDetailsViewModel.Item.GetPackageCopy();
      //RecipeComponentListViewModel.EditingMode = EditingMode.Edit;
    }

    protected override bool OnSaveItem()
    {
      if (base.OnSaveItem())
      {
        RecipeComponentDetailsViewModel.EditingMode = EditingMode.Display;
        Item.RecipeComponentAndMaterialList.Clear();
        foreach (RecipeComponentAndMaterialPackage recipeComponentAndMaterialPackage in RecipeComponentListViewModel.Items.Items)
        {
          Item.RecipeComponentAndMaterialList.Add(recipeComponentAndMaterialPackage);
        }

        using (IRecipesService service = ServiceFactory.GetRecipesService())
        {
          service.CreateOrUpdateRecipePackage(Item);
        }
        return true;
      }
      return false;
    }



    protected override bool OnRefresh()
    {
      if (base.OnRefresh())
      {
        LoadAllMaterials();
        SetMaterialsToAdd();
        return true;
      }
      return false;
    }

    private void SetMaterialsToAdd()
    {
      if (AllMaterials != null)
      {
        if (RecipeComponentListViewModel.Items != null && RecipeComponentListViewModel.Items.Items != null)
        {
          MaterialListToAddViewModel.Items.LoadItems(
            AllMaterials.Where(
              x =>
              !RecipeComponentListViewModel.Items.Items.Select(y => y.MaterialAndContractors.Material.Id).Contains(
                x.Material.Id)));
        }
        else
        {
          MaterialListToAddViewModel.Items.LoadItems(AllMaterials);
        }
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
      base.OnItemChanged(oldItem);
      if (Item != null)
      {
        RecipeComponentListViewModel.Items.LoadItems(Item.RecipeComponentAndMaterialList);
      }
      else
      {
        RecipeComponentListViewModel.Items.LoadItems(null);
      }
      SetMaterialsToAdd();
    }

    #region AddMaterialCommand
    private ICommand _addMaterialCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand AddMaterialCommand
    {
      get
      {
        if (_addMaterialCommand == null)
          _addMaterialCommand = new RelayCommand(AddMaterial, CanAddMaterial);
        return _addMaterialCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanAddMaterial()
    {
      return !IsReadOnly && MaterialListToAddViewModel.Items.SelectedItem != null;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void AddMaterial()
    {
      string errorCaption = "TODO!";
      try
      {
        if (MaterialListToAddViewModel.Items.SelectedItem != null)
        {
          RecipeComponentAndMaterialPackage newRecipeComponentAndMaterialPackage = new RecipeComponentAndMaterialPackage()
            {
              MaterialAndContractors = MaterialListToAddViewModel.Items.SelectedItem,
              RecipeComponent = new RecipeComponentPrimitive()
            };
          RecipeComponentListViewModel.Items.Items.Add(newRecipeComponentAndMaterialPackage);
          RecipeComponentListViewModel.Items.SelectedItem = newRecipeComponentAndMaterialPackage;
          SetMaterialsToAdd();
        }
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }
    #endregion //AddMaterialCommand

    #region RemoveMaterialCommand
    private ICommand _removeMaterialCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand RemoveMaterialCommand
    {
      get
      {
        if (_removeMaterialCommand == null)
          _removeMaterialCommand = new RelayCommand(RemoveMaterial, CanRemoveMaterial);
        return _removeMaterialCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanRemoveMaterial()
    {
      return !IsReadOnly && RecipeComponentListViewModel.Items.SelectedItem != null;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void RemoveMaterial()
    {
      string errorCaption = "TODO!";
      try
      {
        RecipeComponentListViewModel.Items.Items.Remove(RecipeComponentListViewModel.Items.SelectedItem);
        SetMaterialsToAdd();
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }
    #endregion //RemoveMaterialCommand

    protected override bool OnEditingModeChanged()
    {
      if (base.OnEditingModeChanged())
      {
        if (RecipeComponentListViewModel != null)
        {
          RecipeComponentListViewModel.EditingMode = EditingMode;
        }
        if (RecipeComponentDetailsViewModel != null)
        {
          RecipeComponentDetailsViewModel.EditingMode = EditingMode;
        }
        return true;
      }
      return false;
    }
  }
}