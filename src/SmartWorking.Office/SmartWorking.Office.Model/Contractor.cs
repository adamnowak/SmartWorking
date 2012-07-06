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
    public partial class Contractor : ContractorPrimitive
    {
        #region Navigation Properties
    
        public ICollection<Material> MaterialFromDeliverer
        {
            get
            {
                if (_materialFromDeliverer == null)
                {
                    var newCollection = new FixupCollection<Material>();
                    newCollection.CollectionChanged += FixupMaterialFromDeliverer;
                    _materialFromDeliverer = newCollection;
                }
                return _materialFromDeliverer;
            }
            set
            {
                if (!ReferenceEquals(_materialFromDeliverer, value))
                {
                    var previousValue = _materialFromDeliverer as FixupCollection<Material>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMaterialFromDeliverer;
                    }
                    _materialFromDeliverer = value;
                    var newValue = value as FixupCollection<Material>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMaterialFromDeliverer;
                    }
                }
            }
        }
        private ICollection<Material> _materialFromDeliverer;
    
        public ICollection<Material> MaterialFromProducer
        {
            get
            {
                if (_materialFromProducer == null)
                {
                    var newCollection = new FixupCollection<Material>();
                    newCollection.CollectionChanged += FixupMaterialFromProducer;
                    _materialFromProducer = newCollection;
                }
                return _materialFromProducer;
            }
            set
            {
                if (!ReferenceEquals(_materialFromProducer, value))
                {
                    var previousValue = _materialFromProducer as FixupCollection<Material>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMaterialFromProducer;
                    }
                    _materialFromProducer = value;
                    var newValue = value as FixupCollection<Material>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMaterialFromProducer;
                    }
                }
            }
        }
        private ICollection<Material> _materialFromProducer;

        #endregion
        #region Association Fixup
    
        private void FixupMaterialFromDeliverer(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Material item in e.NewItems)
                {
                    item.Deliverer = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Material item in e.OldItems)
                {
                    if (ReferenceEquals(item.Deliverer, this))
                    {
                        item.Deliverer = null;
                    }
                }
            }
        }
    
        private void FixupMaterialFromProducer(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Material item in e.NewItems)
                {
                    item.Producer = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Material item in e.OldItems)
                {
                    if (ReferenceEquals(item.Producer, this))
                    {
                        item.Producer = null;
                    }
                }
            }
        }

        #endregion
    }
}
