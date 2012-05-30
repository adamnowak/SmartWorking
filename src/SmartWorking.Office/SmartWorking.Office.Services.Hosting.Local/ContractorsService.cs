using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
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
