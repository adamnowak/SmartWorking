using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  /// <summary>
  /// View model for <see cref="UpdateMaterial"/> dialog. 
  /// </summary>
  public class UpdateMaterialViewModel : ModalDialogViewModelBase
  {
    private ICommand _createOrUpdateMaterialCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateMaterialViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateMaterialViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the create or update material command.
    /// </summary>
    /// <remarks>
    /// Opens dialog for creating or editing Material.
    /// </remarks>
    public ICommand CreateOrUpdateMaterialCommand
    {
      get
      {
        if (_createOrUpdateMaterialCommand == null)
          _createOrUpdateMaterialCommand = new RelayCommand(UpdateMaterial, CanUpdateMaterial);
        return _createOrUpdateMaterialCommand;
      }
    }

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nowy materiał."
                 : "Edytuj materiał.";
      }
    }

    #region Material

    /// <summary>
    /// The <see cref="Material" /> property's name.
    /// </summary>
    public const string MaterialPropertyName = "Material";

    private Material _material;

    /// <summary>
    /// Gets the Material property.
    /// Material which will be created or updated.
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

    /// <summary>
    /// Determines whether <see cref="CreateOrUpdateMaterialCommand"/> can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="CreateOrUpdateMaterialCommand"/> can be execute; otherwise, <c>false</c>.
    /// </returns>
    private bool CanUpdateMaterial()
    {
      //TODO: validate
      return true;
    }


    /// <summary>
    /// Creates or updates the material in the system.
    /// </summary>
    private void UpdateMaterial()
    {
      if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
      {
        using (IMaterialsService service = ServiceFactory.GetMaterialsService())
        {
          service.UpdateMaterial(Material);
        }
      }
      CloseModalDialog();
    }
  }
}