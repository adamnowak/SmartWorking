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
    public partial class BuildingPrimitive : IPrimitive
    {
        #region Primitive Properties
    		public int Id
    		{
            get;
            set;
    		}
    		public virtual int Contractor_Id
    		{
    			get;
    			set;
    		}
    		public string City
    		{
            get;
            set;
    		}
    		public string Street
    		{
            get;
            set;
    		}
    		public string HouseNo
    		{
            get;
            set;
    		}

        #endregion
    }
    
}
