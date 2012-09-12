//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template made by Louis-Guillaume Morand.
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
using System.ComponentModel.DataAnnotations;
using SmartWorking.Office.PrimitiveEntities.Properties;

namespace SmartWorking.Office.PrimitiveEntities.MetaDates
{
    
    
    public class CarMetaData
    {
        [Required]
        public virtual int Id
        {
            get;
            set;
        }
    	
        [StringLength(20, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CarMetaData_RegistrationNumber_StringLength_20")]
        public virtual string RegistrationNumber
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CarMetaData_Name_StringLength_50")]
        public virtual string Name
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CarMetaData_InternalName_StringLength_50")]
        public virtual string InternalName
        {
            get;
            set;
        }
        public virtual Nullable<int> CarType
        {
            get;
            set;
        }
        public virtual Nullable<System.DateTime> Deleted
        {
            get;
            set;
        }
        public virtual Nullable<double> Capacity
        {
            get;
            set;
        }
        public virtual Nullable<int> TransportType
        {
            get;
            set;
        }
        public virtual Nullable<int> Driver_Id
        {
            get;
            set;
    
        }
        public virtual Nullable<System.DateTime> Deactivated
        {
            get;
            set;
        }
    }
}