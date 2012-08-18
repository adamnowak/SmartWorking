using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Input;
using System.Windows.Media;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class GeneralViewModel : TabControlViewModelBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public GeneralViewModel(IMainViewModel mainViewModel, IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogService, serviceFactory)
    {

      

      
    }






    /// <summary>
    /// Gets the name of control.
    /// </summary>
    public override string Name
    {
      get { return "General"; }
    }

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
          _createDBDumpCommand = new AsyncDelegateCommand(CreateDBDump, CanCreateDBDump, CompleteDBDump, ErrorDBDump);
        return _createDBDumpCommand;
      }
    }

    private void ErrorDBDump(Exception obj)
    {
      MainViewModel.IsActionExecuting = false;
    }

    private void CompleteDBDump(object obj)
    {
      MainViewModel.IsActionExecuting = false;
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
      string pathName = "dump" + DateTime.Now.ToFileTime() + ".txt";
      string errorCaption = "CreateDBDump";
      MainViewModel.IsActionExecuting = true;
      MainViewModel.ProgressText = "CreateDBDump function...";
      try
      {
        IDBService dbService = ServiceFactory.GetDBService();
        DBBackUpPackage test = dbService.GetBackUpData();
        CreateInsertBackup(test, pathName);
        MainViewModel.StatusText = string.Format("Dump został zapisany do pliku '{0}'", pathName);
        MainViewModel.StatusTextColor = Colors.Black;
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
  }
}
