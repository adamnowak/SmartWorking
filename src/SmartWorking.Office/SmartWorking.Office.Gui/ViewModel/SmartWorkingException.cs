using System;

namespace SmartWorking.Office.Gui.ViewModel
{
  public class SmartWorkingException : Exception
  {
    public SmartWorkingException(string message)
      : base(message)
    {
    }
  }
}