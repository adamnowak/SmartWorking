using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public static class XPSCreator
  {
    /// <summary>
    /// Load a XAML template from the file system.
    /// </summary>
    /// <param name="templatePath">The file path to the template.</param>
    /// <returns>Object representing the template.</returns>
    public static object LoadTemplate(string templatePath)
    {
      object template;

      // get the absolute path to the template
      string absolutePath = Path.GetFullPath(templatePath);
      string directoryPath = Path.GetDirectoryName(absolutePath);

      // get template from file system
      using (FileStream inputStream = File.OpenRead(absolutePath))
      {        
        template = XamlReader.Load(inputStream);
      }

      return template;
    }

    public static object LoadTemplate(Stream templateStream)
    {
      templateStream.Position = 0;
      return XamlReader.Load(templateStream);
    }

    /// <summary>
    /// Stuffs a DocumentPaginatorSource with data from an object datasource.
    /// </summary>
    /// <param name="document">The document.</param>
    /// <param name="dataSource">The object datasource.</param>
    public static void InjectData(FrameworkContentElement document, object dataSource)
    {

      document.DataContext = dataSource;

      // we need to give the binding infrastructure a push as we
      // are operating outside of the intended use of WPF
      var dispatcher = Dispatcher.CurrentDispatcher;
      dispatcher.Invoke(DispatcherPriority.SystemIdle, new DispatcherOperationCallback(delegate { return null; }), null);
    }

    /// <summary>
    /// Convert a DocumentPaginatorSource to an XPS file.
    /// </summary>
    /// <param name="fixedDoc">The DocumentPaginatorSource to convert.</param>
    /// <param name="outputStream">The output stream.</param>
    public static void ConvertToXps(FixedDocument fixedDoc, Stream outputStream)
    {
      var package = Package.Open(outputStream, FileMode.Create);
      var xpsDoc = new XpsDocument(package, CompressionOption.Normal);
      XpsDocumentWriter xpsWriter = XpsDocument.CreateXpsDocumentWriter(xpsDoc);

      // xps documents are built using fixed document sequences
      var fixedDocSeq = new FixedDocumentSequence();
      var docRef = new DocumentReference();
      docRef.BeginInit();
      docRef.SetDocument(fixedDoc);
      docRef.EndInit();
      ((IAddChild)fixedDocSeq).AddChild(docRef);

      // write out our fixed document to xps
      xpsWriter.Write(fixedDocSeq.DocumentPaginator);

      xpsDoc.Close();
      package.Close();
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

    //private
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

    public static FixedDocument ConvertToFixedDocument(DocumentPaginator documentPaginator)//IDocumentPaginatorSource flowDocument, 
    {

      FixedDocument fixeddoc = new FixedDocument();



     // DocumentPaginator paginator = documentPaginator;
      if (!documentPaginator.IsPageCountValid)
        documentPaginator.ComputePageCount();

      

      int pageindex;
      for (pageindex = 0; pageindex < documentPaginator.PageCount; pageindex++)
      {
        Grid grid = new Grid();
        DocumentPageView pageView = new DocumentPageView();
        pageView.DocumentPaginator = documentPaginator;
        pageView.PageNumber = pageindex;

        grid.Children.Add(new Border()
        {
          BorderBrush = Brushes.Black,
          BorderThickness = new Thickness(1),
          HorizontalAlignment = HorizontalAlignment.Center,
          VerticalAlignment = VerticalAlignment.Center,
          Child = pageView
        });

        FixedPage fixedpage = new FixedPage();
        fixedpage.Width = documentPaginator.PageSize.Width;
        fixedpage.Height = documentPaginator.PageSize.Height;
        fixedpage.Children.Add(grid);
        
        PageContent pc = new PageContent();
        ((IAddChild)pc).AddChild(fixedpage);
        fixeddoc.Pages.Add(pc);
      }

      return fixeddoc;
    }

    public static void AddBlock(Block from, FlowDocument to)
    {
      if (from != null)
      {
        //if (from is ItemsContent)
        //{
        //  ((ItemsContent)from).RunBeforeCopy();
        //}
        //else
        {
          TextRange range = new TextRange(from.ContentStart, from.ContentEnd);

          MemoryStream stream = new MemoryStream();

          System.Windows.Markup.XamlWriter.Save(range, stream);

          range.Save(stream, DataFormats.XamlPackage);

          TextRange textRange2 = new TextRange(to.ContentEnd, to.ContentEnd);

          textRange2.Load(stream, DataFormats.XamlPackage);
        }
        
      }
    }

    public static FlowDocument GetClone(this FlowDocument flowDocument)
    {
      System.IO.MemoryStream s = new System.IO.MemoryStream();
      TextRange source = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
      source.Save(s, DataFormats.Xaml);
      FlowDocument copy = new FlowDocument();
      TextRange dest = new TextRange(copy.ContentStart, copy.ContentEnd);
      dest.Load(s, DataFormats.Xaml); 

      //copy.Blocks.Clear();
      //List<ItemsContent> i = flowDocument.Blocks.OfType<ItemsContent>().ToList();
      //foreach (ItemsContent itemsContent in i)
      //{
      //  itemsContent.RunBeforeCopy();
      //}
      //foreach (Block block in flowDocument.Blocks)
      //{
        
      
      
      //  AddBlock(block, copy);
      //}
      return copy;
    }

    public static DocumentPaginator GetCloneDocumentPaginator(this FlowDocument flowDocument)
    {
      FlowDocument copy = flowDocument.GetClone();
      return ((IDocumentPaginatorSource) copy).DocumentPaginator;
    }
  }
}
