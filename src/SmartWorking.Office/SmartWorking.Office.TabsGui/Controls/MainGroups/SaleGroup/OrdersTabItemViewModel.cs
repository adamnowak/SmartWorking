﻿using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Controls.Clients;
using SmartWorking.Office.TabsGui.Controls.Drivers;
using SmartWorking.Office.TabsGui.Controls.Orders;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup
{
  /// <summary>
  /// View model for drivers and cars tab item
  /// </summary>
  public class OrdersTabItemViewModel : TabItemViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OrdersTabItemViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public OrdersTabItemViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      OrderDetailsViewModel = new OrderDetailsViewModel(MainViewModel, ModalDialogProvider, ServiceFactory);
      OrderListViewModel = new OrderListViewModel(MainViewModel, OrderDetailsViewModel, ModalDialogProvider, ServiceFactory);

      OrderDetailsViewModel.DeliveryNoteDetailsViewModel.ItemSaved += new System.EventHandler(DeliveryNoteDetailsViewModel_ItemSaved);
      OrderDetailsViewModel.DeliveryNoteDetailsViewModel.IsReadOnlyChanged += new System.EventHandler(DeliveryNoteDetailsViewModel_IsReadOnlyChanged);
      OrderDetailsViewModel.DeliveryNoteListViewModel.ItemDeactivatedFlagChanged += new System.EventHandler(DeliveryNoteListViewModel_ItemDeactivatedFlagChanged);
    }

    void DeliveryNoteListViewModel_ItemDeactivatedFlagChanged(object sender, System.EventArgs e)
    {
      if (OrderDetailsViewModel.DeliveryNoteDetailsViewModel.IsReadOnly)
      {
        Refresh();
      }
    }

    void DeliveryNoteDetailsViewModel_IsReadOnlyChanged(object sender, System.EventArgs e)
    {
      if (OrderDetailsViewModel.DeliveryNoteDetailsViewModel.IsReadOnly)
      {
        Refresh();
      }
    }

    

    void DeliveryNoteDetailsViewModel_ItemSaved(object sender, System.EventArgs e)
    {
      if (MainViewModel.Configuration.PagesToPrint <= 0)
      {
        Refresh();
      }
    }

    

    /// <summary>
    /// Gets the car list view model.
    /// </summary>
    public OrderListViewModel OrderListViewModel { get; private set; }

    /// <summary>
    /// Gets the car details view model.
    /// </summary>
    public OrderDetailsViewModel OrderDetailsViewModel { get; private set; }

    

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.OrdersTabItemViewModel_Name; }
    }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    protected override bool OnRefresh()
    {
      OrderListViewModel.Refresh();
      OrderDetailsViewModel.Refresh();
      return true;

    }

    public override bool IsReadOnly
    {
      get
      {
        return base.IsReadOnly &&
               (OrderListViewModel != null ? OrderListViewModel.IsReadOnly : true)  &&
               (OrderDetailsViewModel != null ? OrderDetailsViewModel.IsReadOnly : true);
      }
    }
  }
}