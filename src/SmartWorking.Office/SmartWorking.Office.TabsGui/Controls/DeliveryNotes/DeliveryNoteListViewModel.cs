﻿using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.DeliveryNotes
{
  public class DeliveryNoteListViewModel : ListingEditableControlViewModel<DeliveryNotePackage>
  {
    public DeliveryNoteListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<DeliveryNotePackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_DeliveryNoteList"; }
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

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new DeliveryNotePackage() { DeliveryNote = new DeliveryNotePrimitive() };      
      EditingViewModel.EditingMode = EditingMode.New;
      EditingMode = EditingMode.Display;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      DeliveryNotePackage clone = Items.SelectedItem.GetPackageCopy();
      if (clone != null)
      {
        clone.DeliveryNote.Id = 0;        
      }
      else
      {
        clone = new DeliveryNotePackage() { DeliveryNote = new DeliveryNotePrimitive() };
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
  }

  
}
