using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Media;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Controls.MainGroups.SettingsGroup;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs
{
  /// <summary>
  /// Main windows view model implementation.
  /// </summary>
  public class DBDumpProgressActionViewModel : ProgressActionViewModelBase
  {
    public IMainViewModel MainViewModel { get; set; }
    public IServiceFactory ServiceFactory { get; private set; }
    public string FilePath { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="modalDialogProvider">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    public DBDumpProgressActionViewModel(IMainViewModel mainViewModel, IServiceFactory serviceFactory, string filePath)
    {
      MainViewModel = mainViewModel;
      ServiceFactory = serviceFactory;
      FilePath = filePath;
    }

    protected override  void OnError(Exception exception)
    {
      MainViewModel.StatusText = "Wystapił błąd.";
    }

    public override void  OnCompleted()
    {
      MainViewModel.StatusText = string.Format("Dump został zapisany do pliku '{0}'", FilePath);
      MainViewModel.StatusTextColor = Colors.Black;
    }

    /// <summary>
    /// //TODO:.
    /// </summary>
    protected override void OnAction()
    {
      IDBService dbService = ServiceFactory.GetDBService();
      DBBackUpPackage dbBackUpPackage = dbService.GetBackUpData();
      CreateInsertBackup(dbBackUpPackage, FilePath);
      Thread.Sleep(5000);
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
  }
}
