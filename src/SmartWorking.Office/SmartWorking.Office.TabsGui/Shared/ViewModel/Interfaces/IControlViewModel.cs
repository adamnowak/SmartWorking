using System;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  /// <summary>
  /// Interface for view model for each control.
  /// </summary>
  public interface IControlViewModel
  {
    /// <summary>
    /// Gets the main view model.
    /// </summary>
    IMainViewModel MainViewModel { get; }

    /// <summary>
    /// Gets the name of control.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Refreshes control context.
    /// </summary>
    void Refresh();

    /// <summary>
    /// Occurs when item was saved.
    /// </summary>
    event EventHandler Refreshed;

    /// <summary>
    /// Gets the modal dialog service.
    /// </summary>
    IModalDialogService ModalDialogService { get; }

    /// <summary>
    /// Gets the service factory.
    /// </summary>
    IServiceFactory ServiceFactory { get; }

    /// <summary>
    /// Gets the editing mode of the control.
    /// </summary>
    EditingMode EditingMode { get; set;  }

    /// <summary>
    /// Occurs when item was saved.
    /// </summary>
    event EventHandler EditingModeChanged;

    /// <summary>
    /// Gets a value indicating whether this instance is read only.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
    /// </value>
    bool IsReadOnly { get; }

    /// <summary>
    /// Occurs when item was saved.
    /// </summary>
    event EventHandler IsReadOnlyChanged;

  }
}