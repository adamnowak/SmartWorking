﻿using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Users
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class RoleDetailsViewModel : EditableControlViewModelBase<RolePrimitive>
  {
    public RoleDetailsViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {

    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "RoleDetails"; }
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
        using (IUsersService service = ServiceFactory.GetUsersService())
        {
          //service.(Item);
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
    //  if (Contractors.Items != null && Item != null && Item.Deliverer != null)
    //  {
    //    Contractors.SelectedItem = Contractors.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
    //    Item.Deliverer = Contractors.SelectedItem;
    //  }
    //  else
    //  {
    //    Contractors.SelectedItem = null;
    //  }

    //}
  }
}