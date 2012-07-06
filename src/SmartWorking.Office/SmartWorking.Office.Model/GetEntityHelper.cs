
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
    public static class GetEntityHelper 
    {
        public static Building GetEntity(this BuildingPrimitive primitive)
        {
        		Building result = new Building(); 
        
        		result.Id = primitive.Id;
        		
        		result.Client_Id = primitive.Client_Id;
        		
        		result.InternalName = primitive.InternalName;
        		
        		result.ZIPCode = primitive.ZIPCode;
        		
        		result.City = primitive.City;
        		
        		result.Street = primitive.Street;
        		
        		result.Phone = primitive.Phone;
        		
        		result.ContactPerson = primitive.ContactPerson;
        		
        		result.ContactPersonPhone = primitive.ContactPersonPhone;
        		
        		result.HouseNo = primitive.HouseNo;
        		
        		result.Deleted = primitive.Deleted;
        		
        		return result;
        }
        
        public static Car GetEntity(this CarPrimitive primitive)
        {
        		Car result = new Car(); 
        
        		result.Id = primitive.Id;
        		
        		result.RegistrationNumber = primitive.RegistrationNumber;
        		
        		result.Name = primitive.Name;
        		
        		result.InternalName = primitive.InternalName;
        		
        		result.CarType = primitive.CarType;
        		
        		result.Deleted = primitive.Deleted;
        		
        		result.Capacity = primitive.Capacity;
        		
        		result.TransportType = primitive.TransportType;
        		
        		return result;
        }
        
        public static Client GetEntity(this ClientPrimitive primitive)
        {
        		Client result = new Client(); 
        
        		result.Id = primitive.Id;
        		
        		result.InternalName = primitive.InternalName;
        		
        		result.NIP = primitive.NIP;
        		
        		result.Name = primitive.Name;
        		
        		result.City = primitive.City;
        		
        		result.Street = primitive.Street;
        		
        		result.ZIPCode = primitive.ZIPCode;
        		
        		result.HouseNo = primitive.HouseNo;
        		
        		result.Phone = primitive.Phone;
        		
        		result.Deleted = primitive.Deleted;
        		
        		return result;
        }
        
        public static Contractor GetEntity(this ContractorPrimitive primitive)
        {
        		Contractor result = new Contractor(); 
        
        		result.Id = primitive.Id;
        		
        		result.InternalName = primitive.InternalName;
        		
        		result.Name = primitive.Name;
        		
        		result.ZIPCode = primitive.ZIPCode;
        		
        		result.City = primitive.City;
        		
        		result.Street = primitive.Street;
        		
        		result.HouseNo = primitive.HouseNo;
        		
        		result.Deleted = primitive.Deleted;
        		
        		result.Phone = primitive.Phone;
        		
        		return result;
        }
        
        public static DeliveryNote GetEntity(this DeliveryNotePrimitive primitive)
        {
        		DeliveryNote result = new DeliveryNote(); 
        
        		result.Id = primitive.Id;
        		
        		result.Driver_Id = primitive.Driver_Id;
        		
        		result.DateDrawing = primitive.DateDrawing;
        		
        		result.DateOfArrival = primitive.DateOfArrival;
        		
        		result.Canceled = primitive.Canceled;
        		
        		result.Drawer = primitive.Drawer;
        		
        		result.Car_Id = primitive.Car_Id;
        		
        		result.Amount = primitive.Amount;
        		
        		result.Order_Id = primitive.Order_Id;
        		
        		return result;
        }
        
        public static Driver GetEntity(this DriverPrimitive primitive)
        {
        		Driver result = new Driver(); 
        
        		result.Id = primitive.Id;
        		
        		result.Name = primitive.Name;
        		
        		result.Surname = primitive.Surname;
        		
        		result.Phone = primitive.Phone;
        		
        		result.InternalName = primitive.InternalName;
        		
        		result.Car_Id = primitive.Car_Id;
        		
        		result.Deleted = primitive.Deleted;
        		
        		return result;
        }
        
        public static Material GetEntity(this MaterialPrimitive primitive)
        {
        		Material result = new Material(); 
        
        		result.Id = primitive.Id;
        		
        		result.Name = primitive.Name;
        		
        		result.Producer_Id = primitive.Producer_Id;
        		
        		result.Deliverer_Id = primitive.Deliverer_Id;
        		
        		result.InternalName = primitive.InternalName;
        		
        		result.Deleted = primitive.Deleted;
        		
        		return result;
        }
        
        public static MaterialStock GetEntity(this MaterialStockPrimitive primitive)
        {
        		MaterialStock result = new MaterialStock(); 
        
        		result.Id = primitive.Id;
        		
        		result.Material_Id = primitive.Material_Id;
        		
        		result.Amount = primitive.Amount;
        		
        		result.Deleted = primitive.Deleted;
        		
        		return result;
        }
        
        public static Order GetEntity(this OrderPrimitive primitive)
        {
        		Order result = new Order(); 
        
        		result.Id = primitive.Id;
        		
        		result.Recipe_Id = primitive.Recipe_Id;
        		
        		result.Building_Id = primitive.Building_Id;
        		
        		result.Amount = primitive.Amount;
        		
        		result.DateOfOrder = primitive.DateOfOrder;
        		
        		result.Canceled = primitive.Canceled;
        		
        		return result;
        }
        
        public static Recipe GetEntity(this RecipePrimitive primitive)
        {
        		Recipe result = new Recipe(); 
        
        		result.Id = primitive.Id;
        		
        		result.Name = primitive.Name;
        		
        		result.InternalName = primitive.InternalName;
        		
        		result.Number = primitive.Number;
        		
        		result.Granulation = primitive.Granulation;
        		
        		result.Consistency = primitive.Consistency;
        		
        		result.ConcreteClass = primitive.ConcreteClass;
        		
        		result.Deleted = primitive.Deleted;
        		
        		return result;
        }
        
        public static RecipeComponent GetEntity(this RecipeComponentPrimitive primitive)
        {
        		RecipeComponent result = new RecipeComponent(); 
        
        		result.Id = primitive.Id;
        		
        		result.Material_Id = primitive.Material_Id;
        		
        		result.Recipe_Id = primitive.Recipe_Id;
        		
        		result.Amount = primitive.Amount;
        		
        		result.Deleted = primitive.Deleted;
        		
        		return result;
        }
        
    }
}
