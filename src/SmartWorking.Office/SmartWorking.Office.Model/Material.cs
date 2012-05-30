//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace SmartWorking.Office.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(MaterialStock))]
    [KnownType(typeof(RecipeSpecification))]
    public partial class Material: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public string InternalName
        {
            get { return _internalName; }
            set
            {
                if (_internalName != value)
                {
                    _internalName = value;
                    OnPropertyChanged("InternalName");
                }
            }
        }
        private string _internalName;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<MaterialStock> MaterialStocks
        {
            get
            {
                if (_materialStocks == null)
                {
                    _materialStocks = new TrackableCollection<MaterialStock>();
                    _materialStocks.CollectionChanged += FixupMaterialStocks;
                }
                return _materialStocks;
            }
            set
            {
                if (!ReferenceEquals(_materialStocks, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_materialStocks != null)
                    {
                        _materialStocks.CollectionChanged -= FixupMaterialStocks;
                    }
                    _materialStocks = value;
                    if (_materialStocks != null)
                    {
                        _materialStocks.CollectionChanged += FixupMaterialStocks;
                    }
                    OnNavigationPropertyChanged("MaterialStocks");
                }
            }
        }
        private TrackableCollection<MaterialStock> _materialStocks;
    
        [DataMember]
        public TrackableCollection<RecipeSpecification> RecipeSpecifications
        {
            get
            {
                if (_recipeSpecifications == null)
                {
                    _recipeSpecifications = new TrackableCollection<RecipeSpecification>();
                    _recipeSpecifications.CollectionChanged += FixupRecipeSpecifications;
                }
                return _recipeSpecifications;
            }
            set
            {
                if (!ReferenceEquals(_recipeSpecifications, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_recipeSpecifications != null)
                    {
                        _recipeSpecifications.CollectionChanged -= FixupRecipeSpecifications;
                    }
                    _recipeSpecifications = value;
                    if (_recipeSpecifications != null)
                    {
                        _recipeSpecifications.CollectionChanged += FixupRecipeSpecifications;
                    }
                    OnNavigationPropertyChanged("RecipeSpecifications");
                }
            }
        }
        private TrackableCollection<RecipeSpecification> _recipeSpecifications;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            MaterialStocks.Clear();
            RecipeSpecifications.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupMaterialStocks(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (MaterialStock item in e.NewItems)
                {
                    item.Material = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("MaterialStocks", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (MaterialStock item in e.OldItems)
                {
                    if (ReferenceEquals(item.Material, this))
                    {
                        item.Material = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("MaterialStocks", item);
                    }
                }
            }
        }
    
        private void FixupRecipeSpecifications(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (RecipeSpecification item in e.NewItems)
                {
                    item.Material = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("RecipeSpecifications", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (RecipeSpecification item in e.OldItems)
                {
                    if (ReferenceEquals(item.Material, this))
                    {
                        item.Material = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("RecipeSpecifications", item);
                    }
                }
            }
        }

        #endregion
    }
}
