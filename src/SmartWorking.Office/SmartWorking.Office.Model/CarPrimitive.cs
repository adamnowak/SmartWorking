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
    public partial class CarPrimitive : PrimitiveBase
    {
        #region Primitive Properties
    		public string RegistrationNumber
    		{
            get;
            set;
    		}
    		public string Name
    		{
            get;
            set;
    		}
    		public string InternalName
    		{
            get;
            set;
    		}
    		public Nullable<int> CarType
    		{
            get;
            set;
    		}
    		public Nullable<double> Capacity
    		{
            get;
            set;
    		}
    		public Nullable<int> TransportType
    		{
            get;
            set;
    		}
    		public virtual Nullable<int> Driver_Id
    		{
    			get;
    			set;
    		}

        #endregion
    }
    
}
