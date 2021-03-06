﻿using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View.Orders;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Orders
{
  /// <summary>
  ///  View model for <see cref="UpdateOrder"/> dialog. 
  /// </summary>
  public class UpdateOrderViewModel : ModalDialogViewModelBase
  {
    private ICommand _createAndPrintOrderCommand;
    private ICommand _selectBuildingCommand;
    private ICommand _selectRecipeCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrderViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateOrderViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nową WZ'tkę."
                 : "Edytuj WZ'tkę.";
      }
    }

    #region OrderPackage property

    /// <summary>
    /// The <see cref="OrderPackage" /> property's name.
    /// </summary>
    public const string OrderPropertyName = "OrderPackage";

    private OrderPackage _orderPackage;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public OrderPackage OrderPackage
    {
      get
      {
        if (_orderPackage == null)
        {
          _orderPackage = new OrderPackage();
        }
        return _orderPackage;
      }

      set
      {
        if (_orderPackage == value)
        {
          return;
        }
        _orderPackage = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(OrderPropertyName);
      }
    }

    #endregion

    #region SelectBuildingCommand

    /// <summary>
    /// Gets the select building command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to selecting building.
    /// </remarks>
    public ICommand SelectBuildingCommand
    {
      get
      {
        if (_selectBuildingCommand == null)
          _selectBuildingCommand = new RelayCommand(SelectBuilding);
        return _selectBuildingCommand;
      }
    }

    private void SelectBuilding()
    {
      string errorCaption = "Wybieranie WZ'tki!";
      try
      {
        OrderPackage.ClientBuildingPackage =
          ModalDialogService.SelectBuildingAndContractorPackage(ModalDialogService, ServiceFactory);
        RaisePropertyChanged("OrderPackage");
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

    #region SelectRecipeCommand

    public ICommand SelectRecipeCommand
    {
      get
      {
        if (_selectRecipeCommand == null)
          _selectRecipeCommand = new RelayCommand(SelectRecipe);
        return _selectRecipeCommand;
      }
    }

    private void SelectRecipe()
    {
      string errorCaption = "Wybieranie recepty!";
      try
      {
        OrderPackage.Recipe = ModalDialogService.SelectRecipe(ModalDialogService, ServiceFactory);
        RaisePropertyChanged("OrderPackage");
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

    #region CreateAndPrintOrderCommand

    public ICommand CreateAndPrintOrderCommand
    {
      get
      {
        if (_createAndPrintOrderCommand == null)
          _createAndPrintOrderCommand = new RelayCommand(CreateAndPrintOrder,
                                                                CanCreateAndPrintOrder);
        return _createAndPrintOrderCommand;
      }
    }

    private bool CanCreateAndPrintOrder()
    {
      return OrderPackage.ClientBuildingPackage != null &&
             OrderPackage.ClientBuildingPackage.Building != null &&
             OrderPackage.ClientBuildingPackage.Client != null &&
             OrderPackage.Recipe != null;
    }

    private void CreateAndPrintOrder()
    {
      string errorCaption = "Zatwierdzanie i drukowanie WZ'tki!";
      try
      {
        if (OrderPackage == null)
        {
          throw new SmartWorkingException("OrderPackage is not initialized.");
        }
        if (OrderPackage.ClientBuildingPackage == null)
        {
          throw new SmartWorkingException("Building and contractor is not defined.");
        }
        if (OrderPackage.Recipe == null)
        {
          throw new SmartWorkingException("Recipe is not defined.");
        }


        using (IOrdersService service = ServiceFactory.GetOrdersService())
        {
          int orderId = service.UpdateOrder(OrderPackage.GetOrderPrimitiveWithReference());
          OrderPackage.Order.Id = orderId;
        }

       
        CloseModalDialog();
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
  }
}