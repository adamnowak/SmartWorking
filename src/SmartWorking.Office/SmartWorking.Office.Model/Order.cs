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
    public partial class Order : OrderPrimitive
    {
        #region Primitive Properties
    		public override Nullable<int> Recipes_Id
    		{
            get { return _recipes_Id; }
            set
            {        
                try
                {
                    _settingFK = true;
                    if (_recipes_Id != value)
                    {
                        if (Recipe != null && Recipe.Id != value)
                        {
                            Recipe = null;
                        }
                        _recipes_Id = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
    		}
    		private Nullable<int> _recipes_Id;    
    
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
    
        public Recipe Recipe
        {
            get { return _recipe; }
            set
            {
                if (!ReferenceEquals(_recipe, value))
                {
                    var previousValue = _recipe;
                    _recipe = value;
                    FixupRecipe(previousValue);
                }
            }
        }
        private Recipe _recipe;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupBuilding(Building previousValue)
        {
            if (previousValue != null && previousValue.Orders.Contains(this))
            {
                previousValue.Orders.Remove(this);
            }
    
            if (Building != null)
            {
                if (!Building.Orders.Contains(this))
                {
                    Building.Orders.Add(this);
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
    
        private void FixupRecipe(Recipe previousValue)
        {
            if (previousValue != null && previousValue.Orders.Contains(this))
            {
                previousValue.Orders.Remove(this);
            }
    
            if (Recipe != null)
            {
                if (!Recipe.Orders.Contains(this))
                {
                    Recipe.Orders.Add(this);
                }
                if (Recipes_Id != Recipe.Id)
                {
                    Recipes_Id = Recipe.Id;
                }
            }
            else if (!_settingFK)
            {
                Recipes_Id = null;
            }
        }
    
        private void FixupDeliveryNotes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (DeliveryNote item in e.NewItems)
                {
                    item.Order = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (DeliveryNote item in e.OldItems)
                {
                    if (ReferenceEquals(item.Order, this))
                    {
                        item.Order = null;
                    }
                }
            }
        }

        #endregion
    }
}
