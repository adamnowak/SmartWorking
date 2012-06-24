using System;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Gui.ViewModel.Cars;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Reports;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Reports
{
  /// <summary>
  /// View model for <see cref="CreateDriversCarsReport"/> dialog. 
  /// </summary>
  public class DriversCarsReportViewModel : ModalDialogViewModelBase
  {
    private ICommand _createDriversCarsReportCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCarViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DriversCarsReportViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
      StartTime = DateTime.Now.AddMonths(-1);
      EndTime = DateTime.Now;
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the create or update car command.
    /// </summary>
    /// <remarks>
    /// Opens dialog for creating or editing Car.
    /// </remarks>
    public ICommand CreateDriversCarsReportCommand
    {
      get
      {
        if (_createDriversCarsReportCommand == null)
          _createDriversCarsReportCommand = new RelayCommand(CreateDriversCarsReport, CanCreateDriversCarsReport);
        return _createDriversCarsReportCommand;
      }
    }

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return "Report - Kierowcy / Samochody.";
      }
    }

    /// <summary>
    /// Determines whether <see cref="CreateDriversCarsReportCommand"/> can be execute.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if <see cref="CreateDriversCarsReportCommand"/> can be execute; otherwise, <c>false</c>.
    /// </returns>
    private bool CanCreateDriversCarsReport()
    {
      //TODO: validate
      return true;
    }

    /// <summary>
    /// The <see cref="DriversCarsDataReport" /> property's name.
    /// </summary>
    public const string DriversCarsDataReportPropertyName = "DriversCarsDataReport";

    private ReportPackage<CarPrimitive, DriverPrimitive> _driversCarsDataReport;

    /// <summary>
    /// Gets the DriversCarsDataReport property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public ReportPackage<CarPrimitive, DriverPrimitive> DriversCarsDataReport
    {
      get
      {
        return _driversCarsDataReport;
      }

      set
      {
        if (_driversCarsDataReport == value)
        {
          return;
        }
        _driversCarsDataReport = value;  

        // Update bindings, no broadcast
        RaisePropertyChanged(DriversCarsDataReportPropertyName);
      }
    }

    /// <summary>
    /// Creates or updates the car in the system.
    /// </summary>
    private void CreateDriversCarsReport()
    {
      string errorCaption = "Tworzenie danych o samochodzie!";
      try
      {
        if (DialogMode == DialogMode.Create || DialogMode == DialogMode.Update)
        {
          using (IReportsService service = ServiceFactory.GetReportsService())
          {
            DriversCarsDataReport =
              service.GetDriversCarsDataReport(StartTime, EndTime);
            
          }
        }
      }
      catch (FaultException<ExceptionDetail> f)
      {
        ShowError(errorCaption, f);
        //Cancel();
      }
      catch (CommunicationException c)
      {
        ShowError(errorCaption, c);
        //Cancel();
      }
      catch (Exception e)
      {
        ShowError(errorCaption, e);
        //Cancel();
      }
    }

    public DateTime StartTime
    {
      get; set; 
    }

    public DateTime EndTime
    {
      get; set;
    }
  }
}