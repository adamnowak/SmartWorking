using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Contractors
{
  public class ContractorListViewModel : ListingEditableControlViewModel<ContractorPrimitive>
  {
    public ContractorListViewModel(IMainViewModel mainViewModel, IEditableControlViewModel<ContractorPrimitive> editingViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, editingViewModel, modalDialogService, serviceFactory)
    {
    }

    public override string Name
    {
      get { return "str_ContractorList"; }
    }

    protected override void  OnLoadItems()
    {
      ContractorPrimitive selectedItem = Items.SelectedItem;
      using (IContractorsService service = ServiceFactory.GetContractorsService())
      {
        //Items.LoadItems(service.GetContractors(Filter, ShowDeleted));
      }
      if (selectedItem != null)
      {
        ContractorPrimitive selectionFromItems =
          Items.Items.Where(x => x.Id == selectedItem.Id).FirstOrDefault();
        if (selectionFromItems != null)
          Items.SelectedItem = selectionFromItems;
      }
    }

    

    protected override void AddItemCommandExecute()
    {
      base.AddItemCommandExecute();
      EditingViewModel.Item = new ContractorPrimitive();
      EditingViewModel.EditingMode = EditingMode.New;
    }

    protected override void AddCloneItemCommandExecute()
    {
      base.AddCloneItemCommandExecute();
      ContractorPrimitive clone = Items.SelectedItem;
      if (clone != null)
      {
        clone.Id = 0;        
      }
      else
      {
        clone = new ContractorPrimitive();
      }
      EditingViewModel.Item = clone;
      EditingViewModel.EditingMode = EditingMode.New;
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
