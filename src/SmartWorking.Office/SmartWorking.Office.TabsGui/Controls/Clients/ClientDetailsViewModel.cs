using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Buildings;
using SmartWorking.Office.TabsGui.Controls.Materials;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class ClientDetailsViewModel : EditableControlViewModelBase<ClientAndBuildingsPackage>
  {
    public ClientDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      BuildingListToAddViewModel = new BuildingListViewModel(MainViewModel, null, ModalDialogService, ServiceFactory);
    }

    public BuildingListViewModel BuildingListToAddViewModel { get; private set; }

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
      if (Item != null)
      {
        BuildingListToAddViewModel.Items.LoadItems(Item.Buildings);
      }
      else
      {
        BuildingListToAddViewModel.Items.LoadItems(null);
      }

    }
  }
}