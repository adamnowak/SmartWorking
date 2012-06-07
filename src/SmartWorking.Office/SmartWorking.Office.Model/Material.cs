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
    public partial class Material
    {
        #region Primitive Properties
    
        public int Id
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

        #endregion
        #region Navigation Properties
    
        public ICollection<MaterialStock> MaterialStocks
        {
            get
            {
                if (_materialStocks == null)
                {
                    var newCollection = new FixupCollection<MaterialStock>();
                    newCollection.CollectionChanged += FixupMaterialStocks;
                    _materialStocks = newCollection;
                }
                return _materialStocks;
            }
            set
            {
                if (!ReferenceEquals(_materialStocks, value))
                {
                    var previousValue = _materialStocks as FixupCollection<MaterialStock>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMaterialStocks;
                    }
                    _materialStocks = value;
                    var newValue = value as FixupCollection<MaterialStock>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMaterialStocks;
                    }
                }
            }
        }
        private ICollection<MaterialStock> _materialStocks;
    
        public ICollection<RecipeSpecification> RecipeSpecifications
        {
            get
            {
                if (_recipeSpecifications == null)
                {
                    var newCollection = new FixupCollection<RecipeSpecification>();
                    newCollection.CollectionChanged += FixupRecipeSpecifications;
                    _recipeSpecifications = newCollection;
                }
                return _recipeSpecifications;
            }
            set
            {
                if (!ReferenceEquals(_recipeSpecifications, value))
                {
                    var previousValue = _recipeSpecifications as FixupCollection<RecipeSpecification>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupRecipeSpecifications;
                    }
                    _recipeSpecifications = value;
                    var newValue = value as FixupCollection<RecipeSpecification>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupRecipeSpecifications;
                    }
                }
            }
        }
        private ICollection<RecipeSpecification> _recipeSpecifications;

        #endregion
        #region Association Fixup
    
        private void FixupMaterialStocks(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (MaterialStock item in e.NewItems)
                {
                    item.Material = this;
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
                }
            }
        }
    
        private void FixupRecipeSpecifications(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (RecipeSpecification item in e.NewItems)
                {
                    item.Material = this;
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
                }
            }
        }

        #endregion
    }
}
