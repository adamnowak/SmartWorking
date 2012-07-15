using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GalaSoft.MvvmLight;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  /// <summary>
  /// Base class for MVVM pattern for list where one element is selected.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class SelectableViewModelBase<T> : ViewModelBase
  {
    /// <summary>
    /// The <see cref="Items" /> property's name.
    /// </summary>
    public const string ItemsPropertyName = "Items";

    /// <summary>
    /// The <see cref="SelectedItem" /> property's name.
    /// </summary>
    public const string SelecteItemPropertyName = "SelectedItem";

    private ObservableCollection<T> _items;

    private T _selectedItem;

    /// <summary>
    /// Initializes a new instance of the <see cref="SelectableViewModelBase&lt;T&gt;"/> class.
    /// </summary>
    public SelectableViewModelBase()
    {
      _items = new ObservableCollection<T>();
      _items.CollectionChanged += _items_CollectionChanged;
    }

    /// <summary>
    /// Gets the Items property.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public ObservableCollection<T> Items
    {
      get { return _items; }

      set
      {
        if (_items == value)
        {
          return;
        }
        if (_items != null)
          _items.CollectionChanged -= _items_CollectionChanged;
        _items = value;
        if (_items != null)
          _items.CollectionChanged += _items_CollectionChanged;
        EnsureSelectedItem();
        // Update bindings, no broadcast
        RaisePropertyChanged(ItemsPropertyName);
      }
    }

    /// <summary>
    /// Gets the SelectedItem property.
    /// Represents selected item among <see cref="Items"/>.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public T SelectedItem
    {
      get { return _selectedItem; }

      set
      {
        if (Equals(_selectedItem, value))
        {
          return;
        }

        T oldValue = _selectedItem;
        _selectedItem = value;

        OnSelectedItemChanged(this, new SelectedItemChangedEventArgs<T>(oldValue, _selectedItem));

        // Update bindings and broadcast change using GalaSoft.MvvmLight.Messenging
        RaisePropertyChanged(SelecteItemPropertyName, oldValue, value, true);
      }
    }

    /// <summary>
    /// Ensures the selected item.
    /// </summary>
    private void EnsureSelectedItem()
    {
      if (_items != null)
      {
        if (!_items.Contains(SelectedItem))
        {
          if (_items.Count > 0)
            SelectedItem = _items[0];
          else
            SelectedItem = default(T);
        }
      }
      else
        SelectedItem = default(T);
    }

    /// <summary>
    /// Handles the CollectionChanged event of the _items control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
    private void _items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      EnsureSelectedItem();
    }

    /// <summary>
    /// Occurs when <see cref="SelectedItem"/> was changed.
    /// </summary>
    public event EventHandler<SelectedItemChangedEventArgs<T>> SelectedItemChanged;

    /// <summary>
    /// Called when selected item changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    protected virtual void OnSelectedItemChanged(object sender, SelectedItemChangedEventArgs<T> e)
    {
      if (SelectedItemChanged != null)
      {
        SelectedItemChanged(sender, e);
      }
    }


    /// <summary>
    /// Clears the list of items and adds those provided as a parameter.
    /// </summary>
    /// <param name="items">The items to be loaded.</param>
    public void LoadItems(IEnumerable<T> items)
    {
      Items.Clear();
      if (items != null)
      {
        foreach (T item in items)
        {
          Items.Add(item);
        }
      }
    }
  }
}