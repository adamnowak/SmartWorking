using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
#if IIS_USED
using SmartWorking.Office.Services.Factory.IIS;
#else
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.MetaDates;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Factory.Local;
#endif
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.Cars;
using SmartWorking.Office.TabsGui.Controls.MainGroups;
using SmartWorking.Office.TabsGui.Controls.MainGroups.AdministrationGroup;
using SmartWorking.Office.TabsGui.Controls.MainGroups.ReportsGroup;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SaleGroup;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup;
using SmartWorking.Office.TabsGui.Shared.View;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;
using WPFLocalizeExtension.Engine;

namespace SmartWorking.Office.TabsGui
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class MainWindowViewModel : TabControlViewModelBase, IMainViewModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel():
      this(new ModalDialogService(),
#if IIS_USED
      new ServiceFactoryIIS()
#else
           new ServiceFactoryLocal()
#endif
      )
    {
      //TODO: improve, should be IoC      
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public MainWindowViewModel(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(null, modalDialogService, serviceFactory)
    {
      SaleGroupViewModel = new SaleGroupViewModel(this, ModalDialogService, ServiceFactory);
      AdministrationGroupViewModel = new AdministrationGroupViewModel(this, ModalDialogService, ServiceFactory);
      SettingsGroupViewModel = new SettingsGroupViewModel(this, ModalDialogService, ServiceFactory);
      ReportsGroupViewModel = new ReportsGroupViewModel(this, ModalDialogService, ServiceFactory);
      IsBlockedAccessLevel = false; 
      MainViewModel = this;
      AccessLevel = AccessLevels.AdministratorLevel;//.WOSLevel;
      IsDebugMode = false;
      LocalizeDictionary.Instance.Culture = new CultureInfo("pl-PL");
      Configuration = new SmartWorkingConfiguration();
      Configuration.PreviewDeliveryNote = true;
      Configuration.PagesToPrint = 1;

#if CONFIG_NAME_DebugLocalSylwek
      AccessLevel = AccessLevels.OperatorLevel;
      IsDebugMode = false;
      IsBlockedAccessLevel = true;
#endif
    }

    private void CreateInsertBackup(DBBackUpPackage dbBackUpPackage, string fileName)
    {
      try
      {
        List<string> lines = new List<string>();

        lines.Add("USE [SmartWorking]");
        lines.Add("GO");

        lines.Add("SET IDENTITY_INSERT [dbo].[Recipes] ON");
        foreach (RecipePrimitive primitive in dbBackUpPackage.RecipeList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[Recipes] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[Drivers] ON");
        foreach (DriverPrimitive primitive in dbBackUpPackage.DriverList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[Drivers] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[Buildings] ON");
        foreach (BuildingPrimitive primitive in dbBackUpPackage.BuildingList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[Buildings] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[Contractors] ON");
        foreach (ContractorPrimitive primitive in dbBackUpPackage.ContractorList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[Contractors] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[Clients] ON");
        foreach (ClientPrimitive primitive in dbBackUpPackage.ClientList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[Clients] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[ClientBuildings] ON");
        foreach (ClientBuildingPrimitive primitive in dbBackUpPackage.ClientBuildingList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[ClientBuildings] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[Cars] ON");
        foreach (CarPrimitive primitive in dbBackUpPackage.CarList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[Cars] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[Materials] ON");
        foreach (MaterialPrimitive primitive in dbBackUpPackage.MaterialList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[Materials] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[RecipeComponents] ON");
        foreach (RecipeComponentPrimitive primitive in dbBackUpPackage.RecipeComponentList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[RecipeComponents] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[Orders] ON");
        foreach (OrderPrimitive primitive in dbBackUpPackage.OrderList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[Orders] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[MaterialStocks] ON");
        foreach (MaterialStockPrimitive primitive in dbBackUpPackage.MaterialStockList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[MaterialStocks] OFF");

        lines.Add("SET IDENTITY_INSERT [dbo].[DeliveryNotes] ON");
        foreach (DeliveryNotePrimitive primitive in dbBackUpPackage.DeliveryNoteList)
        {
          lines.Add(primitive.GetDBInsertQuery());
        }
        lines.Add("SET IDENTITY_INSERT [dbo].[DeliveryNotes] OFF");

        System.IO.File.WriteAllLines(fileName, lines);
      }
      catch (Exception)
      {
        //TODO:
      }
      
    }


    /// <summary>
    /// Gets a value indicating whether this instance is blocked access level.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is blocked access level; otherwise, <c>false</c>.
    /// </value>
    public bool IsBlockedAccessLevel { get; private set; }

    #region AccessLevel
    /// <summary>
    /// The <see cref="AccessLevel" /> property's name.
    /// </summary>
    public const string AccessLevelPropertyName = "AccessLevel";

    private AccessLevel _accessLevel;

    /// <summary>
    /// Gets the AccessLevel property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public AccessLevel AccessLevel
    {
        get
        {
            return _accessLevel;
        }

        set
        {
            if (_accessLevel == value)
            {
                return;
            }
            _accessLevel = value;
            // Update bindings, no broadcast
            RaisePropertyChanged(AccessLevelPropertyName);
        }
    }
    #endregion //AccessLevel

    #region IsDebugMode
    /// <summary>
    /// The <see cref="IsDebugMode" /> property's name.
    /// </summary>
    public const string IsDebugModePropertyName = "IsDebugMode";

    private bool _isDebugMode;

    /// <summary>
    /// Gets the IsDebugMode property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public bool IsDebugMode
    {
      get
      {
        return _isDebugMode;
      }

      set
      {
        if (_isDebugMode == value)
        {
          return;
        }
        _isDebugMode = value;
        if (_isDebugMode)
        {
          var ci = new CultureInfo("en-US");
          LocalizeDictionary.Instance.Culture = ci;

          Thread.CurrentThread.CurrentCulture = ci;
          Thread.CurrentThread.CurrentUICulture = ci;
          //FrameworkElement.LanguageProperty.OverrideMetadata(
          //     typeof(FrameworkElement),
          //     new FrameworkPropertyMetadata(
          //         XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
        else
        {
          var ci = new CultureInfo("pl-PL");
          LocalizeDictionary.Instance.Culture = ci;          

          Thread.CurrentThread.CurrentCulture = ci;
          Thread.CurrentThread.CurrentUICulture = ci;
          //FrameworkElement.LanguageProperty.OverrideMetadata(
          //     typeof(FrameworkElement),
          //     new FrameworkPropertyMetadata(
          //         XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        // Update bindings, no broadcast
        RaisePropertyChanged(IsDebugModePropertyName);
      }
    }
    #endregion //IsDebugMode

    public SaleGroupViewModel SaleGroupViewModel { get; private set; }

    public AdministrationGroupViewModel AdministrationGroupViewModel { get; private set; }

    public SettingsGroupViewModel SettingsGroupViewModel { get; private set; }

    public ReportsGroupViewModel ReportsGroupViewModel { get; private set; }

    #region StatusText
    /// <summary>
    /// The <see cref="StatusText" /> property's name.
    /// </summary>
    public const string StatusTextPropertyName = "StatusText";

    private string _statusText;

    /// <summary>
    /// Gets the StatusText property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public string StatusText
    {
      get
      {
        return _statusText;
      }

      set
      {
        if (_statusText == value)
        {
          return;
        }
        _statusText = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(StatusTextPropertyName);
      }
    }
    #endregion //StatusText

    #region StatusTextColor
    /// <summary>
    /// The <see cref="StatusTextColor" /> property's name.
    /// </summary>
    public const string StatusTextColorPropertyName = "StatusTextColor";

    private Color _statusTextColor;

    /// <summary>
    /// Gets the StatusTextColor property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public Color StatusTextColor
    {
      get
      {
        return _statusTextColor;
      }

      set
      {
        if (_statusTextColor == value)
        {
          return;
        }
        _statusTextColor = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(StatusTextColorPropertyName);
      }
    }
    #endregion //StatusTextColor

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "str_SmartWorking.Office"; }
    }

    public SmartWorkingConfiguration Configuration { get; private set; }

    #region CreateDBDumpCommand
    private ICommand _createDBDumpCommand;

    /// <summary>
    /// Gets the //TODO: command.
    /// </summary>
    /// <remarks>
    /// Opens dialog to //TODO:.
    /// </remarks>
    public ICommand CreateDBDumpCommand
    {
      get
      {
        if (_createDBDumpCommand == null)
          _createDBDumpCommand = new RelayCommand(CreateDBDump, CanCreateDBDump);
        return _createDBDumpCommand;
      }
    }

    /// <summary>
    /// Determines whether this instance an //TODO:.
    /// </summary>
    /// <returns>
    ///   <c/>true<c/> if this instance can //TODO:; otherwise, <c/>false<c/>.
    /// </returns>
    private bool CanCreateDBDump()
    {
      return true;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    private void CreateDBDump()
    {
      string errorCaption = "TODO!";
      try
      {
        IDBService dbService = ServiceFactory.GetDBService();
        DBBackUpPackage test = dbService.GetBackUpData();
        CreateInsertBackup(test, @"dump" + DateTime.Now.ToFileTime() + ".txt");
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
    #endregion //CreateDBDumpCommand

  }
}
