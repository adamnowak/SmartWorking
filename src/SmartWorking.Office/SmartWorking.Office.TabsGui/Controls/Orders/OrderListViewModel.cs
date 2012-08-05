using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Orders
{
  public class OrderListViewModel : ListingEditableControlViewModel<OrderPackage>
  {
    private bool wasCleared = false;
    public OrderListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<OrderPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
      
    }

    public override string Name
    {
      get { return Resources.OrderListViewModel_Name; }
    }

   
    protected override void  OnLoadItems()
    {

      OrderPackage selectedItem = Items.SelectedItem;
      using (IOrdersService service = ServiceFactory.GetOrdersService())
      {
        Items.LoadItems(service.GetOrderPackageList(Filter, ListItemsFilter));
        if (!wasCleared)
        {
          bool shouuldRefresh = ClearList();
          wasCleared = true;
          if (shouuldRefresh)
          {
            Refresh();
          }
        }
      }
      if (selectedItem != null)
      {
        OrderPackage selectionFromItems =
          Items.Items.Where(x => x.Order.Id == selectedItem.Order.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    private bool ClearList()
    {
      bool result = false;
      try
      {
          
      
        DateTime deactiveBefore = DateTime.Now.Date;
        List<OrderPackage> olderOrderPackageList =
          Items.Items.Where(
            x =>
            x.Order != null && !x.Order.Deactivated.HasValue &&
            (!x.Order.DateOfOrder.HasValue || (x.Order.DateOfOrder.HasValue && x.Order.DateOfOrder.Value < deactiveBefore)))
            .ToList();
        if (olderOrderPackageList.Count > 0)
        {
          string info = "Liczba starych zamówień: " + olderOrderPackageList.Count + "\n";

          info += olderOrderPackageList.Select(x => new
                                              {
                                                DateOfOrder = (x.Order != null && x.Order.DateOfOrder != null) ? x.Order.DateOfOrder.ToString() : string.Empty,
                                                Client = (x.Client != null && !string.IsNullOrEmpty(x.Client.InternalName)) ? x.Client.InternalName : string.Empty,
                                                Building = (x.ClientBuildingPackage != null && x.ClientBuildingPackage.Building != null && !string.IsNullOrEmpty(x.ClientBuildingPackage.Building.InternalName)) ? x.ClientBuildingPackage.Building.InternalName : string.Empty
                                              })
                                              .Select(y => y.DateOfOrder.ToString() + ", " + y.Client.ToString() + ", " + y.Building.ToString())
                                              .Aggregate((current, next) => current + "\n" + next);
          if (MessageBoxResult.Yes == 
            ModalDialogService.ShowMessageBox(ModalDialogService, ServiceFactory, MessageBoxImage.Question, 
              "Ukryć starsze zamówienia?", "Czy ukryć zamówienia z dni poprzednich?", MessageBoxButton.YesNo, info))
          {
            using (IOrdersService service = ServiceFactory.GetOrdersService())
            {
              foreach (OrderPackage orderPackage in olderOrderPackageList)
              {
                service.DeactiveOrder(orderPackage.Order);
                result = true;
              } 
            }
          }
        }
      }
      catch (Exception exception)
      {
        ShowError("Błąd przy ukrywaniu starszych zamówień", exception);
      }
      return result;
    }

    #region IsPreparingDelivery
    /// <summary>
    /// The <see cref="IsPreparingDelivery" /> property's name.
    /// </summary>
    public const string IsPreparingDeliveryPropertyName = "IsPreparingDelivery";

    private bool _isPreparingDelivery;

    /// <summary>
    /// Gets the IsPreparingDelivery property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool IsPreparingDelivery
    {
      get
      {
        return _isPreparingDelivery;
      }

      set
      {
        if (_isPreparingDelivery == value)
        {
          return;
        }
        _isPreparingDelivery = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(IsPreparingDeliveryPropertyName);
      }
    }
    #endregion //IsPreparingDelivery

    #region PrepareDeliverCommand
    private ICommand _prepareDeliverCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand PrepareDeliverCommand
    {
      get
      {
        if (_prepareDeliverCommand == null)
          _prepareDeliverCommand = new RelayCommand(PrepareDeliver, CanPrepareDeliver);
        return _prepareDeliverCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanPrepareDeliver()
    {
      return Items.SelectedItem != null;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void PrepareDeliver()
    {
      string errorCaption = "TODO!";
      try
      {
        IsPreparingDelivery = !IsPreparingDelivery;
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
      }
    }
    #endregion //PrepareDeliverCommand

    protected override void OnAddItem()
    {
      base.OnAddItem();
      EditingViewModel.Item = new OrderPackage() {Order = new OrderPrimitive()};
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void OnAddCloneItem()
    {
      base.OnAddCloneItem();
      OrderPackage clone = Items.SelectedItem.GetPackageCopy();
      if (clone != null)
      {
        clone.Order.Id = 0;        
      }
      else
      {
        clone = new OrderPackage() {Order = new OrderPrimitive()};
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override bool  OnItemDeletedFlagChanged()
    {      
      if (base.OnItemDeletedFlagChanged())
      {
        using (IOrdersService service = ServiceFactory.GetOrdersService())
        {
          service.DeleteOrder(EditingViewModel.Item.Order);
        }
        Refresh();
        return true;
      }
      return false;
    }


    #region DeactiveOrderCommand
    private ICommand _deactiveOrderCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand DeactiveOrderCommand
    {
      get
      {
        if (_deactiveOrderCommand == null)
          _deactiveOrderCommand = new RelayCommand(DeactiveOrder, CanDeactiveOrder);
        return _deactiveOrderCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanDeactiveOrder()
    {
      return Items.SelectedItem != null;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void DeactiveOrder()
    {
      string errorCaption = "TODO!";
      try
      {
        using (IOrdersService service = ServiceFactory.GetOrdersService())
        {
          service.DeactiveOrder(Items.SelectedItem.Order);
        }
        Refresh();
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
    #endregion //DeactiveOrderCommand
  }
}
