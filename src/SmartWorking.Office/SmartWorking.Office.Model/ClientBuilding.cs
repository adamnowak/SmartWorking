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
    public partial class ClientBuilding : ClientBuildingPrimitive
    {
        #region Primitive Properties
    		public override Nullable<int> Client_Id
    		{
            get { return _client_Id; }
            set
            {        
                try
                {
                    _settingFK = true;
                    if (_client_Id != value)
                    {
                        if (Client != null && Client.Id != value)
                        {
                            Client = null;
                        }
                        _client_Id = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    		}
    		private Nullable<int> _client_Id;    
    
    		public override Nullable<int> Building_Id
    		{
            get { return _building_Id; }
            set
            {        
                try
                {
                    _settingFK = true;
                    if (_building_Id != value)
                    {
                        if (Building != null && Building.Id != value)
                        {
                            Building = null;
                        }
                        _building_Id = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    		}
    		private Nullable<int> _building_Id;    
    

        #endregion
        #region Navigation Properties
    
        public Building Building
        {
            get { return _building; }
            set
            {
                if (!ReferenceEquals(_building, value))
                {
                    var previousValue = _building;
                    _building = value;
                    FixupBuilding(previousValue);
                }
            }
        }
        private Building _building;
    
        public Client Client
        {
            get { return _client; }
            set
            {
                if (!ReferenceEquals(_client, value))
                {
                    var previousValue = _client;
                    _client = value;
                    FixupClient(previousValue);
                }
            }
        }
        private Client _client;
    
        public ICollection<Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    var newCollection = new FixupCollection<Order>();
                    newCollection.CollectionChanged += FixupOrders;
                    _orders = newCollection;
                }
                return _orders;
            }
            set
            {
                if (!ReferenceEquals(_orders, value))
                {
                    var previousValue = _orders as FixupCollection<Order>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupOrders;
                    }
                    _orders = value;
                    var newValue = value as FixupCollection<Order>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupOrders;
                    }
                }
            }
        }
        private ICollection<Order> _orders;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupBuilding(Building previousValue)
        {
            if (previousValue != null && previousValue.ClientBuildings.Contains(this))
            {
                previousValue.ClientBuildings.Remove(this);
            }
    
            if (Building != null)
            {
                if (!Building.ClientBuildings.Contains(this))
                {
                    Building.ClientBuildings.Add(this);
                }
                if (Building_Id != Building.Id)
                {
                    Building_Id = Building.Id;
                }
            }
            else if (!_settingFK)
            {
                Building_Id = null;
            }
        }
    
        private void FixupClient(Client previousValue)
        {
            if (previousValue != null && previousValue.ClientBuildings.Contains(this))
            {
                previousValue.ClientBuildings.Remove(this);
            }
    
            if (Client != null)
            {
                if (!Client.ClientBuildings.Contains(this))
                {
                    Client.ClientBuildings.Add(this);
                }
                if (Client_Id != Client.Id)
                {
                    Client_Id = Client.Id;
                }
            }
            else if (!_settingFK)
            {
                Client_Id = null;
            }
        }
    
        private void FixupOrders(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Order item in e.NewItems)
                {
                    item.ClientBuilding = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Order item in e.OldItems)
                {
                    if (ReferenceEquals(item.ClientBuilding, this))
                    {
                        item.ClientBuilding = null;
                    }
                }
            }
        }

        #endregion
    }
}
