using System;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.DeliveryNotes
{
  public class DeliveryNoteListViewModel : ListingEditableControlViewModel<DeliveryNotePackage>
  {
    public IEditableControlViewModel<OrderPackage> OrderDetailsControlViewModel { get; private set; }

    public DeliveryNoteListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<DeliveryNotePackage> editingViewModel, IEditableControlViewModel<OrderPackage> orderDetailsControlViewModel,
      IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
      OrderDetailsControlViewModel = orderDetailsControlViewModel;
      if (EditingViewModel != null)
      {
        EditingViewModel.ItemSaved += new System.EventHandler(EditingViewModel_ItemSaved);
      }
    }

    void EditingViewModel_ItemSaved(object sender, System.EventArgs e)
    {
      if (EditingViewModel.Item  != null)
      {
        
      }
    }

    public override string Name
    {
      get { return Resources.DeliveryNoteListViewModel_Name; }
    }

    protected override void  OnLoadItems()
    {
      DeliveryNotePackage selectedItem = Items.SelectedItem;
      using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
      {
        Items.LoadItems(service.GetDeliveryNotePackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null && selectedItem.DeliveryNote != null)
      {
        DeliveryNotePackage selectionFromItems =
          Items.Items.Where(x => x.DeliveryNote.Id == selectedItem.DeliveryNote.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    protected override void OnAddItem()
    {
      using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
      {
        NextDeliveryNoteNumber = service.GetNextDeliveryNumber();
      }
      base.OnAddItem();
      EditingViewModel.Item = new DeliveryNotePackage()
                                {
                                  DeliveryNote = new DeliveryNotePrimitive() { Number = NextDeliveryNoteNumber, Year = DateTime.Now.Year },
                                  Order =
                                    (OrderDetailsControlViewModel != null && OrderDetailsControlViewModel.Item != null)
                                      ? OrderDetailsControlViewModel.Item.Order
                                      : null 
                                };      
      EditingViewModel.EditingMode = EditingMode.New;
      EditingMode = EditingMode.Display;
    }

    protected override void OnAddCloneItem()
    {
      using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
      {
        NextDeliveryNoteNumber = service.GetNextDeliveryNumber();
      }
      base.OnAddCloneItem();
      DeliveryNotePackage clone = Items.SelectedItem.GetPackageCopy();
      if (clone != null)
      {
        clone.DeliveryNote.Id = 0;        
      }
      else
      {
        clone = new DeliveryNotePackage()
        {
          DeliveryNote = new DeliveryNotePrimitive() { Number = NextDeliveryNoteNumber, Year = DateTime.Now.Year },
          Order =
            (OrderDetailsControlViewModel != null && OrderDetailsControlViewModel.Item != null)
              ? OrderDetailsControlViewModel.Item.Order
              : null
        };     
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override bool OnItemDeletedFlagChanged()
    { 
      if (base.OnItemDeletedFlagChanged())
      {
        using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
        {
          service.CanceledDeliveryNote(EditingViewModel.Item.DeliveryNote);
        }
        Refresh();
        return true;
      }
      return false;
      
    }

    protected override bool OnRefresh()
    {
      if (base.OnRefresh())
      {
        
        return true;
      }
      return false;
    }

    protected int NextDeliveryNoteNumber
    {
      get; private set;
    }
  }

  
}
