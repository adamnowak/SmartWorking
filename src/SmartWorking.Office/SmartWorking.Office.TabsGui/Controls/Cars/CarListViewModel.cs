﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  public class CarListViewModel : ListingEditableControlViewModel<CarAndDriverPackage>
  {
    public CarListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<CarAndDriverPackage> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_CarList"; }
    }

    protected override void  OnLoadItems()
    {
      CarAndDriverPackage selectedItem = Items.SelectedItem;
      using (ICarsService service = ServiceFactory.GetCarsService())
      {
        Items.LoadItems(service.GetCarAndDriverPackageList(Filter, ListItemsFilter));
      }
      if (selectedItem != null)
      {
        CarAndDriverPackage selectionFromItems =
          Items.Items.Where(x => x.Car.Id == selectedItem.Car.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();

      EditingViewModel.Item = new CarAndDriverPackage() {Car = new CarPrimitive()};
       
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      CarAndDriverPackage clone = Items.SelectedItem.GetPackageCopy();
      if (clone != null)
      {
        clone.Car.Id = 0;        
      }
      else
      {
        clone = new CarAndDriverPackage() { Car = new CarPrimitive() };
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void DeleteItemCommandExecute()
    {
      base.DeleteItemCommandExecute();
      using (ICarsService service = ServiceFactory.GetCarsService())
      {
        service.DeleteCar(EditingViewModel.Item.GetCarPrimitiveWithReference());
      }
      Refresh();
    }

    #region ShowDeactivated
    /// <summary>
    /// The <see cref="ShowDeactivated" /> property's name.
    /// </summary>
    public const string ShowDeactivatedPropertyName = "ShowDeactivated";

    private bool _showDeactivated;

    /// <summary>
    /// Gets the ShowDeactivated property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool ShowDeactivated
    {
      get
      {
        return _showDeactivated;
      }

      set
      {
        if (_showDeactivated == value)
        {
          return;
        }
        _showDeactivated = value;
        // Update bindings, no broadcast

        if (EditingViewModel.EditingMode == EditingMode.Display)
        {
          Refresh();
        }

        RaisePropertyChanged(ShowDeactivatedPropertyName);
      }
    }
    #endregion //ShowDeactivated
  }

  
}
