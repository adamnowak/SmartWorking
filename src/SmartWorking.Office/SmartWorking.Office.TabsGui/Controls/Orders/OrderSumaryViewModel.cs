using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Buildings;
using SmartWorking.Office.TabsGui.Controls.Clients;
using SmartWorking.Office.TabsGui.Controls.DeliveryNotes;
using SmartWorking.Office.TabsGui.Controls.Recipes;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Orders
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class OrderSumaryViewModel : EditableControlViewModelBase<OrderPackage>
  {
    public OrderSumaryViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.OrderDetailsViewModel_Name; }
    }


    #region AmountDelivered
    /// <summary>
    /// The <see cref="AmountDelivered" /> property's name.
    /// </summary>
    public const string AmountDeliveredPropertyName = "AmountDelivered";

    private double _amountDelivered;

    /// <summary>
    /// Gets the AmountDelivered property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public double AmountDelivered
    {
        get
        {
            return _amountDelivered;
        }

        set
        {
            if (_amountDelivered == value)
            {
                return;
            }
            _amountDelivered = value;
            // Update bindings, no broadcast
            RaisePropertyChanged(AmountDeliveredPropertyName);
        }
    }
    #endregion //AmountDelivered

    #region RemainToDeliver
    /// <summary>
    /// The <see cref="RemainToDeliver" /> property's name.
    /// </summary>
    public const string RemainToDeliverPropertyName = "RemainToDeliver";

    private double _RemainToDeliver;

    /// <summary>
    /// Gets the RemainToDeliver property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public double RemainToDeliver
    {
      get
      {
        return _RemainToDeliver;
      }

      set
      {
        if (_RemainToDeliver == value)
        {
          return;
        }
        _RemainToDeliver = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(RemainToDeliverPropertyName);
      }
    }
    #endregion //RemainToDeliver

    double CalculateAmountDeliver(ICollection<DeliveryNotePackage> deliveryNotePackageList)
    {
      double result = 0;
      if (deliveryNotePackageList != null)
      {
        foreach (DeliveryNotePackage deliveryNotePackage in deliveryNotePackageList)
        {
          if (deliveryNotePackage != null && deliveryNotePackage.DeliveryNote != null &&
              deliveryNotePackage.DeliveryNote.Amount.HasValue)
          {
            result += deliveryNotePackage.DeliveryNote.Amount.Value;
          }
        }
      }
      return result;
    }

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    protected override void OnItemChanged(OrderPackage oldItem)
    {
      if (Item != null)
      {
        AmountDelivered = CalculateAmountDeliver(Item.DeliveryNotePackageList);
        if (Item.Order != null && Item.Order.Amount.HasValue)
        {
          RemainToDeliver = Item.Order.Amount.Value - AmountDelivered;
        }
      }
      else
      {
        AmountDelivered = 0;
        RemainToDeliver = 0;
      }
          

    }
  }

}