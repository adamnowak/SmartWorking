using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace SmartWorking.Office.Gui.ViewModel
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
    private ICommand _nextItemCommand;
    private ICommand _previouseItemCommand;
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

        OnSelectedItemChanged(this, new SelectedItemChangedEventArg<T>(oldValue, _selectedItem));

        // Update bindings and broadcast change using GalaSoft.MvvmLight.Messenging
        RaisePropertyChanged(SelecteItemPropertyName, oldValue, value, true);
      }
    }

    /// <summary>
    /// Gets the previous item command.
    /// </summary>
    /// <remarks>
    /// Sets <see cref="SelectedItem"/> to previous element in <see cref="Items"/> list.
    /// </remarks>
    public ICommand PreviousItemCommand
    {
      get
      {
        if (_previouseItemCommand == null)
          _previouseItemCommand = new RelayCommand(SetPreviouseItem,
                                                   () => !Equals(SelectedItem, Items.FirstOrDefault()));
        return _previouseItemCommand;
      }
    }

    /// <summary>
    /// Gets the next item command.
    /// </summary>
    /// <remarks>
    /// Sets <see cref="SelectedItem"/> to next element in <see cref="Items"/> list.
    /// </remarks>
    public ICommand NextItemCommand
    {
      get
      {
        if (_nextItemCommand == null)
          _nextItemCommand = new RelayCommand(SetNextItem, () => !Equals(SelectedItem, Items.LastOrDefault()));
        return _nextItemCommand;
      }
    }

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

    private void _items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      EnsureSelectedItem();
    }

    /// <summary>
    /// Occurs when <see cref="SelectedItem"/> was changed.
    /// </summary>
    public event EventHandler<SelectedItemChangedEventArg<T>> SelectedItemChanged;

    /// <summary>
    /// Called when [selected item changed].
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    protected virtual void OnSelectedItemChanged(object sender, SelectedItemChangedEventArg<T> e)
    {
      if (SelectedItemChanged != null)
      {
        SelectedItemChanged(sender, e);
      }
    }


    private void SetPreviouseItem()
    {
      try
      {
        int selectedPos = Items.IndexOf(SelectedItem);
        if (selectedPos > 0 && selectedPos < Items.Count)
        {
          SelectedItem = Items.ElementAt(selectedPos - 1);
        }
      }
      catch (Exception exception)
      {
        Messenger.Default.Send(
          new DialogMessage(exception.Message, null), "exceptionMessage");
      }
    }

    private void SetNextItem()
    {
      try
      {
        int selectedPos = Items.IndexOf(SelectedItem);
        if (selectedPos >= 0 && selectedPos < Items.Count - 1)
        {
          SelectedItem = Items.ElementAt(selectedPos + 1);
        }
      }
      catch (Exception exception)
      {
        Messenger.Default.Send(
          new DialogMessage(exception.Message, null), "exceptionMessage");
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