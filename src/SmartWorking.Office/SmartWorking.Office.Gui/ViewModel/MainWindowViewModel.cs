using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View;
using SmartWorking.Office.Services.Factory.Local;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  internal class MainWindowViewModel
  {
    private ICommand _createContractorCommand;
    private ICommand _createDeliveryNoteCommand;
    private ICommand _createMaterialCommand;
    private ICommand _createRecipeCommand;
    private ICommand _editContractorCommand;
    private ICommand _editMaterialCommand;
    private ICommand _editRecipeCommand;

    public MainWindowViewModel() :
      this(new ModalDialogService(), new ServiceFactoryLocal())
    {
      //TODO: improve, should be IoC      
    }

    public MainWindowViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      ModalDialogService = modalDialogService;
      ServiceFactory = serviceFactory;
    }

    public IModalDialogService ModalDialogService { get; set; }
    public IServiceFactory ServiceFactory { get; set; }

    #region Contractor commands

    public ICommand CreateContractorCommand
    {
      get
      {
        if (_createContractorCommand == null)
          _createContractorCommand = new RelayCommand(
            () => ModalDialogService.CreateContractor(ModalDialogService, ServiceFactory));
        return _createContractorCommand;
      }
    }

    public ICommand EditContractorCommand
    {
      get
      {
        if (_editContractorCommand == null)
          _editContractorCommand = new RelayCommand(EditContractor);
        return _editContractorCommand;
      }
    }

    private void EditContractor()
    {
      Contractor selectedContractor = ModalDialogService.SelectContractor(ModalDialogService, ServiceFactory);
      if (selectedContractor != null)
      {
        ModalDialogService.EditContractor(ModalDialogService, ServiceFactory, selectedContractor);
      }
    }

    #endregion //Contractor commands

    #region Material commands

    public ICommand CreateMaterialCommand
    {
      get
      {
        if (_createMaterialCommand == null)
          _createMaterialCommand = new RelayCommand(
            () => ModalDialogService.CreateMaterial(ModalDialogService, ServiceFactory));
        return _createMaterialCommand;
      }
    }

    public ICommand EditMaterialCommand
    {
      get
      {
        if (_editMaterialCommand == null)
          _editMaterialCommand = new RelayCommand(EditMaterial);
        return _editMaterialCommand;
      }
    }

    private void EditMaterial()
    {
      Material selectedMaterial = ModalDialogService.SelectMaterial(ModalDialogService, ServiceFactory);
      if (selectedMaterial != null)
      {
        ModalDialogService.EditMaterial(ModalDialogService, ServiceFactory, selectedMaterial);
      }
    }

    #endregion

    #region DeliveryNote

    public ICommand CreateDeliveryNoteCommand
    {
      get
      {
        if (_createDeliveryNoteCommand == null)
          _createDeliveryNoteCommand = new RelayCommand(
            () => ModalDialogService.CreateDeliveryNote(ModalDialogService, ServiceFactory));
        return _createDeliveryNoteCommand;
      }
    }

    #endregion

    #region Recipe commands

    public ICommand CreateRecipeCommand
    {
      get
      {
        if (_createRecipeCommand == null)
          _createRecipeCommand = new RelayCommand(
            () => ModalDialogService.CreateRecipe(ModalDialogService, ServiceFactory));
        return _createRecipeCommand;
      }
    }

    public ICommand EditRecipeCommand
    {
      get
      {
        if (_editRecipeCommand == null)
          _editRecipeCommand = new RelayCommand(EditRecipe);
        return _editRecipeCommand;
      }
    }

    private void EditRecipe()
    {
      Recipe selectedRecipe = ModalDialogService.SelectRecipe(ModalDialogService, ServiceFactory);
      if (selectedRecipe != null)
      {
        ModalDialogService.EditRecipe(ModalDialogService, ServiceFactory, selectedRecipe);
      }
    }

    #endregion
  }
}