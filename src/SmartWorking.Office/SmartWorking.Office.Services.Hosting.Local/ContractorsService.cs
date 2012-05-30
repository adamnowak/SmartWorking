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
        List<Contractor> result = ctx.Contractors.Include("Buildings").ToList();

        //only in local (when WCF is used then Deserialization set ChangeTracker.ChangeTrackingEnabled on true)
        foreach (Contractor r in result)
        {
          r.StartTracking();
          foreach (Building b in r.Buildings)
          {
            b.StartTracking();
          }
        }
        //end only in local 

        return result;
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

    public void Dispose()
    {
    }

    #endregion
  }
}