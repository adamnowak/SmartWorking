using System;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class CarDetailsViewModel : EditableControlViewModelBase<CarAndDriverPackage>
  {
    public CarDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      Drivers = new SelectableViewModelBase<DriverPrimitive>();
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_CarDetails"; }
    }

    protected override void EditItemCommandExecute()
    {
      LoadDrivers();
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSaveItem()
    {
      Item.Driver = Drivers.SelectedItem;
      if (base.OnSaveItem())
      {
        using (ICarsService service = ServiceFactory.GetCarsService())
        {
          service.CreateOrUpdateCar(Item.GetCarPrimitiveWithReference());
        }
        return true;
      }
      return false;
    }

    public SelectableViewModelBase<DriverPrimitive> Drivers { get; private set; }

    protected override bool OnRefresh()
    {      
      LoadDrivers();
      return base.OnRefresh();
    }

    private void LoadDrivers()
    {
      using (IDriversService service = ServiceFactory.GetDriversService())
      {
        Drivers.LoadItems(service.GetDrivers(string.Empty, ListItemsFilterValues.OnlyActive));
      }
    }

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    protected override void OnItemChanged(CarAndDriverPackage oldItem)
    {
      if (Drivers.Items != null && Item != null && Item.Driver != null)
      {
        Drivers.SelectedItem = Drivers.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
        Item.Driver = Drivers.SelectedItem;
      }
      else
      {
        Drivers.SelectedItem = null;
      }

    }
  }
}