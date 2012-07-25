using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  [Flags]
  public enum ViewModelProviderAction
  {
    IsReadOnlyChanged = 0x0001,
    EditingModeChanged = 0x0002,
    RefreshInvoked = 0x0004,
    SaveInvoked = 0x0008,
    DeleteInvoked = 0x0010
  }

  public class ViewModelProviderActionEventArgs : EventArgs
  {
    public ControlViewModelBase ViewModel { set; get; }

    public ViewModelProviderActionEventArgs(ControlViewModelBase viewModel)
    {
      ViewModel = viewModel;
    }
  }

  public class ViewModelProvider
  {
    public event EventHandler<ViewModelProviderActionEventArgs> ChildrenViewModelIsReadOnlyChanged;
    public event EventHandler<ViewModelProviderActionEventArgs> ChildrenViewModelIsEditingModeChanged;
    public event EventHandler<ViewModelProviderActionEventArgs> ChildrenViewModelRefreshInvoked;
    public event EventHandler<ViewModelProviderActionEventArgs> ChildrenViewModelSaveInvoked;
    public event EventHandler<ViewModelProviderActionEventArgs> ChildrenViewModelDeleteInvoked;

    public ControlViewModelBase ParentViewModel { get; private set; }

    public ViewModelProvider(ControlViewModelBase parentViewModel)
    {
      ParentViewModel = parentViewModel;
      ChildrenViewModels = new Dictionary<ControlViewModelBase, ViewModelProviderAction>();
    }

    private Dictionary<ControlViewModelBase, ViewModelProviderAction> ChildrenViewModels { get; set; }

    public void RegisterChildViewModel(ControlViewModelBase controlViewModelBase)
    {
      RegisterChildViewModel(controlViewModelBase, ViewModelProviderAction.IsReadOnlyChanged | ViewModelProviderAction.EditingModeChanged | ViewModelProviderAction.RefreshInvoked);
    }

    public void RegisterChildViewModel(ControlViewModelBase controlViewModelBase, ViewModelProviderAction viewModelProviderAction)
    {
      if (controlViewModelBase != null)
      {
        ChildrenViewModels.Add(controlViewModelBase, viewModelProviderAction);

        if (((viewModelProviderAction & ViewModelProviderAction.IsReadOnlyChanged) == ViewModelProviderAction.IsReadOnlyChanged) ||
          ((viewModelProviderAction & ViewModelProviderAction.EditingModeChanged) == ViewModelProviderAction.EditingModeChanged))
        {
          controlViewModelBase.PropertyChanged +=
            new System.ComponentModel.PropertyChangedEventHandler(controlViewModelBase_PropertyChanged);
        }

        if ((viewModelProviderAction & ViewModelProviderAction.RefreshInvoked) == ViewModelProviderAction.RefreshInvoked)
        {
          controlViewModelBase.Refreshed += new EventHandler(controlViewModelBase_Refreshed);
        }

        if (controlViewModelBase is IEditableControlViewModel && ((viewModelProviderAction & ViewModelProviderAction.SaveInvoked) == ViewModelProviderAction.SaveInvoked))
        {
          ((IEditableControlViewModel)controlViewModelBase).ItemSaved += new EventHandler(ViewModelProvider_ItemSaved);
        }

        if (controlViewModelBase is IListingEditableControlViewModel && ((viewModelProviderAction & ViewModelProviderAction.DeleteInvoked) == ViewModelProviderAction.DeleteInvoked))
        {
          ((IListingEditableControlViewModel)controlViewModelBase).ItemDeleted += new EventHandler(ViewModelProvider_ItemDeleted);
        }
      }
    }

    void ViewModelProvider_ItemDeleted(object sender, EventArgs e)
    {
      ControlViewModelBase controlViewModelBase = sender as ControlViewModelBase;
      if (controlViewModelBase != null && ChildrenViewModels.ContainsKey(controlViewModelBase))
      {
        if ((ChildrenViewModels[controlViewModelBase] & ViewModelProviderAction.DeleteInvoked) == ViewModelProviderAction.DeleteInvoked)
        {
          OnChildrenViewModelDeleteInvoked(controlViewModelBase);
        }
      }
    }

    void ViewModelProvider_ItemSaved(object sender, EventArgs e)
    {
      ControlViewModelBase controlViewModelBase = sender as ControlViewModelBase;
      if (controlViewModelBase != null && ChildrenViewModels.ContainsKey(controlViewModelBase))
      {
        if ((ChildrenViewModels[controlViewModelBase] & ViewModelProviderAction.SaveInvoked) == ViewModelProviderAction.SaveInvoked)
        {
          OnChildrenViewModelSaveInvoked(controlViewModelBase);
        }
      }
    }

    void controlViewModelBase_Refreshed(object sender, EventArgs e)
    {
      ControlViewModelBase controlViewModelBase = sender as ControlViewModelBase;
      if (controlViewModelBase != null && ChildrenViewModels.ContainsKey(controlViewModelBase))
      {
        if ((ChildrenViewModels[controlViewModelBase] & ViewModelProviderAction.RefreshInvoked) == ViewModelProviderAction.RefreshInvoked)
        {
          OnChildrenViewModelRefreshInvoked(controlViewModelBase);
        }
      }
    }

    void controlViewModelBase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      ControlViewModelBase controlViewModelBase = sender as ControlViewModelBase;
      if (controlViewModelBase != null && ChildrenViewModels.ContainsKey(controlViewModelBase))
      {
        switch (e.PropertyName)
        {
          case ControlViewModelBase.IsReadOnlyPropertyName:
            {
              if ((ChildrenViewModels[controlViewModelBase] & ViewModelProviderAction.IsReadOnlyChanged) == ViewModelProviderAction.IsReadOnlyChanged)
              {
                OnChildrenViewModelIsReadOnlyChanged(controlViewModelBase);
              }
            }
            break;

          case ControlViewModelBase.EditingModePropertyName:
            {
              if ((ChildrenViewModels[controlViewModelBase] & ViewModelProviderAction.EditingModeChanged) == ViewModelProviderAction.EditingModeChanged)
              {
                OnChildrenViewModelIsEditingModeChanged(controlViewModelBase);
              }
            }
            break;
        }
      }
    }

    private void OnChildrenViewModelIsReadOnlyChanged(ControlViewModelBase viewModel)
    {
      if (ChildrenViewModelIsReadOnlyChanged != null && viewModel != null)
      {
        ChildrenViewModelIsReadOnlyChanged(this, new ViewModelProviderActionEventArgs(viewModel));
      }
    }

    private void OnChildrenViewModelIsEditingModeChanged(ControlViewModelBase viewModel)
    {
      if (ChildrenViewModelIsEditingModeChanged != null && viewModel != null)
      {
        ChildrenViewModelIsEditingModeChanged(this, new ViewModelProviderActionEventArgs(viewModel));
      }
    }

    private void OnChildrenViewModelRefreshInvoked(ControlViewModelBase viewModel)
    {
      if (ChildrenViewModelRefreshInvoked != null && viewModel != null)
      {
        ChildrenViewModelRefreshInvoked(this, new ViewModelProviderActionEventArgs(viewModel));
      }
    }

    private void OnChildrenViewModelSaveInvoked(ControlViewModelBase viewModel)
    {
      if (ChildrenViewModelSaveInvoked != null && viewModel != null)
      {
        ChildrenViewModelSaveInvoked(this, new ViewModelProviderActionEventArgs(viewModel));
      }
    }

    private void OnChildrenViewModelDeleteInvoked(ControlViewModelBase viewModel)
    {
      if (ChildrenViewModelDeleteInvoked != null && viewModel != null)
      {
        ChildrenViewModelDeleteInvoked(this, new ViewModelProviderActionEventArgs(viewModel));
      }
    }
  }
}
