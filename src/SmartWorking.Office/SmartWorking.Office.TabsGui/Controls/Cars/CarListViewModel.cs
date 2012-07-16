using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  public class CarListViewModel : ListingEditableControlViewModel<CarPrimitive>
  {
    public CarListViewModel(IEditableControlViewModel<CarPrimitive> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_CarList"; }
    }

    protected override void  OnLoadItems()
    {      
      CarPrimitive selectedItem = Items.SelectedItem;
      using (ICarsService service = ServiceFactory.GetCarsService())
      {
        Items.LoadItems(service.GetCars(Filter));
      }
      if (selectedItem != null)
      {
        CarPrimitive selectionFromItems =
          Items.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new CarPrimitive();
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      CarPrimitive clone = Items.SelectedItem.GetPrimitiveCopy();
      if (clone != null)
      {
        clone.Id = 0;        
      }
      else
      {
        clone = new CarPrimitive();
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }
  }

  
}
