using System;
using System.IO;
using System.Reflection;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SmartWorking.Office.PrimitiveEntities.Reports;

namespace SmartWorking.Office.Gui.ViewModel.Exporters
{
  public class ExcelExporter : IExporter
  {
    public void DriversCarsReportExport(DriversCarsReportPackage driversCarsReportPackage, DateTime startTime, DateTime endTime, string path)
    {
      // Getting the complete workbook...
      HSSFWorkbook templateWorkbook = CreateEmptyWorkbook("Samochody\\Kierowcy raport zbiorczy",
        string.Format("FROM_{0}_TO_{1}", startTime.ToString("yyyy_mm_dd"), endTime.ToString("yyyy_mm_dd")));

      // Getting the worksheet by its name...
      var  sheet = templateWorkbook.GetSheetAt(0);

      // Getting the row... 0 is the first row.
      var dataRow = sheet.CreateRow(0);

      // Setting the value 77 at row 5 column 1
      dataRow.CreateCell(0).SetCellValue(77);

      // Forcing formula recalculation...
      sheet.ForceFormulaRecalculation = true;

      WriteWorkbook(templateWorkbook, path);
    }

    private HSSFWorkbook CreateEmptyWorkbook(string subject, string sheetName)
    {
      HSSFWorkbook hssfworkbook = new HSSFWorkbook();

      ////create a entry of DocumentSummaryInformation
      DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
      dsi.Company = "Adam Nowak";
      hssfworkbook.DocumentSummaryInformation = dsi;

      ////create a entry of SummaryInformation
      SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
      si.Subject = subject;
      hssfworkbook.SummaryInformation = si;

      //here, we must insert at least one sheet to the workbook. otherwise, Excel will say 'data lost in file'
      //So we insert three sheet just like what Excel does
      hssfworkbook.CreateSheet(sheetName);

      ((HSSFSheet)hssfworkbook.GetSheetAt(0)).AlternativeFormula = false;
      ((HSSFSheet)hssfworkbook.GetSheetAt(0)).AlternativeExpression = false;

      return hssfworkbook;
    }

    private void WriteWorkbook(HSSFWorkbook hssfworkbook, string path)
    {
      FileStream file = new FileStream(path, FileMode.Create);
      hssfworkbook.Write(file);
      file.Close();
    }
  }
}
