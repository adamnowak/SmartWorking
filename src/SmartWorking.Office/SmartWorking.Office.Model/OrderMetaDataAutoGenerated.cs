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
    
    
    public class OrderMetaData
    {
        [Required]
        public virtual int Id
        {
            get;
            set;
        }
        public virtual Nullable<int> Recipe_Id
        {
            get;
            set;
    
        }
        public virtual Nullable<int> ClientBuilding_Id
        {
            get;
            set;
    
        }
        public virtual Nullable<double> Amount
        {
            get;
            set;
        }
        public virtual Nullable<System.DateTime> DateOfOrder
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
        public virtual Nullable<System.DateTime> Canceled
        {
            get;
            set;
        }
        public virtual Nullable<int> Pump
        {
            get;
            set;
        }
        public virtual string Notice
        {
            get;
            set;
        }
        public virtual Nullable<System.DateTime> PlannedDeliveryTime
        {
            get;
            set;
        }
    }
}
