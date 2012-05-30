using System;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Event argument used for <see cref="SelectableViewModelBase{T}.SelectedItemChanged"/> event.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class SelectedItemChangedEventArg<T> : EventArgs
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SelectedItemChangedEventArg&lt;T&gt;"/> class.
    /// </summary>
    /// <param name="oldValue">The old value.</param>
    /// <param name="newValue">The new value.</param>
    public SelectedItemChangedEventArg(T oldValue, T newValue)
    {
      OldValue = oldValue;
      NewValue = newValue;
    }

    /// <summary>
    /// Gets the old value.
    /// </summary>
    public T OldValue { get; private set; }

    /// <summary>
    /// Gets the new value.
    /// </summary>
    public T NewValue { get; private set; }
  }
}