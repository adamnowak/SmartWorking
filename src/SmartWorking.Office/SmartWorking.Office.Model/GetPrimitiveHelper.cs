
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

namespace SmartWorking.Office.Entities
{
    public static class GetPrimitiveHelper 
    {
        public static BuildingPrimitive GetPrimitive(this Building entity)
        {
        		BuildingPrimitive primitive = new BuildingPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Contractor_Id = entity.Contractor_Id;
        		
        		primitive.City = entity.City;
        		
        		primitive.Street = entity.Street;
        		
        		primitive.HouseNo = entity.HouseNo;
        		
        		return primitive;
        }
        
        public static CarPrimitive GetPrimitive(this Car entity)
        {
        		CarPrimitive primitive = new CarPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.RegistrationNumber = entity.RegistrationNumber;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		return primitive;
        }
        
        public static ContractorPrimitive GetPrimitive(this Contractor entity)
        {
        		ContractorPrimitive primitive = new ContractorPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.FullName = entity.FullName;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.Surname = entity.Surname;
        		
        		primitive.Phone = entity.Phone;
        		
        		return primitive;
        }
        
        public static DeliveryNotePrimitive GetPrimitive(this DeliveryNote entity)
        {
        		DeliveryNotePrimitive primitive = new DeliveryNotePrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Building_Id = entity.Building_Id;
        		
        		primitive.Recipe_Id = entity.Recipe_Id;
        		
        		primitive.Amount = entity.Amount;
        		
        		primitive.Driver_Id = entity.Driver_Id;
        		
        		primitive.DateDrawing = entity.DateDrawing;
        		
        		primitive.DateOfArrival = entity.DateOfArrival;
        		
        		primitive.Canceled = entity.Canceled;
        		
        		primitive.Drawer = entity.Drawer;
        		
        		primitive.Car_Id = entity.Car_Id;
        		
        		return primitive;
        }
        
        public static DriverPrimitive GetPrimitive(this Driver entity)
        {
        		DriverPrimitive primitive = new DriverPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.Surname = entity.Surname;
        		
        		primitive.Phone = entity.Phone;
        		
        		return primitive;
        }
        
        public static MaterialPrimitive GetPrimitive(this Material entity)
        {
        		MaterialPrimitive primitive = new MaterialPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		return primitive;
        }
        
        public static MaterialStockPrimitive GetPrimitive(this MaterialStock entity)
        {
        		MaterialStockPrimitive primitive = new MaterialStockPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Material_Id = entity.Material_Id;
        		
        		primitive.Amount = entity.Amount;
        		
        		return primitive;
        }
        
        public static RecipePrimitive GetPrimitive(this Recipe entity)
        {
        		RecipePrimitive primitive = new RecipePrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Name = entity.Name;
        		
        		primitive.InternalName = entity.InternalName;
        		
        		return primitive;
        }
        
        public static RecipeComponentPrimitive GetPrimitive(this RecipeComponent entity)
        {
        		RecipeComponentPrimitive primitive = new RecipeComponentPrimitive(); 
        
        		primitive.Id = entity.Id;
        		
        		primitive.Material_Id = entity.Material_Id;
        		
        		primitive.Recipe_Id = entity.Recipe_Id;
        		
        		primitive.Amount = entity.Amount;
        		
        		return primitive;
        }
        
    }
}
