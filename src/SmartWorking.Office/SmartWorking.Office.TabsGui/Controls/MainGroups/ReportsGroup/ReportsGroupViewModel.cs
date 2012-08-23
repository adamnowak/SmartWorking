using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SmartWorking.Office.PrimitiveEntities;
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
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public ReportsGroupViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      PeriodType = PeriodTypeValues.Daily;
      ReportType = ReportTypeValues.Production;
      StartDateTime = DateTime.Now;
      ProductionReport = new ProductionReport(MainViewModel, ModalDialogProvider, ServiceFactory);

    }

    public ProductionReport ProductionReport { get; private set; }

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

    private ReportTypeValues _reportType;

    /// <summary>
    /// Gets the ReportType property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public ReportTypeValues ReportType
    {
      get
      {
        return _reportType;
      }

      set
      {
        if (_reportType == value)
        {
          return;
        }
        _reportType = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(ReportTypePropertyName);
      }
    }
    #endregion //ReportType

    #region DocumentPaginatorSource
    /// <summary>
    /// The <see cref="DocumentPaginatorSource" /> property's name.
    /// </summary>
    public const string DocumentPaginatorSourcePropertyName = "DocumentPaginatorSource";

    private IDocumentPaginatorSource _documentPaginatorSource;

    /// <summary>
    /// Gets the DocumentPaginatorSource property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public IDocumentPaginatorSource DocumentPaginatorSource
    {
      get
      {
        return _documentPaginatorSource;
      }

      set
      {
        if (_documentPaginatorSource == value)
        {
          return;
        }
        _documentPaginatorSource = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(DocumentPaginatorSourcePropertyName);
      }
    }
    #endregion //DocumentPaginatorSource

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
        FlowDocument flowDocument = null;
        DateTime startDateTime = StartDateTime.Date;
        DateTime endDateTime = EndDateTime.Date.AddDays(1).AddMilliseconds(-1);
        if (ReportType == ReportTypeValues.Production)
        {
          endDateTime = StartDateTime.Date.AddDays(1).AddMilliseconds(-1);
          flowDocument = ProductionReport.GenerateReport(startDateTime, endDateTime, PeriodType);
        }
        else if (ReportType == ReportTypeValues.DeliveryNotes)
        {
          
        }


        if (flowDocument != null)
        {
          double width = 793;
          double horizmargin = 48;
          flowDocument.ColumnGap = 0;
          flowDocument.ColumnWidth = width - 2*horizmargin;
          DocumentPaginatorSource = XPSCreator.ConvertToFixedDocument( //FlowDocumentViewModel.DocumentPaginatorSource.DocumentPaginator);
            new DocumentPaginatorWrapper(
              ((IDocumentPaginatorSource)flowDocument).DocumentPaginator,
              new Size(width, 1122), new Size(horizmargin, 48)));
        }
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

    #region StartDateTime
    /// <summary>
    /// The <see cref="StartDateTime" /> property's name.
    /// </summary>
    public const string StartDateTimePropertyName = "StartDateTime";

    private DateTime _startDateTime;

    /// <summary>
    /// Gets the StartDateTime property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public DateTime StartDateTime
    {
      get
      {
        return _startDateTime;
      }

      set
      {
        if (_startDateTime == value)
        {
          return;
        }
        _startDateTime = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(StartDateTimePropertyName);
      }
    }
    #endregion //StartDateTime

    #region EndDateTime
    /// <summary>
    /// The <see cref="EndDateTime" /> property's name.
    /// </summary>
    public const string EndDateTimePropertyName = "EndDateTime";

    private DateTime _endDateTime;

    /// <summary>
    /// Gets the EndDateTime property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public DateTime EndDateTime
    {
      get
      {
        return _endDateTime;
      }

      set
      {
        if (_endDateTime == value)
        {
          return;
        }
        _endDateTime = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(EndDateTimePropertyName);
      }
    }
    #endregion //EndDateTime

    #region SelectedDatesChangedCommand
    private ICommand _selectedDatesChangedCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand SelectedDatesChangedCommand
    {
      get
      {
        if (_selectedDatesChangedCommand == null)
          _selectedDatesChangedCommand = new RelayCommand<object>(SelectedDatesChanged);
        return _selectedDatesChangedCommand;
      }
    }

  

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void SelectedDatesChanged(object o)
    {
      SelectedDatesCollection selectedDatesCollection = o as SelectedDatesCollection;
      if (selectedDatesCollection != null && selectedDatesCollection.Count > 0)
      {
        StartDateTime = new DateTime(selectedDatesCollection.Min(x => x.Ticks));
        EndDateTime = new DateTime(selectedDatesCollection.Max(x => x.Ticks));
      }
    }
    #endregion //SelectedDatesChangedCommand

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "Reports"; }
    }
  }
}
