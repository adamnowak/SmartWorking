using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartWorking.Office.PrimitiveEntities.Packages
{
  public class UserAndRolesPackage
  {
    public UserPrimitive User { get; set; }

    public string PasswordConfirm { get; set; }

    private ICollection<RolePrimitive> _roles;
    public ICollection<RolePrimitive> Roles
    {
      get
      {
        if (_roles == null)
        {
          _roles = new ObservableCollection<RolePrimitive>();
        }
        return _roles;
      }
      set
      {
        _roles = value;
      }
    }
  }
}
