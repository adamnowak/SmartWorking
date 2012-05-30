using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  public class MaterialsService : IMaterialsService
  {
    public List<Material> GetMaterials()
    {
      using (var ctx = new SmartWorkingEntities())
      {
        return ctx.Materials.ToList();
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
  }
}
