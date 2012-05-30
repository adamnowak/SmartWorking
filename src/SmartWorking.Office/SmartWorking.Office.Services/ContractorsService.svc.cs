using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.ServiceInterfaces;

namespace SmartWorking.Office.Services
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
  public class ContractorsService : IContractorsService
  {
    #region IContractorsService Members

    public List<Contractor> GetContractors()
    {
      using (var ctx = new SmartWorkingEntities())
      {
        return ctx.Contractors.Include("Buildings").ToList();
      }
    }

    public void UpdateContractor(Contractor contractorToUpdate)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        ctx.Contractors.ApplyChanges(contractorToUpdate);
        ctx.SaveChanges();
      }
    }


    #endregion

    public void Dispose()
    {
      
    }
  }
}