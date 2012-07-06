using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.Orders;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Orders
{
  /// <summary>
  ///  View model for <see cref="ManageOrders"/> dialog. 
  /// </summary>
  public class ManageOrdersViewModel : ModalDialogViewModelBase
  {
    private ICommand _cancelOrderCommand;
    private ICommand _createOrderCommand;
    private ICommand _printOrderCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageOrdersViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ManageOrdersViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      SelectableOrder = new SelectableViewModelBase<OrderPackage>();
      ShowCanceledOrders = true;
      LoadOrders(string.Empty, ShowCanceledOrders);
    }

    #region ShowCanceledOrders

    /// <summary>
    /// The <see cref="ShowCanceledOrders" /> property's name.
    /// </summary>
    public const string ShowCanceledOrdersPropertyName = "ShowCanceledOrders";

    private bool _showCanceledOrders;


    /// <summary>
    /// Gets the ShowCanceledOrders property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool ShowCanceledOrders
    {
      get { return _showCanceledOrders; }

      set
      {
        if (_showCanceledOrders == value)
        {
          return;
        }
        _showCanceledOrders = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(ShowCanceledOrdersPropertyName);
      }
    }

    #endregion

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the selectable car.
    /// </summary>
    public SelectableViewModelBase<OrderPackage> SelectableOrder { get; private set; }


    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get { return "Wybierz zamówienie."; }
    }

    #region CancelOrderCommand

    public ICommand CancelOrderCommand
    {
      get
      {
        if (_cancelOrderCommand == null)
          _cancelOrderCommand = new RelayCommand(CancelOrder, CanCancelOrder);
        return _cancelOrderCommand;
      }
    }

    private void CancelOrder()
    {
      string errorCaption = "Anulowanie zamówienia!";
      try
      {
        using (IOrdersService ordersService = ServiceFactory.GetOrdersService())
        {
          ordersService.CanceledOrder(SelectableOrder.SelectedItem.Order);
        }
        LoadOrders(string.Empty, ShowCanceledOrders);
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

    private bool CanCancelOrder()
    {
      return SelectableOrder.SelectedItem != null && SelectableOrder.SelectedItem.Order != null;
    }

    #endregion

    #region CreateOrderCommand

    /// <summary>
    /// Gets the create delivery note command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to creating delivery note.
    /// </remarks>
    public ICommand CreateOrderCommand
    {
      get
      {
        if (_createOrderCommand == null)
          _createOrderCommand = new RelayCommand(CreateOrder);
        return _createOrderCommand;
      }
    }

    /// <summary>
    /// Execution of <see cref="CreateOrderCommand"/>.
    /// </summary>
    private void CreateOrder()
    {
      string errorCaption = "Tworzenie zamówienia!";
      try
      {
        ModalDialogService.CreateOrder(ModalDialogService, ServiceFactory);
        LoadOrders(string.Empty, ShowCanceledOrders);
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

    #endregion

    /// <summary>
    /// Loads the delivery notes.
    /// </summary>
    /// <param name="buildingContains">Used to filtering result. Loaded <see cref="Order"/> object will contain this string.</param>
    /// <param name="showDeactivedOrders">if set to <c>true</c> then loaded <see cref="Order"/> object  will contain <see cref="Order"/> which are deactivated; otherwise not.</param>    
    /// <remarks>
    /// Loaded items will be in <see cref="SelectableOrder"/> object in Items property.
    /// </remarks>
    private void LoadOrders(string buildingContains, bool showDeactivedOrders)
    {
      string errorCaption = "Wczytywanie danych o zamówieniach!";
      try
      {
        OrderPackage selectedItem = SelectableOrder.SelectedItem;
        using (IOrdersService service = ServiceFactory.GetOrdersService())
        {
          SelectableOrder.LoadItems(service.GetOrderPackageList(buildingContains, showDeactivedOrders));
        }
        if (selectedItem != null)
        {
          OrderPackage selectionFromItems =
            SelectableOrder.Items.Where(x => x.Order.Id == selectedItem.Order.Id).FirstOrDefault();
          if (selectionFromItems != null)
            SelectableOrder.SelectedItem = selectionFromItems;
        }
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
  }
}