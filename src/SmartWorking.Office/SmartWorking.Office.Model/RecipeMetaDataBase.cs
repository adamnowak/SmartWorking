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
    
    
    public class RecipeMetaDataBase
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
    	
        [StringLength(50, ErrorMessage="Ce champ ne peut depasser 50 caracteres")]
        public virtual string InternalName
        {
            get;
            set;
        }
    	
        [StringLength(10, ErrorMessage="Ce champ ne peut depasser 10 caracteres")]
        public virtual string Number
        {
            get;
            set;
        }
    	
        [StringLength(10, ErrorMessage="Ce champ ne peut depasser 10 caracteres")]
        public virtual string Granulation
        {
            get;
            set;
        }
    	
        [StringLength(10, ErrorMessage="Ce champ ne peut depasser 10 caracteres")]
        public virtual string Consistency
        {
            get;
            set;
        }
    	
        [StringLength(10, ErrorMessage="Ce champ ne peut depasser 10 caracteres")]
        public virtual string ConcreteClass
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
    	
        [StringLength(20, ErrorMessage="Ce champ ne peut depasser 20 caracteres")]
        public virtual string WaterToCement
        {
            get;
            set;
        }
    	
        [StringLength(20, ErrorMessage="Ce champ ne peut depasser 20 caracteres")]
        public virtual string StrengthClass
        {
            get;
            set;
        }
        public virtual Nullable<int> StrengthProgress
        {
            get;
            set;
        }
    	
        [StringLength(20, ErrorMessage="Ce champ ne peut depasser 20 caracteres")]
        public virtual string Code
        {
            get;
            set;
        }
    }
}
