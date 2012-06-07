using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.ViewModel.Contractors;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Cars
{
  public class UpdateCarViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateMaterialCommand;

    public UpdateCarViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    public DialogMode ViewMode { get; set; }

    public ICommand CreateOrUpdateMaterialCommand
    {
      get
      {
        if (_createOrUpdateMaterialCommand == null)
          _createOrUpdateMaterialCommand = new RelayCommand(UpdateMaterial, CanUpdateMaterial);
        return _createOrUpdateMaterialCommand;
      }
    }

    public override string Title
    {
      get
      {
        return (ViewMode == DialogMode.Create)
                 ? "Utwórz nowy materiał."
                 : "Edytuj materiał.";
      }
    }

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
      get { return _material; }

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

    private bool CanUpdateMaterial()
    {
      //TODO: validate
      return true;
    }


    private void UpdateMaterial()
    {
      if (ViewMode == DialogMode.Create || ViewMode == DialogMode.Update)
      {
        using (IMaterialsService materialsService = ServiceFactory.GetMaterialsService())
        {
          materialsService.UpdateMaterial(Material);
        }
      }
      CloseModalDialog();
    }
  }
}