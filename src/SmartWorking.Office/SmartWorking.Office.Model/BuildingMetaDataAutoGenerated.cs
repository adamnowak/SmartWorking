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
    
    
    public class BuildingMetaData
    {
        [Required]
        public virtual int Id
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_InternalName_StringLength_50")]
        public virtual string InternalName
        {
            get;
            set;
        }
    	
        [StringLength(10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_ZIPCode_StringLength_10")]
        public virtual string ZIPCode
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_City_StringLength_70")]
        public virtual string City
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_Street_StringLength_70")]
        public virtual string Street
        {
            get;
            set;
        }
    	
        [StringLength(20, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_Phone_StringLength_20")]
        public virtual string Phone
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_ContactPerson_StringLength_70")]
        public virtual string ContactPerson
        {
            get;
            set;
        }
    	
        [StringLength(20, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_ContactPersonPhone_StringLength_20")]
        public virtual string ContactPersonPhone
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_HouseNo_StringLength_50")]
        public virtual string HouseNo
        {
            get;
            set;
        }
        public virtual Nullable<System.DateTime> Deleted
        {
            get;
            set;
        }
        public virtual Nullable<System.DateTime> Deactivated
        {
            get;
            set;
        }
    	
        [StringLength(150, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BuildingMetaData_Name_StringLength_150")]
        public virtual string Name
        {
            get;
            set;
        }
    }
}
