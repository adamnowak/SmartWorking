using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Gui.View.DeliveryNotes;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel.Contractors
{
  /// <summary>
  ///  View model for <see cref="UpdateDeliveryNote"/> dialog. 
  /// </summary>
  public class UpdateDeliveryNoteViewModel : ModalDialogViewModelBase
  {
    private ICommand _selectBuildingCommand;    
    private ICommand _selectRecipeCommand;
    private ICommand _selectDriverCommand;
    private ICommand _selectCarCommand;
    private ICommand _createAndPrintDeliveryNoteCommand;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateDeliveryNoteViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public UpdateDeliveryNoteViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    /// <summary>
    /// Gets or sets the dialog mode.
    /// </summary>
    /// <value>
    /// The dialog mode.
    /// </value>
    public DialogMode DialogMode { get; set; }

    /// <summary>
    /// Gets the title of modal dialog.
    /// </summary>
    public override string Title
    {
      get
      {
        return (DialogMode == DialogMode.Create)
                 ? "Utwórz nową WZ'tkę."
                 : "Edytuj WZ'tkę.";
      }
    }

    #region DeliveryNote property

    /// <summary>
    /// The <see cref="DeliveryNote" /> property's name.
    /// </summary>
    public const string DeliveryNotePropertyName = "DeliveryNote";

    private DeliveryNote _deliveryNote;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public DeliveryNote DeliveryNote
    {
      get { return _deliveryNote; }

      set
      {
        if (_deliveryNote == value)
        {
          return;
        }
        _deliveryNote = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(DeliveryNotePropertyName);
      }
    }

    #endregion

    #region Building property

    /// <summary>
    /// The <see cref="Building" /> property's name.
    /// </summary>
    public const string BuildingPropertyName = "Building";

    private Building _building;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Building Building
    {
      get { return _building; }

      set
      {
        if (_building == value)
        {
          return;
        }
        _building = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(BuildingPropertyName);
      }
    }

    #endregion

    #region Recipe property

    /// <summary>
    /// The <see cref="Recipe" /> property's name.
    /// </summary>
    public const string RecipePropertyName = "Recipe";

    private Recipe _recipe;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Recipe Recipe
    {
      get { return _recipe; }

      set
      {
        if (_recipe == value)
        {
          return;
        }
        _recipe = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(RecipePropertyName);
      }
    }

    #endregion

    #region Driver property

    /// <summary>
    /// The <see cref="Driver" /> property's name.
    /// </summary>
    public const string DriverPropertyName = "Driver";

    private Driver _driver;

    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Driver Driver
    {
      get { return _driver; }

      set
      {
        if (_driver == value)
        {
          return;
        }
        _driver = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(DriverPropertyName);
      }
    }

    #endregion

    #region Car property

    /// <summary>
    /// The <see cref="Car" /> property's name.
    /// </summary>
    public const string CarPropertyName = "Car";

    private Car _car;
    


    /// <summary>
    /// Gets the Contractor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Car Car
    {
      get { return _car; }

      set
      {
        if (_car == value)
        {
          return;
        }
        _car = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(CarPropertyName);
      }
    }

    #endregion

    #region SelectBuildingCommand
    /// <summary>
    /// Gets the select building command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to selecting building.
    /// </remarks>
    public ICommand SelectBuildingCommand
    {
      get
      {
        if (_selectBuildingCommand == null)
          _selectBuildingCommand = new RelayCommand(SelectBuilding);
        return _selectBuildingCommand;
      }
    }

    private void SelectBuilding()
    {
      Building = ModalDialogService.SelectBuilding(ModalDialogService, ServiceFactory);      
    }
    #endregion

    #region SelectRecipeCommand
    public ICommand SelectRecipeCommand
    {
      get
      {
        if (_selectRecipeCommand == null)
          _selectRecipeCommand = new RelayCommand(SelectRecipe);
        return _selectRecipeCommand;
      }
    }

    private void SelectRecipe()
    {
      Recipe = ModalDialogService.SelectRecipe(ModalDialogService, ServiceFactory); 
    }
    #endregion

    #region CreateAndPrintDeliveryNoteCommand
    public ICommand CreateAndPrintDeliveryNoteCommand
    {
      get
      {
        if (_createAndPrintDeliveryNoteCommand == null)
          _createAndPrintDeliveryNoteCommand = new RelayCommand(CreateAndPrintDeliveryNote, CanCreateAndPrintDeliveryNote);
        return _createAndPrintDeliveryNoteCommand;
      }
    }

    private bool CanCreateAndPrintDeliveryNote()
    {
      return Building != null && Car != null && Driver != null && Recipe != null;
    }

    private void CreateAndPrintDeliveryNote()
    {
      if (Building == null)
      {
        throw new SmartWorkingException("Building is not defined.");
      }
      if (Car == null)
      {
        throw new SmartWorkingException("Car is not defined.");
      }
      if (Driver == null)
      {
        throw new SmartWorkingException("Driver is not defined.");
      }
      if (Recipe == null)
      {
        throw new SmartWorkingException("Recipe is not defined.");
      }
      if (DeliveryNote == null)
      {
        throw new SmartWorkingException("DeliveryNote is not initialized.");
      }

      DeliveryNote.Building = Building;
      DeliveryNote.Car = Car;
      DeliveryNote.Driver = Driver;
      DeliveryNote.Recipe = Recipe;

      using (IDeliveryNotesService service = ServiceFactory.GetDeliveryNotesService())
      {
        service.UpdateDeliveryNote(DeliveryNote);
      }

      PrintDeliveryNote(DeliveryNote);

      CloseModalDialog();
    }
    #endregion


    #region SelectDriverCommand
    public ICommand SelectDriverCommand
    {
      get
      {
        if (_selectDriverCommand == null)
          _selectDriverCommand = new RelayCommand(SelectDriver);
        return _selectDriverCommand;
      }
    }

    private void SelectDriver()
    {
      Driver = ModalDialogService.SelectDriver(ModalDialogService, ServiceFactory); 
    }
    #endregion

    #region SelectCarCommand
    public ICommand SelectCarCommand
    {
      get
      {
        if (_selectCarCommand == null)
          _selectCarCommand = new RelayCommand(SelectCar);
        return _selectCarCommand;
      }
    }

    private void SelectCar()
    {
      Car = ModalDialogService.SelectCar(ModalDialogService, ServiceFactory); 
    }
    #endregion

    #region PrintDeliveryNote
    private void PrintDeliveryNote(DeliveryNote deliveryNote)
    {
      //http://read.pudn.com/downloads116/sourcecode/editor/490275/PDFsharp/PdfSharp/PdfSharp.Pdf.Printing/PdfFilePrinter.cs__.htm
      if (deliveryNote.Building == null)
      {
        throw new SmartWorkingException("Building is not defined.");
      }
      if (deliveryNote.Car == null)
      {
        throw new SmartWorkingException("Car is not defined.");
      }
      if (deliveryNote.Driver == null)
      {
        throw new SmartWorkingException("Driver is not defined.");
      }
      if (deliveryNote.Recipe == null)
      {
        throw new SmartWorkingException("Recipe is not defined.");
      }
      string filename = string.Format("d:\\adamnowak\\private\\Sylwek\\temp\\pdf\\WZ_{0}_{1:yyyy-MM-dd_hh-mm-ss-tt}.pdf", deliveryNote.Id, DateTime.Now);

      string text = Building.City + ", " + Building.Street;
      PdfDocument document = new PdfDocument();

      PdfPage page = document.AddPage();
      XGraphics gfx = XGraphics.FromPdfPage(page);
      XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
      XTextFormatter tf = new XTextFormatter(gfx);

      XRect rect = new XRect(40, 100, 250, 232);
      gfx.DrawRectangle(XBrushes.SeaShell, rect);
      tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);
      
      document.Save(filename);
      Process.Start(filename);
    }
    #endregion
  }

  public class SmartWorkingException : Exception
  {
    public SmartWorkingException(string message)
      : base(message)
    {
    }
  }
}