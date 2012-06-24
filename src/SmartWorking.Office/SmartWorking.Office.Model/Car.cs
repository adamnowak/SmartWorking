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
    public partial class Car : CarPrimitive
    {
        #region Navigation Properties
    
        public ICollection<DeliveryNote> DeliveryNotes
        {
            get
            {
                if (_deliveryNotes == null)
                {
                    var newCollection = new FixupCollection<DeliveryNote>();
                    newCollection.CollectionChanged += FixupDeliveryNotes;
                    _deliveryNotes = newCollection;
                }
                return _deliveryNotes;
            }
            set
            {
                if (!ReferenceEquals(_deliveryNotes, value))
                {
                    var previousValue = _deliveryNotes as FixupCollection<DeliveryNote>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupDeliveryNotes;
                    }
                    _deliveryNotes = value;
                    var newValue = value as FixupCollection<DeliveryNote>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupDeliveryNotes;
                    }
                }
            }
        }
        private ICollection<DeliveryNote> _deliveryNotes;

        #endregion
        #region Association Fixup
    
        private void FixupDeliveryNotes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (DeliveryNote item in e.NewItems)
                {
                    item.Car = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DeliveryNote item in e.OldItems)
                {
                    if (ReferenceEquals(item.Car, this))
                    {
                        item.Car = null;
                    }
                }
            }
        }

        #endregion
    }
}
