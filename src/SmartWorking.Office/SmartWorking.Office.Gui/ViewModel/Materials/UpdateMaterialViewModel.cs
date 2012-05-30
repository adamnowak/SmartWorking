using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View;
using SmartWorking.Office.Gui.View.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
 
  public class UpdateMaterialViewModel : ModalDialogViewModelBase
  {
    public UpdateMaterialViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    public ViewMode ViewMode { get; set; }

    #region Material property
    /// <summary>
    /// The <see cref="Contractor" /> property's name.
    /// </summary>
    public const string MaterialPropertyName = "Material";

    private Material _material;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Material Material
    {
      get
      {
        return _material;
      }

      set
      {
        if (_material == value)
        {
          return;
        }
        _material = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(MaterialPropertyName);
      }
    }
    #endregion


    private ICommand _createMaterialCommand;

    public ICommand CreateMaterialCommand
    {
      get
      {
        if (_createMaterialCommand == null)
          _createMaterialCommand = new RelayCommand(UpdateMaterial, CanCreateMaterial);
        return _createMaterialCommand;
      }
    }

    private bool CanCreateMaterial()
    {
      //TODO: validate
      return true;
    }


    private void UpdateMaterial()
    {
      if (ViewMode == ViewMode.Create || ViewMode == ViewMode.Update)
      {
        using (var materialsService = ServiceFactory.GetMaterialsService())
        {
          materialsService.UpdateMaterial(Material);
        }
      }
      CloaseModalDialog();
    }

    public override string Title
    {
      get
      {
        return (ViewMode == ViewModel.ViewMode.Create)
                 ? "Utwórz nowy materiał."
                 : "Edytuj materiał.";
      }
    }
  }
}