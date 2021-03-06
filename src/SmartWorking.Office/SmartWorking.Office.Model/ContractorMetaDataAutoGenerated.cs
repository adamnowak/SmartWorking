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
    
    
    public class ContractorMetaData
    {
        [Required]
        public virtual int Id
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ContractorMetaData_InternalName_StringLength_50")]
        public virtual string InternalName
        {
            get;
            set;
        }
    	
        [StringLength(150, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ContractorMetaData_Name_StringLength_150")]
        public virtual string Name
        {
            get;
            set;
        }
    	
        [StringLength(10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ContractorMetaData_ZIPCode_StringLength_10")]
        public virtual string ZIPCode
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ContractorMetaData_City_StringLength_70")]
        public virtual string City
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ContractorMetaData_Street_StringLength_70")]
        public virtual string Street
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ContractorMetaData_HouseNo_StringLength_50")]
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
    	
        [StringLength(10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ContractorMetaData_Phone_StringLength_10")]
        public virtual string Phone
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
