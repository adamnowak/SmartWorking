using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View;
#if IIS_USED
using SmartWorking.Office.Services.Factory.IIS;
#else
using SmartWorking.Office.Services.Factory.Local;
#endif
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// View model for <see cref="MainWindow"/> window. 
  /// </summary>
  internal class MainWindowViewModel
  {
    private ICommand _manageContractorsCommand;
    private ICommand _manageDeliveryNotesCommand;
    private ICommand _manageMaterialsCommand;
    private ICommand _manageRecipesCommand;
    private ICommand _manageCarsCommand;
    private ICommand _manageDriversCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/>. 
    /// </summary>
    public MainWindowViewModel() :
      this(new ModalDialogService(),
#if IIS_USED
      new ServiceFactoryIIS()
#else
 new ServiceFactoryLocal()
#endif
      )
    {
      //TODO: improve, should be IoC      
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public MainWindowViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
    {
      ModalDialogService = modalDialogService;
      ServiceFactory = serviceFactory;
    }

    /// <summary>
    /// Gets or sets the modal dialog service.
    /// </summary>
    /// <value>
    /// The modal dialog service.
    /// </value>
    public IModalDialogService ModalDialogService { get; set; }
    /// <summary>
    /// Gets or sets the service factory.
    /// </summary>
    /// <value>
    /// The service factory.
    /// </value>
    public IServiceFactory ServiceFactory { get; set; }

    /// <summary>
    /// Gets the manage <see cref="DeliveryNote"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="DeliveryNote"/> objects.</remarks>
    public ICommand ManageDeliveryNotesCommand
    {
      get
      {
        if (_manageDeliveryNotesCommand == null)
          _manageDeliveryNotesCommand = new RelayCommand(() => ModalDialogService.ManageDeliveryNotes(ModalDialogService, ServiceFactory));
        return _manageDeliveryNotesCommand;
      }
    }

    /// <summary>
    /// Gets the manage <see cref="Contractor"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="Contractor"/> objects.</remarks>
    public ICommand ManageContractorsCommand
    {
      get
      {
        if (_manageContractorsCommand == null)
          _manageContractorsCommand = new RelayCommand(() => ModalDialogService.ManageContractors(ModalDialogService, ServiceFactory));
        return _manageContractorsCommand;
      }
    }

    /// <summary>
    /// Gets the manage <see cref="Material"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="Material"/> objects.</remarks>
    public ICommand ManageMaterialsCommand
    {
      get
      {
        if (_manageMaterialsCommand == null)
          _manageMaterialsCommand = new RelayCommand(() => ModalDialogService.ManageMaterials(ModalDialogService, ServiceFactory));
        return _manageMaterialsCommand;
      }
    }

    /// <summary>
    /// Gets the manage <see cref="Recipe"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="Recipe"/> objects.</remarks>
    public ICommand ManageRecipesCommand
    {
      get
      {
        if (_manageRecipesCommand == null)
          _manageRecipesCommand = new RelayCommand(() => ModalDialogService.ManageRecipes(ModalDialogService, ServiceFactory));
        return _manageRecipesCommand;
      }
    }

    /// <summary>
    /// Gets the manage <see cref="Car"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="Car"/> objects.</remarks>
    public ICommand ManageCarsCommand
    {
      get
      {
        if (_manageCarsCommand == null)
          _manageCarsCommand = new RelayCommand(() => ModalDialogService.ManageCars(ModalDialogService, ServiceFactory));
        return _manageCarsCommand;
      }
    }

    /// <summary>
    /// Gets the manage <see cref="Driver"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="Driver"/> objects.</remarks>
    public ICommand ManageDriversCommand
    {
      get
      {
        if (_manageDriversCommand == null)
          _manageDriversCommand = new RelayCommand(() => ModalDialogService.ManageDrivers(ModalDialogService, ServiceFactory));
        return _manageDriversCommand;
      }
    }
  }
}