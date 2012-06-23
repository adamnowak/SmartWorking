using System;
using System.Diagnostics;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Printing;
using SmartWorking.Office.Gui.ViewModel.DeliveryNotes;
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Gui.ViewModel
{
  public static class PrinterHelper
  {
    public static void PrintDeliveryNote(DeliveryNotePackage deliveryNotePackage)
    {
      string errorCaption = "Drukowanie WZ'tki!";

      //http://read.pudn.com/downloads116/sourcecode/editor/490275/PDFsharp/PdfSharp/PdfSharp.Pdf.Printing/PdfFilePrinter.cs__.htm
      if (deliveryNotePackage.BuildingAndContractor == null)
      {
        throw new SmartWorkingException("Building and contractor is not defined.");
      }
      if (deliveryNotePackage.BuildingAndContractor.Building == null)
      {
        throw new SmartWorkingException("Building is not defined.");
      }
      if (deliveryNotePackage.BuildingAndContractor.Contractor == null)
      {
        throw new SmartWorkingException("Contractor is not defined.");
      }
      if (deliveryNotePackage.Car == null)
      {
        throw new SmartWorkingException("Car is not defined.");
      }
      if (deliveryNotePackage.Driver == null)
      {
        throw new SmartWorkingException("Driver is not defined.");
      }
      if (deliveryNotePackage.Recipe == null)
      {
        throw new SmartWorkingException("Recipe is not defined.");
      }

      string path =  Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "pdf");

      if (!Directory.Exists(path))
      {
        System.IO.Directory.CreateDirectory(path);
      }

      string filename = Path.Combine(path,
                                     string.Format("WZ_{0}_{1:yyyy-MM-dd_hh-mm-ss-tt}.pdf",
                                                   deliveryNotePackage.DeliveryNote.Id, DateTime.Now));

      PdfDocument document = new PdfDocument();

      
      PdfPage page = document.AddPage();
      page.Orientation = PdfSharp.PageOrientation.Landscape;
      page.Size = PdfSharp.PageSize.Letter;
      page.Rotate = 0;

      XGraphics gfx = XGraphics.FromPdfPage(page);
      XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
      XTextFormatter tf = new XTextFormatter(gfx);

      string text = "todo: " + deliveryNotePackage.BuildingAndContractor.Building.City + ", " +
                    deliveryNotePackage.BuildingAndContractor.Building.Street;
      XRect rect = new XRect(10, 100, 250, 232);
      //gfx.DrawRectangle(XBrushes.SeaShell, rect);
      tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

      document.Save(filename);
      //Process.Start(filename);
      //PdfReader.Open(filename, PdfDocumentOpenMode.ReadOnly);
      //PdfReader.
      Print(filename);
    }


    public static void Print(string filename)
    {

      // Reuse the renderer from the preview
      //DocumentRenderer renderer = this.pagePreview.Renderer;
      //if (renderer != null)
      //{
      //  int pageCount = renderer.FormattedDocument.PageCount;
      //  // Creates a PrintDocument that simplyfies printing of MigraDoc documents
      //  MigraDocPrintDocument printDocument = new MigraDocPrintDocument();
      //  // Attach the current printer settings
      //  printDocument.PrinterSettings = this.printerSettings;
      //  if (this.printerSettings.PrintRange == PrintRange.Selection)
      //    printDocument.SelectedPage = this.pagePreview.Page;
      //  // Attach the current document renderer
      //  printDocument.Renderer = renderer;
      //  // Print the document
      //  printDocument.Print();
      //}


      PdfFilePrinter.AdobeReaderPath = @"c:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe";      
      PdfFilePrinter.DefaultPrinterName = "PDF995";
      PdfFilePrinter printer = new PdfFilePrinter(filename);

      try
      {
        printer.Print();
      }
      catch (Exception ex)
      {
        throw new NotImplementedException();
      }

    }
  }
}
