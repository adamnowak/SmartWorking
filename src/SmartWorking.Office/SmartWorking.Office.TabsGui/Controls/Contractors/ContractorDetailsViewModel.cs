﻿using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Contractors
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class ContractorDetailsViewModel : EditableControlViewModelBase<ContractorPrimitive>
  {
    public ContractorDetailsViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.ContractorDetailsViewModel_Name; }
    }

    protected override void EditItemCommandExecute()
    {
      Item = Item.GetPrimitiveCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSavingItem()
    {
      if (base.OnSavingItem())
      {
        using (IContractorsService service = ServiceFactory.GetContractorsService())
        {
          service.CreateOrUpdateContractor(Item);
        }
        return true;
      }
      return false;
    }





    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    //protected override void OnItemChanged(CarAndDriverPackage oldItem)
    //{
    //  if (Producers.Items != null && Item != null && Item.Deliverer != null)
    //  {
    //    Producers.SelectedItem = Producers.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
    //    Item.Deliverer = Producers.SelectedItem;
    //  }
    //  else
    //  {
    //    Producers.SelectedItem = null;
    //  }

    //}
  }
}