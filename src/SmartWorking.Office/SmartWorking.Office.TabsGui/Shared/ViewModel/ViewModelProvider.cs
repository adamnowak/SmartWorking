using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  [Flags]
  public enum ViewModelProviderAction
  {
    IsReadOnlyChanged = 0x1,
    EditingModeChanged = 0x2,
    RefreshInvoiked = 0x4,
    SaveInvoiked = 0x8,
    DeleteInvoiked = 0x16
  }

  public class ViewModelProviderActionEventArgs : EventArgs
  {
    public ControlViewModelBase ViewModel { set; get; }
    public ViewModelProviderAction ViewModelProviderAction { get; set; }

    public ViewModelProviderActionEventArgs(ControlViewModelBase viewModel, ViewModelProviderAction viewModelProviderAction)
    {
      ViewModel = viewModel;
      ViewModelProviderAction = viewModelProviderAction;
    }
  }

  public class ViewModelProvider
  {
    public event EventHandler<ViewModelProviderActionEventArgs> ChildrenViewModelProviderActionInvoked;

    private void OnChildrenViewModelProviderActionInvoked(ControlViewModelBase viewModel, ViewModelProviderAction viewModelProviderAction)
    {
      if (ChildrenViewModelProviderActionInvoked != null && viewModel != null)
      {
        ChildrenViewModelProviderActionInvoked(this, new ViewModelProviderActionEventArgs(viewModel, viewModelProviderAction));
      }
    }
  
    public ControlViewModelBase ParentViewModel { get; private set; }

    public ViewModelProvider(ControlViewModelBase parentViewModel)
    {
      ParentViewModel = parentViewModel;
      ChildrenViewModels = new Dictionary<ControlViewModelBase, ViewModelProviderAction>();
    }

    private Dictionary<ControlViewModelBase, ViewModelProviderAction> ChildrenViewModels { get;  set; }

    public void RegisterChildViewModel(ControlViewModelBase controlViewModelBase)
    {
      RegisterChildViewModel(controlViewModelBase, ViewModelProviderAction.IsReadOnlyChanged | ViewModelProviderAction.EditingModeChanged | ViewModelProviderAction.RefreshInvoiked);
    }

    public void RegisterChildViewModel(ControlViewModelBase controlViewModelBase, ViewModelProviderAction viewModelProviderAction)
    {
      if (controlViewModelBase != null)
      {
        ChildrenViewModels.Add(controlViewModelBase, viewModelProviderAction);

        controlViewModelBase.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(controlViewModelBase_PropertyChanged);
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
              OnChildrenViewModelProviderActionInvoked(controlViewModelBase, ViewModelProviderAction.IsReadOnlyChanged);
            }
          }
          break;

          case ControlViewModelBase.EditingModePropertyName:
          break;
        }
      }
    }
  }
}
