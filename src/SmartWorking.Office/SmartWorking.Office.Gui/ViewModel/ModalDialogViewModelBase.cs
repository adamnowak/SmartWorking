using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Gui.ViewModel
{
  /// <summary>
  /// Base class for View Model in MVVM pattern (using MVVMLight). Implements <see cref="IModalDialogViewModel"/> interface.
  /// </summary>
  public abstract class ModalDialogViewModelBase : WindowViewModelBase, IModalDialogViewModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DialogViewModelBase"/> class.
    /// </summary>
    /// <param name="modalDialogService">The modal dialog service.</param>
    /// <param name="serviceFactory">The service factory.</param>
    protected ModalDialogViewModelBase(IModalDialogService modalDialogService, IServiceFactory serviceFactory)
      : base(modalDialogService, serviceFactory)
    {
    }

    #region IModalDialogViewModel Members

    /// <summary>
    /// Initializes view model properties.
    /// </summary>
    public virtual void Initialize()
    {
    }

    public virtual void Refresh()
    {      
    }

    #endregion
  }
}