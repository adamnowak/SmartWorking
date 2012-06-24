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
using SmartWorking.Office.PrimitiveEntities;

namespace SmartWorking.Office.Entities
{
    public partial class MaterialStock : MaterialStockPrimitive
    {
        #region Primitive Properties
    		public override Nullable<int> Material_Id
    		{
            get { return _material_Id; }
            set
            {        
                try
                {
                    _settingFK = true;
                    if (_material_Id != value)
                    {
                        if (Material != null && Material.Id != value)
                        {
                            Material = null;
                        }
                        _material_Id = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    		}
    		private Nullable<int> _material_Id;    
    

        #endregion
        #region Navigation Properties
    
        public Material Material
        {
            get { return _material; }
            set
            {
                if (!ReferenceEquals(_material, value))
                {
                    var previousValue = _material;
                    _material = value;
                    FixupMaterial(previousValue);
                }
            }
        }
        private Material _material;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupMaterial(Material previousValue)
        {
            if (previousValue != null && previousValue.MaterialStocks.Contains(this))
            {
                previousValue.MaterialStocks.Remove(this);
            }
    
            if (Material != null)
            {
                if (!Material.MaterialStocks.Contains(this))
                {
                    Material.MaterialStocks.Add(this);
                }
                if (Material_Id != Material.Id)
                {
                    Material_Id = Material.Id;
                }
            }
            else if (!_settingFK)
            {
                Material_Id = null;
            }
        }

        #endregion
    }
}
