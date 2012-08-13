using System;
using System.Linq;
using System.Printing;
using System.ServiceModel;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;
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
  public class OrderDetailsViewModel : EditableControlViewModelBase<OrderPackage>
  {
    public OrderDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      ClientDetailsViewModel = new ClientDetailsViewModel(MainViewModel, null, ModalDialogService, ServiceFactory);
      ClientListViewModel = new ClientListViewModel(MainViewModel, ClientDetailsViewModel, ModalDialogService, ServiceFactory);

      ClientListViewModel.Items.SelectedItemChanged += new System.EventHandler<SelectedItemChangedEventArgs<ClientAndClientBuildingsPackage>>(Items_SelectedItemChanged);

      ClientBuildingDetailsViewModel = new ClientBuildingDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      ClientBuildingListViewModel = new ClientBuildingListViewModel(MainViewModel, ClientBuildingDetailsViewModel, ModalDialogService, ServiceFactory);

      RecipeDetailsViewModel = new RecipeDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      RecipeListViewModel = new RecipeListViewModel(MainViewModel, RecipeDetailsViewModel, ModalDialogService, ServiceFactory);

      DeliveryNoteDetailsViewModel = new DeliveryNoteDetailsViewModel(MainViewModel, ModalDialogService, ServiceFactory);
      DeliveryNoteListViewModel = new DeliveryNoteListViewModel(MainViewModel, DeliveryNoteDetailsViewModel, this,
                                                                ModalDialogService, ServiceFactory);


      OrderSumaryViewModel = new OrderSumaryViewModel(MainViewModel, ModalDialogService, ServiceFactory);

      DeliveryNoteDetailsViewModel.ItemSaved += new EventHandler(DeliveryNoteDetailsViewModel_ItemSaved);
    }

    void DeliveryNoteDetailsViewModel_ItemSaved(object sender, EventArgs e)
    {
      if (MainViewModel.Configuration.PagesToPrint > 0)
      {
        var t = DeliveryNoteDetailsViewModel.Item;

        PrintQueue printQueue = null;
        bool UseDefaultPrinter = true;

        if (UseDefaultPrinter)
        {
          printQueue = new LocalPrintServer().DefaultPrintQueue;
        }
        else
        {
          PrintDialog printDialog = XPSCreator.GetPrintDialog();
          printDialog.PrintTicket = printDialog.PrintQueue.DefaultPrintTicket;          
          if (printDialog == null)
            return;
          printQueue = printDialog.PrintQueue;
        }

        if (printQueue != null)
        { 
          FixedDocument fixedDocumentToPrint = (FixedDocument)XPSCreator.LoadTemplate("XPSTemplates\\DeliveryNoteTemplate.xaml");
          XPSCreator.InjectData(fixedDocumentToPrint, 
            OrderDetailsDataContextForDocument.Load(Item, (DeliveryNoteDetailsViewModel != null) ? DeliveryNoteDetailsViewModel.Item : null));
          XPSCreator.PrintFlowDocument(printQueue, fixedDocumentToPrint.DocumentPaginator);
        }

      }
    }

    public OrderSumaryViewModel OrderSumaryViewModel { get; private set; }


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

    void Items_SelectedItemChanged(object sender, SelectedItemChangedEventArgs<ClientAndClientBuildingsPackage> e)
    {
      if (e.NewValue != null)
      {
        ClientBuildingListViewModel.Items.LoadItems(e.NewValue.ClientBuildings);
      }
      else
      {
        ClientBuildingListViewModel.Items.LoadItems(null);
      }
    }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public ClientListViewModel ClientListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public ClientDetailsViewModel ClientDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public ClientBuildingListViewModel ClientBuildingListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public ClientBuildingDetailsViewModel ClientBuildingDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the driver list view model.
    /// </summary>
    public RecipeListViewModel RecipeListViewModel { get; private set; }

    /// <summary>
    /// Gets the driver details view model.
    /// </summary>
    public RecipeDetailsViewModel RecipeDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the delivery note details view model.
    /// </summary>
    public DeliveryNoteDetailsViewModel DeliveryNoteDetailsViewModel { get; private set; }

    /// <summary>
    /// Gets the delivery note list view model.
    /// </summary>
    public DeliveryNoteListViewModel DeliveryNoteListViewModel { get; private set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.OrderDetailsViewModel_Name; }
    }

    protected override void EditItemCommandExecute()
    {
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSaveItem()
    {
      Item.ClientBuildingPackage = ClientBuildingDetailsViewModel.Item;
      if (RecipeDetailsViewModel.Item != null)
      {
        Item.Recipe = RecipeDetailsViewModel.Item.Recipe;
      }
      if (base.OnSaveItem())
      {
        using (IOrdersService service = ServiceFactory.GetOrdersService())
        {
          service.CreateOrUpdateOrder(Item.GetOrderPrimitiveWithReference());
        }
        return true;
      }
      return false;
    }

    protected override bool OnRefresh()
    {
      //ClientDetailsViewModel.Refresh();
      ClientListViewModel.Refresh();
      
      //BuildingDetailsViewModel.Refresh();
      //BuildingListViewModel.Refresh();
      
      //RecipeDetailsViewModel.Refresh();
      RecipeListViewModel.Refresh();

      DeliveryNoteDetailsViewModel.Refresh();
      
      return base.OnRefresh(); 
    }

  

    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    protected override void OnItemChanged(OrderPackage oldItem)
    {

      ClientListViewModel.Items.SelectedItem = null;
      ClientBuildingListViewModel.Items.SelectedItem = null;
      RecipeListViewModel.Items.SelectedItem = null;
      DeliveryNoteListViewModel.Items.SelectedItem = null;

      if (Item != null)
      {
        if (Item.Client != null)
        {
          ClientListViewModel.Items.SelectedItem = ClientListViewModel.Items.Items.Where(x => x.Client.Id == Item.Client.Id).FirstOrDefault();
        }

        if (Item.ClientBuildingPackage != null && Item.ClientBuildingPackage.ClientBuilding != null)
        {
          ClientBuildingListViewModel.Items.SelectedItem = ClientBuildingListViewModel.Items.Items.Where(x => x.ClientBuilding.Id == Item.ClientBuildingPackage.ClientBuilding.Id).FirstOrDefault();
        }

        if (Item.Recipe != null)
        {
          RecipeListViewModel.Items.SelectedItem = RecipeListViewModel.Items.Items.Where(x => x.Recipe.Id == Item.Recipe.Id).FirstOrDefault();
        }

        if (Item.DeliveryNotePackageList != null)
        {
          DeliveryNoteListViewModel.Items.LoadItems(Item.DeliveryNotePackageList);
        }

        
      }

      OrderSumaryViewModel.Item = Item;
      

      

      //if (Producers.Items != null && Item != null && Item.Deliverer != null)
      //{
      //  Producers.SelectedItem = Producers.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
      //  Item.Deliverer = Producers.SelectedItem;
      //}
      //else
      //{
      //  Producers.SelectedItem = null;
      //}

    }



    #region PreviewDeliveryNoteItemCommand
    private ICommand _previewDeliveryNoteItemCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand PreviewDeliveryNoteItemCommand
    {
      get
      {
        if (_previewDeliveryNoteItemCommand == null)
          _previewDeliveryNoteItemCommand = new RelayCommand(PreviewDeliveryNoteItem, CanPreviewDeliveryNoteItem);
        return _previewDeliveryNoteItemCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanPreviewDeliveryNoteItem()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void PreviewDeliveryNoteItem()
    {
      string errorCaption = "TODO!";
      try
      {
        
        SetDocumentPaginatorSource();
        IsDeliveryNotePreview = true;
        
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
    public class Test
    {
      public ImageSource BackImage { get; set; }
    }
    private void SetDocumentPaginatorSource()
    {
      if (DocumentPaginatorSource == null)
      {
        DocumentPaginatorSource = (FixedDocument)XPSCreator.LoadTemplate("XPSTemplates\\DeliveryNotePreviewTemplate.xaml");
      }

      XPSCreator.InjectData(DocumentPaginatorSource, 
        OrderDetailsDataContextForDocument.Load(Item, (DeliveryNoteDetailsViewModel != null) ? DeliveryNoteDetailsViewModel.Item : null));
    }

    

    #endregion //PreviewDeliveryNoteItemCommand

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
  }
}