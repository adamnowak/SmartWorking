using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Buildings;
using SmartWorking.Office.TabsGui.Controls.Materials;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class ClientDetailsViewModel : EditableControlViewModelBase<ClientAndClientBuildingsPackage>
  {
    public ClientDetailsViewModel(IMainViewModel mainViewModel, IListingEditableControlViewModel<BuildingPrimitive> buildingListViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      BuildingListToAddViewModel = buildingListViewModel;
      EditingModeChanged += new EventHandler(ClientDetailsViewModel_EditingModeChanged);
      ClientBuildingListViewModel = new ClientBuildingListViewModel(MainViewModel, null, ModalDialogProvider, ServiceFactory);
    }

    void ClientDetailsViewModel_EditingModeChanged(object sender, EventArgs e)
    {
      if (EditingMode == EditingMode.New)
      {
        if (BuildingListToAddViewModel != null && BuildingListToAddViewModel.EditingViewModel != null)
        {
          BuildingListToAddViewModel.EditingViewModel.EditingMode = EditingMode.New;
          BuildingListToAddViewModel.EditingViewModel.Item = new BuildingPrimitive();
        }
      }
      
    }

    public IListingEditableControlViewModel<BuildingPrimitive> BuildingListToAddViewModel { get; private set; }
    public ClientBuildingListViewModel ClientBuildingListViewModel { get; private set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.ClientDetailsViewModel_Name; }
    }

    protected override void EditItemCommandExecute()
    {
      
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSavingItem()
    {
      if (BuildingListToAddViewModel != null && BuildingListToAddViewModel.EditingViewModel != null)
      {
        if (BuildingListToAddViewModel.EditingViewModel.EditingMode == EditingMode.New)
        {
          if (ModalDialogProvider.ShowMessageBox(ModalDialogProvider, ServiceFactory, MessageBoxImage.Question,
                                            "A co z budową?",
                                            "Chcesz najpierw zapisac budowę?\n Jeśli nie informacje o budowie znikną!",
                                            MessageBoxButton.YesNo, string.Empty) == MessageBoxResult.Yes)
          {
            return false;
          }
        }
        BuildingListToAddViewModel.EditingViewModel.Item = null;
        BuildingListToAddViewModel.EditingViewModel.EditingMode = EditingMode.Display;
      }

      if (base.OnSavingItem())
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
    protected override void OnItemChanged(ClientAndClientBuildingsPackage oldItem)
    {
      SetClientBuildings();
    }

    private void SetClientBuildings()
    {
      if (Item != null)
      {
        ClientBuildingListViewModel.Items.LoadItems(Item.ClientBuildings);
      }
      else
      {
        ClientBuildingListViewModel.Items.LoadItems(null);
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
             !Item.ClientBuildings.Select(x => x.Building.Id).Contains(BuildingListToAddViewModel.Items.SelectedItem.Id);
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
             !Item.ClientBuildings.Select(x => x.Building).Contains(BuildingListToAddViewModel.Items.SelectedItem))
        {
          Item.ClientBuildings.Add(new ClientBuildingAndBuildingPackage() { Building = BuildingListToAddViewModel.Items.SelectedItem, ClientBuilding = new ClientBuildingPrimitive()});
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
      return !IsReadOnly && ClientBuildingListViewModel.Items.SelectedItem != null;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void RemoveBuilding()
    {
      string errorCaption = "TODO!";
      try
      {
        Item.ClientBuildings.Remove(ClientBuildingListViewModel.Items.SelectedItem);
        //if (ClientBuildingListViewModel.Items.SelectedItem != null)
        //{
        //  ClientBuildingPackage toRemove = Item.ClientBuildings.FirstOrDefault(x => x.Building == ClientBuildingListViewModel.Items.SelectedItem);
        //  if (toRemove != null)
        //  {
            
        //  }
        //}
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