using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  
  [Flags]
  public enum AccessLevel
  {
    Read = 0x1,
    Write = 0x2,
    Delete = 0x4    
  }

  public class AccessLevels
  {
    public static AccessLevel OperatorLevel { get { return AccessLevel.Read | AccessLevel.Write; }}
    public static AccessLevel WOSLevel { get { return AccessLevel.Read | AccessLevel.Write; }}
    public static AccessLevel AdministratorLevel { get { return AccessLevel.Read | AccessLevel.Write | AccessLevel.Delete; }}
  }
  

  //public class AccessLevel 
  //{
  //  public AccessLevel(AccessLevelValue level)
  //  {
  //    Level = level;
  //  }

  //  public AccessLevelValue Level { get; private set; }

  //  public bool HasAccess(AccessLevelValue level)
  //  {
  //    switch (Level)
  //    {
  //      case AccessLevelValue.Operator:
  //        (level == AccessLevelValue.Operator)
        
  //    }
  //  }
  //}
}
