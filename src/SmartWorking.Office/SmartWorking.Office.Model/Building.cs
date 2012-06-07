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

namespace SmartWorking.Office.Entities
{
    public partial class Building
    {
        #region Primitive Properties
    
        public int Id
        {
            get;
            set;
        }
    
        public int Contractor_Id
        {
            get { return _contractor_Id; }
            set
            {
                if (_contractor_Id != value)
                {
                    if (Contractor != null && Contractor.Id != value)
                    {
                        Contractor = null;
                    }
                    _contractor_Id = value;
                }
            }
        }
        private int _contractor_Id;
    
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
        #region Navigation Properties
    
        public Contractor Contractor
        {
            get { return _contractor; }
            set
            {
                if (!ReferenceEquals(_contractor, value))
                {
                    var previousValue = _contractor;
                    _contractor = value;
                    FixupContractor(previousValue);
                }
            }
        }
        private Contractor _contractor;
    
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
    
        private void FixupContractor(Contractor previousValue)
        {
            if (previousValue != null && previousValue.Buildings.Contains(this))
            {
                previousValue.Buildings.Remove(this);
            }
    
            if (Contractor != null)
            {
                if (!Contractor.Buildings.Contains(this))
                {
                    Contractor.Buildings.Add(this);
                }
                if (Contractor_Id != Contractor.Id)
                {
                    Contractor_Id = Contractor.Id;
                }
            }
        }
    
        private void FixupDeliveryNotes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (DeliveryNote item in e.NewItems)
                {
                    item.Building = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DeliveryNote item in e.OldItems)
                {
                    if (ReferenceEquals(item.Building, this))
                    {
                        item.Building = null;
                    }
                }
            }
        }

        #endregion
    }
}
