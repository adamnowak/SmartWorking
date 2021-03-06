﻿using System;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Properties;
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
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DriverDetailsViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      CarListProtectedViewModel = new CarListViewModel(MainViewModel, null, ModalDialogProvider, ServiceFactory);
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.DriverDetailsViewModel_Name; }
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
    protected override bool OnSavingItem()
    {
      if (base.OnSavingItem())
      {
        using (IDriversService service = ServiceFactory.GetDriversService())
        {
          service.CreateOrUpdateDriver(Item.Driver);
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