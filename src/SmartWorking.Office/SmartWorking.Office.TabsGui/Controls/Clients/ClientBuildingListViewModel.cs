using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Clients
{
  public class ClientBuildingListViewModel : ListingEditableControlViewModel<ClientBuildingAndBuildingPackage>
  {
    public ClientBuildingListViewModel(IMainViewModel mainViewModel,
                                       IEditableControlViewModel<ClientBuildingAndBuildingPackage> editingViewModel,
                                       IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return Resources.ClientBuildingListViewModel_Name; }
    }
  }
}