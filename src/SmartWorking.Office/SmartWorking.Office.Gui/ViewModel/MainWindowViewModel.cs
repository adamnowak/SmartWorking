using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.View;
using SmartWorking.Office.Services.Interfaces;
#if IIS_USED
using SmartWorking.Office.Services.Factory.IIS;
#else
using SmartWorking.Office.Services.Factory.Local;
#endif

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// View model for <see cref="MainWindow"/> window. 
  /// </summary>
  public class MainWindowViewModel : WindowViewModelBase
  {
    private ICommand _manageCarsCommand;
    private ICommand _manageContractorsCommand;
    private ICommand _manageDeliveryNotesCommand;
    private ICommand _manageDriversCommand;
    private ICommand _manageMaterialStocksCommand;
    private ICommand _manageMaterialsCommand;
    private ICommand _manageRecipesCommand;
    private ICommand _createDriversCarsReportCommand;
    private ICommand _createCarsReceipsReportCommand;

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
      : base(modalDialogService, serviceFactory)
    {
      ModalDialogService = modalDialogService;
      ServiceFactory = serviceFactory;
    }

    public override string Title
    {
      get { return "SmartWorking (office)"; }
    }

    /// <summary>
    /// Gets the manage <see cref="DeliveryNote"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="DeliveryNote"/> objects.</remarks>
    public ICommand ManageDeliveryNotesCommand
    {
      get
      {
        if (_manageDeliveryNotesCommand == null)
          _manageDeliveryNotesCommand =
            new RelayCommand(ManageDeliveryNotes);
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
          _manageContractorsCommand =
            new RelayCommand(ManageContractors);
        return _manageContractorsCommand;
      }
    }

    /// <summary>
    /// Gets the manage <see cref="MaterialPrimitive"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="MaterialPrimitive"/> objects.</remarks>
    public ICommand ManageMaterialsCommand
    {
      get
      {
        if (_manageMaterialsCommand == null)
          _manageMaterialsCommand =
            new RelayCommand(ManageMaterials);
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
          _manageRecipesCommand =
            new RelayCommand(ManageRecipes);
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
          _manageCarsCommand = new RelayCommand(ManageCars);
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
          _manageDriversCommand =
            new RelayCommand(ManageDrivers);
        return _manageDriversCommand;
      }
    }

    /// <summary>
    /// Gets the manage <see cref="MaterialStock"/> command.
    /// </summary>
    /// <remarks>Opens dialog to manage <see cref="MaterialStock"/> objects.</remarks>
    public ICommand ManageMaterialStocksCommand
    {
      get
      {
        if (_manageMaterialStocksCommand == null)
          _manageMaterialStocksCommand =
            new RelayCommand(ManageMaterialStocks);
        return _manageMaterialStocksCommand;
      }
    }

    /// <summary>
    /// Gets the creating report about relations <see cref="Driver"/> and <see cref="Car"/> command.
    /// </summary>
    /// <remarks>Creates report about relations <see cref="Driver"/> and <see cref="Car"/>.</remarks>
    public ICommand CreateDriversCarsReportCommand
    {
      get
      {
        if (_createDriversCarsReportCommand == null)
          _createDriversCarsReportCommand =
            new RelayCommand(CreateDriversCarsReport);
        return _createDriversCarsReportCommand;
      }
    }

    /// <summary>
    /// Gets the creating report about relations <see cref="Driver"/> and <see cref="Car"/> command.
    /// </summary>
    /// <remarks>Creates report about relations <see cref="Driver"/> and <see cref="Car"/>.</remarks>
    public ICommand CreateCarsReceipsReportCommand
    {
      get
      {
        if (_createCarsReceipsReportCommand == null)
          _createCarsReceipsReportCommand =
            new RelayCommand(CreateCarsReceipsReport);
        return _createCarsReceipsReportCommand;
      }
    }

    private void CreateCarsReceipsReport()
    {
      string errorCaption = "Tworzenie raportu (Samochody/Recepty)!";
      try
      {
        //TODO:
        MessageBoxResult messageBoxResult = ModalDialogService.ShowMessageBox(ModalDialogService, ServiceFactory,
                                                                              MessageBoxImage.Warning,
                                                                              "Ten przycisk wymaga pracy:)",
                                                                              "Funkcja nie jest jeszcze zaimplementowane. Czeka na swoją kolej.",
                                                                              MessageBoxButton.OKCancel,
                                                                              "Testowałem własności MessageBox'a (wyskakującego małego okienka).");
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }

    private void CreateDriversCarsReport()
    {
      string errorCaption = "Tworzenie raportu (Kierowcy/Samochody)!";
      try
      {
        ModalDialogService.CreateDriversCarsReport(ModalDialogService, ServiceFactory);
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }


    private void ManageDeliveryNotes()
    {
      string errorCaption = "Zarządzanie WZ'tkami!";
      try
      {
        ModalDialogService.ManageDeliveryNotes(ModalDialogService, ServiceFactory);
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }

    private void ManageContractors()
    {
      string errorCaption = "Zarządzanie kontrahentami!";
      try
      {
        ModalDialogService.ManageContractors(ModalDialogService, ServiceFactory);
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
      }
    }

    private void ManageMaterials()
    {
      string errorCaption = "Zarządzanie materiałami!";
      try
      {
        ModalDialogService.ManageMaterials(ModalDialogService, ServiceFactory);
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }

    private void ManageRecipes()
    {
      string errorCaption = "Zarządzanie receptami!";
      try
      {
        ModalDialogService.ManageRecipes(ModalDialogService, ServiceFactory);
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }

    private void ManageCars()
    {
      string errorCaption = "Zarządzanie samochodami!";
      try
      {
        ModalDialogService.ManageCars(ModalDialogService, ServiceFactory);
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }

    private void ManageDrivers()
    {
      string errorCaption = "Zarządzanie kierowcami!";
      try
      {
        ModalDialogService.ManageDrivers(ModalDialogService, ServiceFactory);
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }

    private void ManageMaterialStocks()
    {
      string errorCaption = "Zarządzaniem stanem magazynu!";
      try
      {
        MessageBoxResult messageBoxResult = ModalDialogService.ShowMessageBox(ModalDialogService, ServiceFactory,
                                                                              MessageBoxImage.Warning,
                                                                              "Ten przycisk wymaga pracy:)",
                                                                              "Funkcja nie jest jeszcze zaimplementowane. Czeka na swoją kolej.",
                                                                              MessageBoxButton.OKCancel,
                                                                              "Testowałem własności MessageBox'a (wyskakującego małego okienka).");
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        Cancel();
      }
    }
  }
}