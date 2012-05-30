using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  public class MaterialsService : IMaterialsService
  {
    #region IMaterialsService Members

    public List<Material> GetMaterials()
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Material> result = ctx.Materials.ToList();

        //only in local (when WCF is used then Deserialization set ChangeTracker.ChangeTrackingEnabled on true)
        foreach (Material r in result)
        {
          r.StartTracking();
        }
        //end only in local 

        return result;
      }
    }

    public void UpdateMaterial(Material materialToUpdate)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        ctx.Materials.ApplyChanges(materialToUpdate);
        ctx.SaveChanges();
      }
    }

    public void Dispose()
    {
    }

    #endregion
  }
}