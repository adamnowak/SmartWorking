using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;

using System.Xml;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public static class XPSCreator
  {
    public static IDocumentPaginatorSource RenderFlowDocumentTemplate(string templatePath, object dataContextObject)
    {
      string rawXamlText = "";
      using (StreamReader streamReader = File.OpenText(templatePath))
      {
        rawXamlText = streamReader.ReadToEnd();
      }

      FlowDocument document = XamlReader.Load(new XmlTextReader(new StringReader(rawXamlText))) as FlowDocument;
      if (dataContextObject != null)
      {
        document.DataContext = dataContextObject;
      }
      return document;
    }

    public static IDocumentPaginatorSource RenderFlowDocumentTemplate(string templatePath)
    {

      string rawXamlText = "";



      //Create a StreamReader that will read from the document template.

      using (StreamReader streamReader = File.OpenText(templatePath))
      {

        rawXamlText = streamReader.ReadToEnd();

      }

      //Use the XAML reader to create a FlowDocument from the XAML string.

      FlowDocument document = XamlReader.Load(new XmlTextReader(new StringReader(rawXamlText))) as FlowDocument;

      return document;

    }

    public static PrintDialog GetPrintDialog()
    {
      PrintDialog printDialog = null;

      // Create a Print dialog.
      PrintDialog dlg = new PrintDialog();

      // Show the printer dialog.  If the return is "true",
      // the user made a valid selection and clicked "Ok".
      if (dlg.ShowDialog() == true)
        printDialog = dlg;  // return the dialog the user selections.
      return printDialog;
    }

    private static XpsDocumentWriter GetPrintXpsDocumentWriter(PrintQueue printQueue)
    {
      XpsDocumentWriter xpsWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
      return xpsWriter;
    }

    private static void PrintDocumentPaginator(XpsDocumentWriter xpsDocumentWriter, DocumentPaginator document)
    {
        xpsDocumentWriter.Write(document);
    }


    public static void PrintFlowDocument(PrintQueue printQueue, DocumentPaginator document)
    {
      XpsDocumentWriter xpsDocumentWriter = GetPrintXpsDocumentWriter(printQueue);
      PrintDocumentPaginator(xpsDocumentWriter, document);
    }
  }
}
