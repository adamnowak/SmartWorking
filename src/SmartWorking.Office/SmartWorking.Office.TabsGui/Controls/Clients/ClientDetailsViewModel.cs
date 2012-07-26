﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Buildings;
using SmartWorking.Office.TabsGui.Controls.Materials;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class ClientDetailsViewModel : EditableControlViewModelBase<ClientAndBuildingsPackage>
  {
    public ClientDetailsViewModel(IMainViewModel mainViewModel, IListingEditableControlViewModel<BuildingPrimitive> buildingListViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      BuildingListToAddViewModel = buildingListViewModel;

      ClientBuildingsListViewModel = new BuildingListViewModel(MainViewModel, null, ModalDialogService, ServiceFactory);
    }

    public IListingEditableControlViewModel<BuildingPrimitive> BuildingListToAddViewModel { get; private set; }
    public BuildingListViewModel ClientBuildingsListViewModel { get; private set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_ClientDetails"; }
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
        using (IClientsService service = ServiceFactory.GetClientsService())
        {
          service.CreateOrUpdateClient(Item);
        }
        return true;
      }
      return false;
    }

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    protected override void OnItemChanged(ClientAndBuildingsPackage oldItem)
    {
      SetClientBuildings();
    }

    private void SetClientBuildings()
    {
      if (Item != null)
      {
        ClientBuildingsListViewModel.Items.LoadItems(Item.Buildings);
      }
      else
      {
        ClientBuildingsListViewModel.Items.LoadItems(null);
      }
    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly;
      }
    }


    #region AddBuildingCommand
    private ICommand _addBuildingCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand AddBuildingCommand
    {
      get
      {
        if (_addBuildingCommand == null)
          _addBuildingCommand = new RelayCommand(AddBuilding, CanAddBuilding);
        return _addBuildingCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanAddBuilding()
    {
      return !IsReadOnly &&
             BuildingListToAddViewModel.Items.SelectedItem != null &&
             !Item.Buildings.Contains(BuildingListToAddViewModel.Items.SelectedItem);
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void AddBuilding()
    {
      string errorCaption = "TODO!";
      try
      {
        if (BuildingListToAddViewModel.Items.SelectedItem != null &&
             !Item.Buildings.Contains(BuildingListToAddViewModel.Items.SelectedItem))
        {
          Item.Buildings.Add(BuildingListToAddViewModel.Items.SelectedItem);
        }
        SetClientBuildings();
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
    #endregion //AddBuildingCommand

    #region RemoveBuildingCommand
    private ICommand _removeBuildingCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand RemoveBuildingCommand
    {
      get
      {
        if (_removeBuildingCommand == null)
          _removeBuildingCommand = new RelayCommand(RemoveBuilding, CanRemoveBuilding);
        return _removeBuildingCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanRemoveBuilding()
    {
      return !IsReadOnly && ClientBuildingsListViewModel.Items.SelectedItem != null;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void RemoveBuilding()
    {
      string errorCaption = "TODO!";
      try
      {
        if (ClientBuildingsListViewModel.Items.SelectedItem != null)
        {
          Item.Buildings.Remove(ClientBuildingsListViewModel.Items.SelectedItem);
        }
        SetClientBuildings();
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
    #endregion //RemoveBuildingCommand
  }
}