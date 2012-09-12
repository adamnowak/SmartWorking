
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Globalization;

namespace SmartWorking.Office.PrimitiveEntities
{
    public static class DBBackupHelper 
    {
        
        
        private static string GetDBValue(string dbString)
        {
        	return (dbString == null) ? "NULL" : string.Format("N'{0}'", dbString);
        }
        
        private static string GetDBValue(int dbInt)
        {
        	return dbInt.ToString();
        }
        
        private static string GetDBValue(int? dbIntNull)
        {
        	return (dbIntNull == null || !dbIntNull.HasValue) ? "NULL" : dbIntNull.Value.ToString();
        }
        
        private static string GetDBValue(double? dbDoubleNull)
        {
        	return (dbDoubleNull == null || !dbDoubleNull.HasValue) ? "NULL" : dbDoubleNull.Value.ToString(new CultureInfo("en-Us"));
        }
        
        private static string GetDBValue(DateTime? dbDateTimeNull)
        {
        	          return (dbDateTimeNull == null || !dbDateTimeNull.HasValue)
                           ? "NULL"
                           : string.Format("CAST(0x{0} AS DateTime)",
                                           ((int)((dbDateTimeNull.Value - new DateTime(1900, 1, 1)).TotalDays)).ToString("X8") +
                                           ((int)Math.Round((dbDateTimeNull.Value - dbDateTimeNull.Value.Date).TotalMilliseconds * 0.3,0)).ToString("X8"));
        }
        
        public static string GetDBInsertQuery(this BuildingPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Buildings] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [InternalName]";
        		values += string.Format(", {0}", GetDBValue(primitive.InternalName));
        
        		result += ", [ZIPCode]";
        		values += string.Format(", {0}", GetDBValue(primitive.ZIPCode));
        
        		result += ", [City]";
        		values += string.Format(", {0}", GetDBValue(primitive.City));
        
        		result += ", [Street]";
        		values += string.Format(", {0}", GetDBValue(primitive.Street));
        
        		result += ", [Phone]";
        		values += string.Format(", {0}", GetDBValue(primitive.Phone));
        
        		result += ", [ContactPerson]";
        		values += string.Format(", {0}", GetDBValue(primitive.ContactPerson));
        
        		result += ", [ContactPersonPhone]";
        		values += string.Format(", {0}", GetDBValue(primitive.ContactPersonPhone));
        
        		result += ", [HouseNo]";
        		values += string.Format(", {0}", GetDBValue(primitive.HouseNo));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this CarPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Cars] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [RegistrationNumber]";
        		values += string.Format(", {0}", GetDBValue(primitive.RegistrationNumber));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        		result += ", [InternalName]";
        		values += string.Format(", {0}", GetDBValue(primitive.InternalName));
        
