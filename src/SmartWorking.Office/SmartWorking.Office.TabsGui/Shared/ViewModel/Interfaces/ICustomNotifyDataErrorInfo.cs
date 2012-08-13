using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces
{
  public interface ICustomNotifyDataErrorInfo
  {
    void Validate();
    bool HasErrors { get; }
    IList<ValidationResult> Errors { get; }
    
  }
}