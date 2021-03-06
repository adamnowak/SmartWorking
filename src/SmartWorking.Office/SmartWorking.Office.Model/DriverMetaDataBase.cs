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

namespace SmartWorking.Office.PrimitiveEntities.MetaDates
{
    
    
    public class DriverMetaDataBase
    {
        [Required]
        public virtual int Id
        {
            get;
            set;
        }
    	
        [StringLength(70, ErrorMessage="Ce champ ne peut depasser 70 caracteres")]
        public virtual string Name
        {
            get;
            set;
        }
    	
        [StringLength(100, ErrorMessage="Ce champ ne peut depasser 100 caracteres")]
        public virtual string Surname
        {
            get;
            set;
        }
    	
        [StringLength(20, ErrorMessage="Ce champ ne peut depasser 20 caracteres")]
        public virtual string Phone
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessage="Ce champ ne peut depasser 50 caracteres")]
        public virtual string InternalName
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
