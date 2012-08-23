using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.ServiceModel;
using System.Windows.Documents;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup
{
  
  public interface IReportData
  {
    IList Items { get; }
  }

  public abstract class ReportBase : ControlViewModelBase, IReport
  {
    public ReportBase(string templateName, IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory) 
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      TemplateName = templateName;
    }

    public string TemplateName { get; protected set; }

    protected virtual IReportData Data { get; set; }

    protected virtual Stream GetTemplateStream()
    {
      // get the absolute path to the template
      string absolutePath = Path.GetFullPath(TemplateName);
      string directoryPath = Path.GetDirectoryName(absolutePath);
      // get template from file system
      return  File.OpenRead(absolutePath);
    }

    public FlowDocument GenerateReport(DateTime startTime, DateTime endTime, PeriodTypeValues period)
    {
      string errorCaption = "GenerateReport";
      try
      {
        Data = FillData(startTime, endTime, period);
        using (Stream templateStream = GetTemplateStream())
        {
          FlowDocument flowDocument = (FlowDocument) XPSCreator.LoadTemplate(templateStream);
          FillDocument(flowDocument, startTime, endTime);
          templateStream.Close();
          return flowDocument;
        }
        
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
      return null;
    }

    protected abstract IReportData FillData(DateTime startTime, DateTime endTime, PeriodTypeValues period);

    protected virtual void FillDocument(FlowDocument flowDocument, DateTime startTime, DateTime endTime)
    {
      XPSCreator.InjectData(flowDocument, Data);
    }

    public void ExportToExcel(DateTime startTime, DateTime endTime, PeriodTypeValues period)
    {
      string errorCaption = "ExportToExcel";
      try
      {
        //TODO:
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
  }

  
}