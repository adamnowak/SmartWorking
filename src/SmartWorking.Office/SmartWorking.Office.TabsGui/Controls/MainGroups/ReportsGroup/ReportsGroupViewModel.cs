using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class ReportsGroupViewModel : TabControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ReportsGroupViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {
      PeriodType = PeriodTypeValues.Daily;
      ReportType = ReportTypesValues.Production;
      DayliDateTime = DateTime.Now;
      MonthlyDateTime = DateTime.Now;
    }

    #region PeriodType
    /// <summary>
    /// The <see cref="PeriodType" /> property's name.
    /// </summary>
    public const string PeriotTypePropertyName = "PeriodType";

    private PeriodTypeValues _periodType;

    /// <summary>
    /// Gets the PeriodType property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public PeriodTypeValues PeriodType
    {
      get
      {
        return _periodType;
      }

      set
      {
        if (_periodType == value)
        {
          return;
        }
        _periodType = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(PeriotTypePropertyName);
      }
    }
    #endregion //PeriodType

    #region ReportType
    /// <summary>
    /// The <see cref="ReportType" /> property's name.
    /// </summary>
    public const string ReportTypePropertyName = "ReportType";

    private ReportTypesValues _reportTypes;

    /// <summary>
    /// Gets the ReportType property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public ReportTypesValues ReportType
    {
      get
      {
        return _reportTypes;
      }

      set
      {
        if (_reportTypes == value)
        {
          return;
        }
        _reportTypes = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(ReportTypePropertyName);
      }
    }
    #endregion //ReportType

    #region GenerateReportCommand
    private ICommand _generateReportCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand GenerateReportCommand
    {
      get
      {
        if (_generateReportCommand == null)
          _generateReportCommand = new RelayCommand(GenerateReport, CanGenerateReport);
        return _generateReportCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanGenerateReport()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void GenerateReport()
    {
      string errorCaption = "TODO!";
      try
      {
        DateTime startDateTime = DayliDateTime.Date;
        DateTime endDateTime = startDateTime.AddDays(1).AddMilliseconds(-1);
        //startDateTime = DayliDateTime.
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
    #endregion //GenerateReportCommand


    #region DayliDateTime
    /// <summary>
    /// The <see cref="DayliDateTime" /> property's name.
    /// </summary>
    public const string DayliDateTimePropertyName = "DayliDateTime";

    private DateTime _dayliDateTime;

    /// <summary>
    /// Gets the DayliDateTime property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public DateTime DayliDateTime
    {
      get
      {
        return _dayliDateTime;
      }

      set
      {
        if (_dayliDateTime == value)
        {
          return;
        }
        _dayliDateTime = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(DayliDateTimePropertyName);
      }
    }
    #endregion //DayliDateTime

    #region MonthlyDateTime
    /// <summary>
    /// The <see cref="MonthlyDateTime" /> property's name.
    /// </summary>
    public const string MonthlyDateTimePropertyName = "MonthlyDateTime";

    private DateTime _monthlyDateTime;

    /// <summary>
    /// Gets the MonthlyDateTime property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public DateTime MonthlyDateTime
    {
      get
      {
        return _monthlyDateTime;
      }

      set
      {
        if (_monthlyDateTime == value)
        {
          return;
        }
        _monthlyDateTime = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(MonthlyDateTimePropertyName);
      }
    }
    #endregion //MonthlyDateTime
    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "Reports"; }
    }
  }
}
