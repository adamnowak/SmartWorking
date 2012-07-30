using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.Materials
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class MaterialDetailsViewModel : EditableControlViewModelBase<MaterialAndContractorsPackage>
  {
    public MaterialDetailsViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      Deliverers = new SelectableViewModelBase<ContractorPrimitive>();
      Producers = new SelectableViewModelBase<ContractorPrimitive>();
    }

    public SelectableViewModelBase<ContractorPrimitive> Deliverers { get; private set; }
    public SelectableViewModelBase<ContractorPrimitive> Producers { get; private set; }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return Resources.MaterialDetailsViewModel_Name; }
    }

    protected override void EditItemCommandExecute()
    {
      LoadContractors();
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSaveItem()
    {
      if (Item != null)
      {
        Item.Producer = Producers.SelectedItem;
        Item.Deliverer = Deliverers.SelectedItem;
        if (base.OnSaveItem())
        {
          using (IMaterialsService service = ServiceFactory.GetMaterialsService())
          {
            service.CreateOrUpdateMaterial(Item.GetMaterialPrimitiveWithReference());
          }
          return true;
        }
      }
      return false;
    }



    protected override bool OnRefresh()
    {
      LoadContractors();
      return base.OnRefresh();
    }

    private void LoadContractors()
    {
      using (IContractorsService service = ServiceFactory.GetContractorsService())
      {
        List<ContractorPrimitive> contractors = service.GetContractors(string.Empty, ListItemsFilterValues.OnlyActive);
        //TODO:
        ContractorPrimitive selectedProducer = Producers.SelectedItem;
        Producers.LoadItems(contractors);
        if (selectedProducer != null)
        {
          Producers.SelectedItem = Producers.Items.Where(x => x.Id == selectedProducer.Id).FirstOrDefault();
        }
        else
        {
          Producers.SelectedItem = null;
        }

        ContractorPrimitive selectedDeliverer = Deliverers.SelectedItem;
        Deliverers.LoadItems(contractors);
        if (selectedDeliverer != null)
        {
          Deliverers.SelectedItem = Deliverers.Items.Where(x => x.Id == selectedDeliverer.Id).FirstOrDefault();
        }
        else
        {
          Deliverers.SelectedItem = null;
        }
        
      }
    }

     //<summary>
     //Called when [item changed].
     //</summary>
     //<param name="oldItem">The old item.</param>
    protected override void OnItemChanged(MaterialAndContractorsPackage oldItem)
    {
      if (Item != null)
      {
        if (Producers.Items != null && Item.Producer != null)
        {
          Producers.SelectedItem = Producers.Items.Where(x => x.Id == Item.Producer.Id).FirstOrDefault();
          Item.Producer = Producers.SelectedItem;
        }
        else
        {
          Producers.SelectedItem = null;
        }

        if (Deliverers.Items != null && Item.Deliverer != null)
        {
          Deliverers.SelectedItem = Deliverers.Items.Where(x => x.Id == Item.Deliverer.Id).FirstOrDefault();
          Item.Deliverer = Deliverers.SelectedItem;
        }
        else
        {
          Deliverers.SelectedItem = null;
        } 
      }
      else
      {
        Producers.SelectedItem = null;
        Deliverers.SelectedItem = null;
      }
      

    }
  }
}