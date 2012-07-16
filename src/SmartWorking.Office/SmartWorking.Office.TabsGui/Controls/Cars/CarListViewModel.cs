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

    public override void Refresh()
    {
      LoadItems();
    }

    public override string Name
    {
      get { return "str_CarList"; }
    }

    private void LoadItems()
    {
      string errorCaption = Name;
      try
      {
        CarPrimitive selectedItem = Items.SelectedItem;
        using (ICarsService service = ServiceFactory.GetCarsService())
        {
          Items.LoadItems(service.GetCars(string.Empty));
        }
        if (selectedItem != null)
        {
          CarPrimitive selectionFromItems =
            Items.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
          if (selectionFromItems != null)
            Items.SelectedItem = selectionFromItems;
        }
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);

      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);

      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
      }
    }

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new CarPrimitive();
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      CarPrimitive clone = Items.SelectedItem.GetPrimitiveCopy();
      clone.Id = 0;
      EditingViewModel.Item = clone;
    }
  }

  
}
