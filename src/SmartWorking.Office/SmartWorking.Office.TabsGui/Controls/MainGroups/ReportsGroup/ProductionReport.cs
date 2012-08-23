using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Windows.Documents;
using System.Xml;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Properties;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup
{
  public class ProductionReportSubData
  {
    public string RecipeCode { get; set; }
    public string RecipeName { get; set; }
    public string Amount { get; set; }
  }

  public class ProductionReportData : IReportData
  {
    public ProductionReportData()
    {
      Items = new List<ProductionReportSubData>();
    }
    public string Header { get; set; }    
    public IList Items { get; set; }
    public string Sum { get; set; }
  }

  public class ProductionReport : ReportBase
  {
    public ProductionReport(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base("XPSTemplates\\ProductionReportTemplate.xaml", mainViewModel, modalDialogProvider, serviceFactory)
    {
    }

    protected override IReportData FillData(DateTime startTime, DateTime endTime, PeriodTypeValues period)
    {
      string header = PeriodTypes.GetString(period) + " raport produkcji z ";
      switch (period)
      {
        case PeriodTypeValues.Daily:
          {
            header += "dnia " + startTime.ToShortDateString();
            break;
          }
        case PeriodTypeValues.Monthly:
          {
            header += "miesiąca " + startTime.Month.ToString();
            break;
          }
        case PeriodTypeValues.Custom:
          {
            header += "okresu od: " + startTime.ToShortDateString() + " do: " + endTime.ToShortDateString();
            break;
          }
      }
      
      ProductionReportData
        result = new ProductionReportData() {Header = 
          header};
      using (IReportsService service = ServiceFactory.GetReportsService())
      {
        List<DeliveryNoteReportPackage> deliveryNoteReportPackageList = service.GetDeliveryNoteReportPackageListByDateTime(startTime, endTime);
        var groups = deliveryNoteReportPackageList.GroupBy(x => (x.Recipe != null) ? x.Recipe.Id : 0).AsEnumerable();
        double amountAllElements = 0;
        List<ProductionReportSubData> productionReportSubDatas = new List<ProductionReportSubData>();
        foreach (var group in groups)
        {
          if (group.Count() <= 0)
            break;

          if (group.FirstOrDefault() == null)
            break;

          string recipeCode = "0";
          string recipeName = "NotDefined";
          if (group.FirstOrDefault().Recipe != null)
          {
            recipeName = group.FirstOrDefault().Recipe.Name;
            recipeCode = group.FirstOrDefault().Recipe.Code;
          }



          double amountOfElement = 0;

          foreach (var elementGroup in group)
          {
            if (elementGroup != null && elementGroup.DeliveryNote != null && !elementGroup.DeliveryNote.IsDeactive && !elementGroup.DeliveryNote.IsDeleted)
            {
              amountOfElement += elementGroup.DeliveryNote.Amount ?? 0;
            }
          }
          amountAllElements += amountOfElement;

          productionReportSubDatas.Add(new ProductionReportSubData()
                             {RecipeCode = recipeCode, RecipeName = recipeName, Amount = amountOfElement.ToString()});
          Debug.WriteLine("Code: " + recipeCode + " Nazwa recepty: " + recipeName + ", GroupKey:" + group.Key + ", GroupCount: " + group.Count() + ", Ilość: " + amountOfElement + " m3");
          
        }
        result.Items = productionReportSubDatas.OrderBy(x => x.RecipeCode).ToList();
        result.Sum = amountAllElements.ToString();
      }
      return result;
     
    }

    protected override Stream GetTemplateStream()
    {
      using (Stream s = base.GetTemplateStream())
      {
        XmlDocument xamlDoc = new XmlDocument();
        
        xamlDoc.Load(s);

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xamlDoc.NameTable);
        nsmgr.AddNamespace("base", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
        nsmgr.AddNamespace("x", "http://schemas.microsoft.com/winfx/2006/xaml");

        XmlNode itemsTable = xamlDoc.DocumentElement.SelectSingleNode("//base:Table[@x:Name='tableToReplace']", nsmgr);

        if (Data != null && Data.Items != null)
        {
          for (int i = 1; i < Data.Items.Count; i++)
          {
            XmlNode rowGroup = itemsTable.LastChild;
            XmlNode newRowGroup = rowGroup.Clone();
            string bindingText = newRowGroup.Attributes["DataContext"].Value;
            bindingText = bindingText.Remove(bindingText.LastIndexOf('[')) + "[" + i + "] }";
            newRowGroup.Attributes["DataContext"].Value = bindingText;
            //newRowGroup.Attributes["Background"].Value = (i%2) == 0 ? "White" : "LightGray";
            itemsTable.InsertAfter(newRowGroup, rowGroup);
          }
        }

        MemoryStream memStream = new MemoryStream();
        xamlDoc.Save(memStream);
        
        return memStream;
      }

    }

    public override string Name
    {
      get { return "ProductionReport"; }
    }

    public override void Save()
    {
      throw new NotImplementedException();
    }

    public override void Cancel()
    {
      throw new NotImplementedException();
    }
  }
}