        		result += ", [CarType]";
        		values += string.Format(", {0}", GetDBValue(primitive.CarType));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Capacity]";
        		values += string.Format(", {0}", GetDBValue(primitive.Capacity));
        
        		result += ", [TransportType]";
        		values += string.Format(", {0}", GetDBValue(primitive.TransportType));
        
        		result += ", [Driver_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Driver_Id));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this ClientPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Clients] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [InternalName]";
        		values += string.Format(", {0}", GetDBValue(primitive.InternalName));
        
        		result += ", [NIP]";
        		values += string.Format(", {0}", GetDBValue(primitive.NIP));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        		result += ", [City]";
        		values += string.Format(", {0}", GetDBValue(primitive.City));
        
        		result += ", [Street]";
        		values += string.Format(", {0}", GetDBValue(primitive.Street));
        
        		result += ", [ZIPCode]";
        		values += string.Format(", {0}", GetDBValue(primitive.ZIPCode));
        
        		result += ", [HouseNo]";
        		values += string.Format(", {0}", GetDBValue(primitive.HouseNo));
        
        		result += ", [Phone]";
        		values += string.Format(", {0}", GetDBValue(primitive.Phone));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this ClientBuildingPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[ClientBuildings] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Client_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Client_Id));
        
        		result += ", [Building_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Building_Id));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this ContractorPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Contractors] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [InternalName]";
        		values += string.Format(", {0}", GetDBValue(primitive.InternalName));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        		result += ", [ZIPCode]";
        		values += string.Format(", {0}", GetDBValue(primitive.ZIPCode));
        
        		result += ", [City]";
        		values += string.Format(", {0}", GetDBValue(primitive.City));
        
        		result += ", [Street]";
        		values += string.Format(", {0}", GetDBValue(primitive.Street));
        
        		result += ", [HouseNo]";
        		values += string.Format(", {0}", GetDBValue(primitive.HouseNo));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Phone]";
        		values += string.Format(", {0}", GetDBValue(primitive.Phone));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this DeliveryNotePrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[DeliveryNotes] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Driver_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Driver_Id));
        
        		result += ", [DateDrawing]";
        		values += string.Format(", {0}", GetDBValue(primitive.DateDrawing));
        
        		result += ", [DateOfArrival]";
        		values += string.Format(", {0}", GetDBValue(primitive.DateOfArrival));
        
        		result += ", [Drawer]";
        		values += string.Format(", {0}", GetDBValue(primitive.Drawer));
        
        		result += ", [Car_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Car_Id));
        
        		result += ", [Amount]";
        		values += string.Format(", {0}", GetDBValue(primitive.Amount));
        
        		result += ", [Order_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Order_Id));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        		result += ", [Number]";
        		values += string.Format(", {0}", GetDBValue(primitive.Number));
        
        		result += ", [Year]";
        		values += string.Format(", {0}", GetDBValue(primitive.Year));
        
        		result += ", [DeactivationReason]";
        		values += string.Format(", {0}", GetDBValue(primitive.DeactivationReason));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this DriverPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Drivers] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        		result += ", [Surname]";
        		values += string.Format(", {0}", GetDBValue(primitive.Surname));
        
        		result += ", [Phone]";
        		values += string.Format(", {0}", GetDBValue(primitive.Phone));
        
        		result += ", [InternalName]";
        		values += string.Format(", {0}", GetDBValue(primitive.InternalName));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this MaterialPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Materials] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        		result += ", [Producer_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Producer_Id));
        
        		result += ", [Deliverer_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deliverer_Id));
        
        		result += ", [InternalName]";
        		values += string.Format(", {0}", GetDBValue(primitive.InternalName));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        		result += ", [MaterialType]";
        		values += string.Format(", {0}", GetDBValue(primitive.MaterialType));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this MaterialStockPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[MaterialStocks] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Material_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Material_Id));
        
        		result += ", [Amount]";
        		values += string.Format(", {0}", GetDBValue(primitive.Amount));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this OrderPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Orders] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Recipe_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Recipe_Id));
        
        		result += ", [ClientBuilding_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.ClientBuilding_Id));
        
        		result += ", [Amount]";
        		values += string.Format(", {0}", GetDBValue(primitive.Amount));
        
        		result += ", [DateOfOrder]";
        		values += string.Format(", {0}", GetDBValue(primitive.DateOfOrder));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        		result += ", [Canceled]";
        		values += string.Format(", {0}", GetDBValue(primitive.Canceled));
        
        		result += ", [Pump]";
        		values += string.Format(", {0}", GetDBValue(primitive.Pump));
        
        		result += ", [Notice]";
        		values += string.Format(", {0}", GetDBValue(primitive.Notice));
        
        		result += ", [PlannedDeliveryTime]";
        		values += string.Format(", {0}", GetDBValue(primitive.PlannedDeliveryTime));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this RecipePrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Recipes] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        		result += ", [InternalName]";
        		values += string.Format(", {0}", GetDBValue(primitive.InternalName));
        
        		result += ", [Number]";
        		values += string.Format(", {0}", GetDBValue(primitive.Number));
        
        		result += ", [Granulation]";
        		values += string.Format(", {0}", GetDBValue(primitive.Granulation));
        
        		result += ", [Consistency]";
        		values += string.Format(", {0}", GetDBValue(primitive.Consistency));
        
        		result += ", [ConcreteClass]";
        		values += string.Format(", {0}", GetDBValue(primitive.ConcreteClass));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        		result += ", [WaterToCement]";
        		values += string.Format(", {0}", GetDBValue(primitive.WaterToCement));
        
        		result += ", [StrengthClass]";
        		values += string.Format(", {0}", GetDBValue(primitive.StrengthClass));
        
        		result += ", [StrengthProgress]";
        		values += string.Format(", {0}", GetDBValue(primitive.StrengthProgress));
        
        		result += ", [Code]";
        		values += string.Format(", {0}", GetDBValue(primitive.Code));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this RecipeComponentPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[RecipeComponents] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Material_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Material_Id));
        
        		result += ", [Recipe_Id]";
        		values += string.Format(", {0}", GetDBValue(primitive.Recipe_Id));
        
        		result += ", [Amount]";
        		values += string.Format(", {0}", GetDBValue(primitive.Amount));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this RolePrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Roles] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
        public static string GetDBInsertQuery(this UserPrimitive primitive)
        {
        		if (primitive == null) return string.Empty;
        		string values = " VALUES (";
        		string result = "INSERT [dbo].[Users] (";
        				result += "[Id]";
        		values += string.Format("{0}", GetDBValue(primitive.Id));
        
        		result += ", [Name]";
        		values += string.Format(", {0}", GetDBValue(primitive.Name));
        
        		result += ", [Surname]";
        		values += string.Format(", {0}", GetDBValue(primitive.Surname));
        
        		result += ", [Password]";
        		values += string.Format(", {0}", GetDBValue(primitive.Password));
        
        		result += ", [PasswordSalz]";
        		values += string.Format(", {0}", GetDBValue(primitive.PasswordSalz));
        
        		result += ", [Phone]";
        		values += string.Format(", {0}", GetDBValue(primitive.Phone));
        
        		result += ", [Deleted]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deleted));
        
        		result += ", [Deactivated]";
        		values += string.Format(", {0}", GetDBValue(primitive.Deactivated));
        
        
        		if (values.Length > 0)
        			return result + ")" + values + ")";
        		else 
        			return string.Empty;
        }
        
    }
}