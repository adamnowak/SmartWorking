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
    
    
    public class UserMetaData
    {
        [Required]
        public virtual int Id
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserMetaData_Name_StringLength_70")]
        public virtual string Name
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserMetaData_Surname_StringLength_70")]
        public virtual string Surname
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserMetaData_Password_StringLength_70")]
        public virtual string Password
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserMetaData_PasswordSalz_StringLength_70")]
        public virtual string PasswordSalz
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserMetaData_Phone_StringLength_50")]
        public virtual string Phone
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
    }
}
