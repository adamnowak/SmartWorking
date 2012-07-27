using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  public class ClientBuildingListViewModel : ListingEditableControlViewModel<ClientBuildingPackage>
  {
    public ClientBuildingListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<ClientBuildingPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_BuildingList"; }
    }
  }
}
