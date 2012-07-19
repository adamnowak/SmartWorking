using System;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Drivers
{
  /// <summary>
  /// Driver details view model implementation.
  /// </summary>
  public class DriverDetailsViewModel : EditableControlViewModelBase<DriverAndCarsPackage>
  {
    public CarListViewModel CarListProtectedViewModel { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DriverDetailsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DriverDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      CarListProtectedViewModel = new CarListViewModel(MainViewModel, null, ModalDialogService, ServiceFactory);
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_DriverDetails"; }
    }

    /// <summary>
    /// Edits the item command execute.
    /// </summary>
    protected override void EditItemCommandExecute()
    {
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    /// <summary>
    /// Called when save item.
    /// </summary>
    /// <returns></returns>
    protected override bool OnSaveItem()
    {
      if (base.OnSaveItem())
      {
        using (IDriversService service = ServiceFactory.GetDriversService())
        {
          service.UpdateDriver(Item.Driver);
        }
        return true;
      }
      return false;
    }

    protected override void OnItemChanged(DriverAndCarsPackage oldItem)
    {
      base.OnItemChanged(oldItem);
      if (CarListProtectedViewModel.Items != null && Item != null)
      {
        CarListProtectedViewModel.Items.LoadItems(
          Item.Cars.Select(x => new CarAndDriverPackage() {Car = x, Driver = Item.Driver}));
      }
    }
  }
}