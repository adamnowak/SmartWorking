using System;
using System.Diagnostics;
using System.Drawing.Printing;
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
      XGraphics gfx = XGraphics.FromPdfPage(page);      

      //DeliveryNote top
      ComposeDeliveryNoteOnPage(deliveryNotePackage, gfx, 0);

      PrintSection(gfx, "...............................................................................................................................................................................................................",
                   string.Empty,
                   new XPoint(0, 400), 500, 0, 12, 12, 12);

      //DeliveryNote bottom
      ComposeDeliveryNoteOnPage(deliveryNotePackage, gfx, 400);

      document.Save(filename);
      Print(filename);
    }

    private static void ComposeDeliveryNoteOnPage(DeliveryNotePackage deliveryNotePackage, XGraphics gfx, double shiftY)
    {
      //DeliveryNote
      PrintSection(gfx, "WZ: " + deliveryNotePackage.DeliveryNote.Id.ToString(), string.Empty, new XPoint(250, 30 + shiftY));
      
      //Contractor
      string contracotrInfo =
        ((string.IsNullOrEmpty(deliveryNotePackage.BuildingAndContractor.Contractor.FullName)) ? string.Empty : deliveryNotePackage.BuildingAndContractor.Contractor.FullName + Environment.NewLine) +
        ((string.IsNullOrEmpty(deliveryNotePackage.BuildingAndContractor.Contractor.Name)) ? string.Empty : deliveryNotePackage.BuildingAndContractor.Contractor.Name + Environment.NewLine) +
        ((string.IsNullOrEmpty(deliveryNotePackage.BuildingAndContractor.Contractor.Surname)) ? string.Empty : deliveryNotePackage.BuildingAndContractor.Contractor.Surname + Environment.NewLine);
      PrintSection(gfx, "Kontrahent:", contracotrInfo, new XPoint(30, 70 + shiftY));
        
      //Building
      string buildingInfo =
        ((string.IsNullOrEmpty(deliveryNotePackage.BuildingAndContractor.Building.City)) ? string.Empty : deliveryNotePackage.BuildingAndContractor.Building.City + Environment.NewLine) +
        ((string.IsNullOrEmpty(deliveryNotePackage.BuildingAndContractor.Building.Street)) ? string.Empty : deliveryNotePackage.BuildingAndContractor.Building.Street + Environment.NewLine) +
        ((string.IsNullOrEmpty(deliveryNotePackage.BuildingAndContractor.Building.HouseNo)) ? string.Empty : deliveryNotePackage.BuildingAndContractor.Building.HouseNo + Environment.NewLine);
      PrintSection(gfx, "Budowa:", buildingInfo, new XPoint(30, 140 + shiftY));

      //Date drawing
      PrintSection(gfx, "Data wystawienia: ",
                        ((deliveryNotePackage.DeliveryNote.DateDrawing.HasValue) ?
                                                                                   deliveryNotePackage.DeliveryNote.DateDrawing.Value.ToShortDateString()
                           : string.Empty),
                   new XPoint(300, 60 + shiftY));

      //Date of arrival
      PrintSection(gfx, "Data dostarczenia: ", 
                        ((deliveryNotePackage.DeliveryNote.DateOfArrival.HasValue) ?
                                                                                     deliveryNotePackage.DeliveryNote.DateOfArrival.Value.ToShortDateString() 
                           : string.Empty),
                  new XPoint(300, 110 + shiftY));

      //Recipe
      string recipeInfo =
        ((string.IsNullOrEmpty(deliveryNotePackage.Recipe.Name))
           ? string.Empty
           : deliveryNotePackage.Recipe.Name + Environment.NewLine) +
        ((string.IsNullOrEmpty(deliveryNotePackage.Recipe.InternalName))
           ? string.Empty
           : deliveryNotePackage.Recipe.InternalName + Environment.NewLine)+
        ((string.IsNullOrEmpty(deliveryNotePackage.DeliveryNote.Amount.ToString()))
           ? string.Empty
           : deliveryNotePackage.DeliveryNote.Amount + Environment.NewLine);

      PrintSection(gfx, "Recepta:", recipeInfo, new XPoint(200, 180 + shiftY));

      //Car
      PrintSection(gfx, "Samochod: ",
                   ((string.IsNullOrEmpty(deliveryNotePackage.Car.Name))
                      ? string.Empty
                      : deliveryNotePackage.Car.Name + Environment.NewLine) +
                   ((string.IsNullOrEmpty(deliveryNotePackage.Car.RegistrationNumber))
                      ? string.Empty
                      : deliveryNotePackage.Car.RegistrationNumber + Environment.NewLine),
                   new XPoint(30, 270 + shiftY));

      //Driver
      PrintSection(gfx, "Kierowca: ",
                   ((string.IsNullOrEmpty(deliveryNotePackage.Driver.Name)) ? string.Empty : deliveryNotePackage.Driver.Name + Environment.NewLine) +
                   ((string.IsNullOrEmpty(deliveryNotePackage.Driver.Surname)) ? string.Empty  : deliveryNotePackage.Driver.Surname + Environment.NewLine) +
                   ((string.IsNullOrEmpty(deliveryNotePackage.Driver.Phone)) ? string.Empty : deliveryNotePackage.Driver.Phone + Environment.NewLine),
                   new XPoint(200, 270 + shiftY));

      //Sign
      PrintSection(gfx, "Wystawiający: ", Environment.NewLine + "................................", new XPoint(400, 310 + shiftY));
    }

    private static void PrintSection(XGraphics gfx, string header, string text, XPoint point)
    {
      PrintSection(gfx, header, text, point, 200, 100, 16, 10, 20);
    }

    private static void PrintSection(XGraphics gfx, string header, string text, XPoint point, double width, double height, double headerFontSize, double textFontSize, double headerHeight)
    {
      XFont fontHeader = new XFont("Times New Roman", headerFontSize, XFontStyle.Bold);
      XFont fontText = new XFont("Times New Roman", textFontSize, XFontStyle.Bold);
      XTextFormatter tf = new XTextFormatter(gfx);
      tf.DrawString(header, fontHeader, XBrushes.Black, new XRect(point.X, point.Y, width, height));
      tf.DrawString(text, fontText, XBrushes.Black, new XRect(point.X + 5, point.Y + headerHeight, width, height));
    }

    public static void Print(string filename)
    {
      //!!!!!!!!!!MIGRADOC
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

      //!!!!!!!!PDFSHART - PDFFILEPRINTER 
      //PrinterSettings settings = new PrinterSettings();
      //PdfFilePrinter.AdobeReaderPath = @"c:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe";
      //PdfFilePrinter.DefaultPrinterName = settings.PrinterName;
      //PdfFilePrinter printer = new PdfFilePrinter(filename);
      //printer.Print(500);

      //!!!!!!!!!!!!SYSTEM - open file - like double click on file 
      Process.Start(filename);

//!!!!!!!!!!! COMMAND LINE
//c:\>"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe" /p /h d:\adamnowak\
//private\Sylwek\SmartWorking\bin\gui\Debug\pdf\WZ_3_2012-06-23_03-16-42-PM.pdf

//c:\>"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe" /n /t d:\adamnowak\
//private\Sylwek\SmartWorking\bin\gui\Debug\pdf\WZ_3_2012-06-23_03-16-42-PM.pdf "W
//yslij do programu OneNote 2010"

//c:\>"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe" /n /h /t d:\adamnow
//ak\private\Sylwek\SmartWorking\bin\gui\Debug\pdf\WZ_3_2012-06-23_03-16-42-PM.pdf
// "Wyslij do programu OneNote 2010"

//c:\>"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe" /n /h /t d:\adamnow
//ak\private\Sylwek\SmartWorking\bin\gui\Debug\pdf\WZ_3_2012-06-23_03-16-42-PM.pdf
// "Wyslij do programu OneNote 2010"

//c:\>"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe" /n /h /t d:\adamnow
//ak\private\Sylwek\SmartWorking\bin\gui\Debug\pdf\WZ_3_2012-06-23_03-16-42-PM.pdf
// "Wyslij do programu OneNote 2010"

//c:\>"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe" /n /h /t d:\adamnow
//ak\private\Sylwek\SmartWorking\bin\gui\Debug\pdf\WZ_3_2012-06-23_03-16-42-PM.pdf
// "Wyslij do programu OneNote 2010"

//c:\>"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe" /h

//c:\>"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe" /n /h /t d:\adamnow
//ak\private\Sylwek\SmartWorking\bin\gui\Debug\pdf\WZ_3_2012-06-23_03-16-42-PM.pdf
// "Wyslij do programu OneNote 2010"
    }
  }
}
