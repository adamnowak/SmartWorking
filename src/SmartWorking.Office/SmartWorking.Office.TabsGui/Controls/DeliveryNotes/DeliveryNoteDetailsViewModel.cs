using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
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

    #region IsDeliveryNotePreview
    /// <summary>
    /// The <see cref="IsDeliveryNotePreview" /> property's name.
    /// </summary>
    public const string IsDeliveryNotePreviewPropertyName = "IsDeliveryNotePreview";

    private bool _isDeliveryNotePreview = false;

    /// <summary>
    /// Gets the IsDeliveryNotePreview property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool IsDeliveryNotePreview
    {
      get
      {
        return _isDeliveryNotePreview;
      }

      set
      {
        if (_isDeliveryNotePreview == value)
        {
          return;
        }
        _isDeliveryNotePreview = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(IsDeliveryNotePreviewPropertyName);
      }
    }
    #endregion //IsDeliveryNotePreview

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
        if (SmartWorkingConfiguration.Instance.PreviewDeliveryNote)
        {
          SetDocumentPaginatorSource();
          IsDeliveryNotePreview = true;
        }
        else
        {
          SaveDeliveryNote();  
        }
        
        return true;
      }
      return false;
    }

    private void SetDocumentPaginatorSource()
    {
      if (DocumentPaginatorSource == null)
      {
        DocumentPaginatorSource = (FixedDocument)XPSCreator.LoadTemplate("XPSTemplates\\DeliveryNoteTemplate.xaml");
      }
      XPSCreator.InjectData(DocumentPaginatorSource, Item);
    }

    private void SaveDeliveryNote()
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
      }
    }

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
        IsDeliveryNotePreview = false;
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
    #endregion //CancelPringintItemCommand
    

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

    #region DocumentPaginatorSource
    /// <summary>
    /// The <see cref="DocumentPaginatorSource" /> property's name.
    /// </summary>
    public const string DocumentPaginatorSourcePropertyName = "DocumentPaginatorSource";

    private FixedDocument _documentPaginatorSource;

    /// <summary>
    /// Gets the DocumentPaginatorSource property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public FixedDocument DocumentPaginatorSource
    {
      get
      {
        return _documentPaginatorSource;
      }

      set
      {
        if (_documentPaginatorSource == value)
        {
          return;
        }
        _documentPaginatorSource = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(DocumentPaginatorSourcePropertyName);
      }
    }
    #endregion //DocumentPaginatorSource
  }
}