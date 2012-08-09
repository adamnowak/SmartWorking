
using System;
using GalaSoft.MvvmLight;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public class SmartWorkingConfiguration : ViewModelBase
  {
    #region PreviewDeliveryNote
    /// <summary>
    /// The <see cref="PreviewDeliveryNote" /> property's name.
    /// </summary>
    public const string PreviewDeliveryNotePropertyName = "PreviewDeliveryNote";

    private bool _previewDeliveryNote = false;

    /// <summary>
    /// Gets or sets a value indicating whether delivery note will be shown on preview dialog before save and printing.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [preview delivery note]; otherwise, <c>false</c>.
    /// </value>
    public bool PreviewDeliveryNote
    {
      get
      {
        return _previewDeliveryNote;
      }

      set
      {
        if (_previewDeliveryNote == value)
        {
          return;
        }
        _previewDeliveryNote = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(PreviewDeliveryNotePropertyName);
      }
    }
    #endregion //PreviewDeliveryNote


    #region PagesToPrint
    /// <summary>
    /// The <see cref="PagesToPrint" /> property's name.
    /// </summary>
    public const string PagesToPrintPropertyName = "PagesToPrint";

    private int _PagesToPrint;

    /// <summary>
    /// Gets the PagesToPrint property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public int PagesToPrint
    {
      get
      {
        return _PagesToPrint;
      }

      set
      {
        if (_PagesToPrint == value)
        {
          return;
        }
        _PagesToPrint = value;
        // Update bindings, no broadcast
        RaisePropertyChanged(PagesToPrintPropertyName);
      }
    }
    #endregion //PagesToPrint

    
  }
}