using System;
using System.Linq;
using System.ServiceModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.Drivers
{
  /// <summary>
  /// Driver details view model implementation.
  /// </summary>
  public class DriverDetailsViewModel : EditableControlViewModelBase<DriverAndCarPackage>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DriverDetailsViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DriverDetailsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      Cars = new SelectableViewModelBase<CarPrimitive>();
    }

    #region Cars
    /// <summary>
    /// The <see cref="Cars" /> property's name.
    /// </summary>
    public const string CarsPropertyName = "Cars";

    private SelectableViewModelBase<CarPrimitive> _cars;

    /// <summary>
    /// Gets the Cars property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public SelectableViewModelBase<CarPrimitive> Cars
    {
      get
      {
        return _cars;
      }

      set
      {
        if (_cars == value)
        {
          return;
        }
        _cars = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(CarsPropertyName);
      }
    }
    #endregion //Cars

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
      Item.Car = Cars.SelectedItem;
      if (base.OnSaveItem())
      {
        using (IDriversService service = ServiceFactory.GetDriversService())
        {
          service.UpdateDriver(Item.GetDriverPrimitiveWithReference());
        }
        return true;
      }
      return false;
    }

    /// <summary>
    /// Refreshes this instance.
    /// </summary>
    public override void Refresh()
    {
      base.Refresh();
      using (ICarsService service = ServiceFactory.GetCarsService())
      {
        Cars.LoadItems(service.GetCars(string.Empty));
      }
    }

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    protected override void OnItemChanged(DriverAndCarPackage oldItem)
    {
      if (Cars != null && Cars.Items != null && Item != null && Item.Car != null)
      {
        Cars.SelectedItem = Cars.Items.Where(x => x.Id == Item.Car.Id).FirstOrDefault();
        Item.Car = Cars.SelectedItem;
      }
    }
  }
}