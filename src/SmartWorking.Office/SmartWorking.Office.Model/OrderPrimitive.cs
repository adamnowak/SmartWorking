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

namespace SmartWorking.Office.PrimitiveEntities
{
    public partial class OrderPrimitive : PrimitiveBase
    {
        #region Primitive Properties
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
    		public Nullable<double> Amount
    		{
            get;
            set;
    		}
    		public Nullable<System.DateTime> DateOfOrder
    		{
            get;
            set;
    		}
    		public Nullable<System.DateTime> Canceled
    		{
            get;
            set;
    		}
    		public Nullable<int> Pump
    		{
            get;
            set;
    		}
    		public string Notice
    		{
            get;
            set;
    		}

        #endregion
    }
    
}
