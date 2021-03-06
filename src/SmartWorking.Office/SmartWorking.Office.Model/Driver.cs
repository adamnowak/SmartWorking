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
    public partial class Driver : DriverPrimitive
    {
        #region Navigation Properties
    
        public ICollection<Car> Cars
        {
            get
            {
                if (_cars == null)
                {
                    var newCollection = new FixupCollection<Car>();
                    newCollection.CollectionChanged += FixupCars;
                    _cars = newCollection;
                }
                return _cars;
            }
            set
            {
                if (!ReferenceEquals(_cars, value))
                {
                    var previousValue = _cars as FixupCollection<Car>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCars;
                    }
                    _cars = value;
                    var newValue = value as FixupCollection<Car>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCars;
                    }
                }
            }
        }
        private ICollection<Car> _cars;
    
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
    
        private void FixupCars(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Car item in e.NewItems)
                {
                    item.Driver = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Car item in e.OldItems)
                {
                    if (ReferenceEquals(item.Driver, this))
                    {
                        item.Driver = null;
                    }
                }
            }
        }
    
        private void FixupDeliveryNotes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (DeliveryNote item in e.NewItems)
                {
                    item.Driver = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DeliveryNote item in e.OldItems)
                {
                    if (ReferenceEquals(item.Driver, this))
                    {
                        item.Driver = null;
                    }
                }
            }
        }

        #endregion
    }
}
