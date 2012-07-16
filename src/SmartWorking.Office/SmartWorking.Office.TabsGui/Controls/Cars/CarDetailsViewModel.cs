using System;
using System.ServiceModel;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;

namespace SmartWorking.Office.TabsGui.Controls.Cars
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class CarDetailsViewModel : EditableControlViewModelBase<CarPrimitive>
  {
    public CarDetailsViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    { 
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "str_CarDetails"; }
    }

    public override void Refresh()
    {
      
    }

    

    protected override void EditItemCommandExecute()
    {
      base.EditItemCommandExecute();
      EditingMode = Shared.ViewModel.EditingMode.Edit;
    }
  }
}