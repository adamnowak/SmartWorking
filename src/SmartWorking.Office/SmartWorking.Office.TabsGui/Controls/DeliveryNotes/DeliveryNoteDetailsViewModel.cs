using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.MetaDates;
using SmartWorking.Office.PrimitiveEntities.Packages;
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
    public DeliveryNoteDetailsViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      Cars = new SelectableViewModelBase<CarAndDriverPackage>();
      Drivers = new SelectableViewModelBase<DriverPrimitive>();
      Cars.SelectedItemChanged += new EventHandler<SelectedItemChangedEventArgs<CarAndDriverPackage>>(Cars_SelectedItemChanged);
    }

    void Cars_SelectedItemChanged(object sender, SelectedItemChangedEventArgs<CarAndDriverPackage> e)
    {
      if (//Drivers.SelectedItem == null && 
        !IsReadOnly && Cars.SelectedItem != null && Cars.SelectedItem.Driver != null)
      {
        Drivers.SelectedItem = Drivers.Items.Where(x => x.Id == Cars.SelectedItem.Driver.Id).FirstOrDefault();
      }
      
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

    public override void BeforeSavingItem()
    {
      if (Item != null)
      {
        Item.CarAndDriver = Cars.SelectedItem;
        Item.Driver = Drivers.SelectedItem;
        Item.DeliveryNote.DateDrawing = DateTime.Now;
      }
    }

    public override void Validate()
    {
      base.Validate();
      Errors = Item.DeliveryNote.ValidateClientSide();
    }

    protected override bool OnSavingItem()
    {
      if (Item != null)
      {
        if (base.OnSavingItem())
        {
          using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
          {
            Item.DeliveryNote = service.CreateOrUpdateDeliveryNote(Item.GetDeliveryNotePrimitiveWithReference());
          }
        }        
        return true;
      }
      return false;
    }

    protected override void OnSavedItem()
    {
      if (MainViewModel.Configuration.PagesToPrint <= 0)
      {
        base.OnSavedItem();
      }
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
      Drivers.SelectedItem = null;
    }

    private void LoadCars()
    {
      using (ICarsService service = ServiceFactory.GetCarsService())
      {
        List<CarAndDriverPackage> cars = service.GetCarAndDriverPackageList(string.Empty, ListItemsFilterValues.OnlyActive);
        Cars.LoadItems(cars);
      }
      Cars.SelectedItem = null;
    }

     //<summary>
     //Called when [item changed].
     //</summary>
     //<param name="oldItem">The old item.</param>
    protected override void OnItemChanged(DeliveryNotePackage oldItem)
    {
      if (Item != null)
      {
        if (Cars.Items != null && Item.CarAndDriver != null && Item.CarAndDriver.Car != null)
        {
          Cars.SelectedItem = Cars.Items.Where(x => x.Car.Id == Item.CarAndDriver.Car.Id).FirstOrDefault();
          
        }
        else
        {
          Cars.SelectedItem = null;
        }

        if (Drivers.Items != null && Item.Driver != null )
        {
          Drivers.SelectedItem = Drivers.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
          //Item.Deliverer = Deliverers.SelectedItem;
        }
        else
        {
          Drivers.SelectedItem = null;
        }
      }
      else
      {
        Cars.SelectedItem = null;
        Drivers.SelectedItem = null;
      }
      

    }

    #region PrintItemCommand
    private ICommand _printItemCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand PrintItemCommand
    {
      get
      {
        if (_printItemCommand == null)
          _printItemCommand = new RelayCommand(PrintItem, CanPrintItem);
        return _printItemCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanPrintItem()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void PrintItem()
    {
      string errorCaption = "TODO!";
      try
      {
        //Special for delivery note (avoids saving during next printing).
        if (Item.DeliveryNote != null && Item.DeliveryNote.Id <= 0)
        {
          Save();
        }
        if (ItemReadyToPrint != null)
        {
          ItemReadyToPrint(this, EventArgs.Empty);
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

    /// <summary>
    /// Occurs when item is ready to print.
    /// </summary>
    public event EventHandler ItemReadyToPrint;
    #endregion //PrintItemCommand

    #region CancelPringintItemCommand
    private ICommand _cancelPringintItemCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand CancelPringintItemCommand
    {
      get
      {
        if (_cancelPringintItemCommand == null)
          _cancelPringintItemCommand = new RelayCommand(CancelPringintItem, CanCancelPringintItem);
        return _cancelPringintItemCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanCancelPringintItem()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void CancelPringintItem()
    {
      string errorCaption = "TODO!";
      try
      {        
        if (ItemFinishedPrinting != null)
        {
          ItemFinishedPrinting(this, EventArgs.Empty);
        }
        base.OnSavedItem();
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
    /// <summary>
    /// Occurs when printing is finished.
    /// </summary>
    public event EventHandler ItemFinishedPrinting;
    #endregion //CancelPringintItemCommand
  }
}