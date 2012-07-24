using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Drivers
{
  /// <summary>
  /// View model for listing drivers.
  /// </summary>
  public class DriverListViewModel : ListingEditableControlViewModel<DriverAndCarsPackage>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DriverListViewModel"/> class.
    /// </summary>
    /// <param name="editingViewModel">The editing view model.</param>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DriverListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<DriverAndCarsPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "str_DriverList"; }
    }


    /// <summary>
    /// Called when load items.
    /// </summary>
    protected override void  OnLoadItems()
    {
      DriverAndCarsPackage selectedItem = Items.SelectedItem;
      using (IDriversService service = ServiceFactory.GetDriversService())
      {
        Items.LoadItems(service.GetDriverAndCarsPackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        DriverAndCarsPackage selectionFromItems =
          Items.Items.Where(x => x.Driver.Id == selectedItem.Driver.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    /// <summary>
    /// Adds the item command execute.
    /// </summary>
    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new DriverAndCarsPackage() { Driver = new DriverPrimitive() };
      EditingViewModel.EditingMode = EditingMode.New;
    }

    /// <summary>
    /// Adds the clone item command execute.
    /// </summary>
    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      DriverAndCarsPackage clone = Items.SelectedItem.GetPackageCopy();
      if (clone != null)
      {
        clone.Driver.Id = 0;        
      }
      else
      {
        clone = new DriverAndCarsPackage() { Driver = new DriverPrimitive() };
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override bool OnDeleteItem()
    { 
      if (base.OnDeleteItem())
      {
        using (IDriversService service = ServiceFactory.GetDriversService())
        {
          service.DeleteDriver(EditingViewModel.Item.Driver);
        }
        Refresh();
        return true;
      }
      return false;
    }
  }

  
}
