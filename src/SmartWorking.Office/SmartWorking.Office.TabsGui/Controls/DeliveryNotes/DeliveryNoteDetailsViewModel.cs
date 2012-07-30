using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.DeliveryNotes
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class DeliveryNoteDetailsViewModel : EditableControlViewModelBase<DeliveryNotePackage>
  {
    public DeliveryNoteDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      Cars = new SelectableViewModelBase<CarAndDriverPackage>();
      Drivers = new SelectableViewModelBase<DriverPrimitive>();
    }

    public SelectableViewModelBase<CarAndDriverPackage> Cars { get; private set; }
    public SelectableViewModelBase<DriverPrimitive> Drivers { get; private set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.DeliveryNoteDetailsViewModel_Name; }
    }

    protected override void EditItemCommandExecute()
    {
      LoadCars();
      LoadDrivers();
      //Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSaveItem()
    {
      if (Item != null)
      {
        if (base.OnSaveItem())
        {          
          Item.CarAndDriver = Cars.SelectedItem;
          Item.Driver = Drivers.SelectedItem;
          Item.DeliveryNote.DateDrawing = DateTime.Now;
          
          using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
          {
            service.CreateOrUpdateDeliveryNote(Item.GetDeliveryNotePrimitiveWithReference());
          }
          return true;
        }
      }
      return false;
    }

    

    protected override bool OnRefresh()
    {
      LoadCars();
      LoadDrivers();
      return base.OnRefresh(); 
    }

    private void LoadDrivers()
    {
      using (IDriversService service = ServiceFactory.GetDriversService())
      {
        List<DriverPrimitive> drivers = service.GetDrivers(string.Empty, ListItemsFilterValues.OnlyActive);
        Drivers.LoadItems(drivers);
      }
    }

    private void LoadCars()
    {
      using (ICarsService service = ServiceFactory.GetCarsService())
      {
        List<CarAndDriverPackage> cars = service.GetCarAndDriverPackageList(string.Empty, ListItemsFilterValues.OnlyActive);
        Cars.LoadItems(cars);
      }
    }

     //<summary>
     //Called when [item changed].
     //</summary>
     //<param name="oldItem">The old item.</param>
    protected override void OnItemChanged(DeliveryNotePackage oldItem)
    {
      //if (Item != null)
      //{
      //  if (Producers.Items != null && Item.Producer != null)
      //  {
      //    Producers.SelectedItem = Producers.Items.Where(x => x.Id == Item.Producer.Id).FirstOrDefault();
      //    Item.Producer = Producers.SelectedItem;
      //  }
      //  else
      //  {
      //    Producers.SelectedItem = null;
      //  }

      //  if (Deliverers.Items != null && Item.Deliverer != null)
      //  {
      //    Deliverers.SelectedItem = Deliverers.Items.Where(x => x.Id == Item.Deliverer.Id).FirstOrDefault();
      //    Item.Deliverer = Deliverers.SelectedItem;
      //  }
      //  else
      //  {
      //    Deliverers.SelectedItem = null;
      //  } 
      //}
      //else
      //{
      //  Producers.SelectedItem = null;
      //  Deliverers.SelectedItem = null;
      //}
      

    }
  }
}