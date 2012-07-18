
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
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Entities
{
    public static class GetPrimitiveHelper 
    {
        public static BuildingPrimitive GetPrimitive(this Building entity)
        {
        		BuildingPrimitive primitive = new BuildingPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Client_Id = entity.Client_Id;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		primitive.ZIPCode = entity.ZIPCode;
        		
        		primitive.City = entity.City;
        		
        		primitive.Street = entity.Street;
        		
        		primitive.Phone = entity.Phone;
        		
        		primitive.ContactPerson = entity.ContactPerson;
        		
        		primitive.ContactPersonPhone = entity.ContactPersonPhone;
        		
        		primitive.HouseNo = entity.HouseNo;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		primitive.IsActive = entity.IsActive;
        		
        		return primitive;
        }
        
        public static CarPrimitive GetPrimitive(this Car entity)
        {
        		CarPrimitive primitive = new CarPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.RegistrationNumber = entity.RegistrationNumber;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		primitive.CarType = entity.CarType;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		primitive.Capacity = entity.Capacity;
        		
        		primitive.TransportType = entity.TransportType;
        		
        		primitive.Driver_Id = entity.Driver_Id;
        		
        		primitive.IsActive = entity.IsActive;
        		
        		return primitive;
        }
        
        public static ClientPrimitive GetPrimitive(this Client entity)
        {
        		ClientPrimitive primitive = new ClientPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		primitive.NIP = entity.NIP;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.City = entity.City;
        		
        		primitive.Street = entity.Street;
        		
        		primitive.ZIPCode = entity.ZIPCode;
        		
        		primitive.HouseNo = entity.HouseNo;
        		
        		primitive.Phone = entity.Phone;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		primitive.IsActive = entity.IsActive;
        		
        		return primitive;
        }
        
        public static ContractorPrimitive GetPrimitive(this Contractor entity)
        {
        		ContractorPrimitive primitive = new ContractorPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.ZIPCode = entity.ZIPCode;
        		
        		primitive.City = entity.City;
        		
        		primitive.Street = entity.Street;
        		
        		primitive.HouseNo = entity.HouseNo;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		primitive.Phone = entity.Phone;
        		
        		return primitive;
        }
        
        public static DeliveryNotePrimitive GetPrimitive(this DeliveryNote entity)
        {
        		DeliveryNotePrimitive primitive = new DeliveryNotePrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Driver_Id = entity.Driver_Id;
        		
        		primitive.DateDrawing = entity.DateDrawing;
        		
        		primitive.DateOfArrival = entity.DateOfArrival;
        		
        		primitive.Canceled = entity.Canceled;
        		
        		primitive.Drawer = entity.Drawer;
        		
        		primitive.Car_Id = entity.Car_Id;
        		
        		primitive.Amount = entity.Amount;
        		
        		primitive.Order_Id = entity.Order_Id;
        		
        		return primitive;
        }
        
        public static DriverPrimitive GetPrimitive(this Driver entity)
        {
        		DriverPrimitive primitive = new DriverPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.Surname = entity.Surname;
        		
        		primitive.Phone = entity.Phone;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		return primitive;
        }
        
        public static MaterialPrimitive GetPrimitive(this Material entity)
        {
        		MaterialPrimitive primitive = new MaterialPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.Producer_Id = entity.Producer_Id;
        		
        		primitive.Deliverer_Id = entity.Deliverer_Id;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		return primitive;
        }
        
        public static MaterialStockPrimitive GetPrimitive(this MaterialStock entity)
        {
        		MaterialStockPrimitive primitive = new MaterialStockPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Material_Id = entity.Material_Id;
        		
        		primitive.Amount = entity.Amount;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		return primitive;
        }
        
        public static OrderPrimitive GetPrimitive(this Order entity)
        {
        		OrderPrimitive primitive = new OrderPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Recipe_Id = entity.Recipe_Id;
        		
        		primitive.Building_Id = entity.Building_Id;
        		
        		primitive.Amount = entity.Amount;
        		
        		primitive.DateOfOrder = entity.DateOfOrder;
        		
        		primitive.Canceled = entity.Canceled;
        		
        		return primitive;
        }
        
        public static RecipePrimitive GetPrimitive(this Recipe entity)
        {
        		RecipePrimitive primitive = new RecipePrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		primitive.Number = entity.Number;
        		
        		primitive.Granulation = entity.Granulation;
        		
        		primitive.Consistency = entity.Consistency;
        		
        		primitive.ConcreteClass = entity.ConcreteClass;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		primitive.IsActive = entity.IsActive;
        		
        		return primitive;
        }
        
        public static RecipeComponentPrimitive GetPrimitive(this RecipeComponent entity)
        {
        		RecipeComponentPrimitive primitive = new RecipeComponentPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Material_Id = entity.Material_Id;
        		
        		primitive.Recipe_Id = entity.Recipe_Id;
        		
        		primitive.Amount = entity.Amount;
        		
        		primitive.Deleted = entity.Deleted;
        		
        		return primitive;
        }
        
    }
}
