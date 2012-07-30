using System;
using System.Linq;
using System.ServiceModel;
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
      }
      if (selectedItem != null)
      {
        OrderPackage selectionFromItems =
          Items.Items.Where(x => x.Order.Id == selectedItem.Order.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
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
      return true;
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

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new OrderPackage() {Order = new OrderPrimitive()};
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
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
          service.CanceledOrder(EditingViewModel.Item.Order);
        }
        Refresh();
        return true;
      }
      return false;
    }

  }
}
