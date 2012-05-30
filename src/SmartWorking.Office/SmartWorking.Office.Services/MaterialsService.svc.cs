using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartWorking.Office.Entities;
using SmartWorking.Office.ServiceInterfaces;

namespace SmartWorking.Office.Services
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MaterialsService" in code, svc and config file together.
  public class MaterialsService : IMaterialsService
  {
    public List<Material> GetMaterials()
    {
      throw new NotImplementedException();
    }

    public void UpdateMaterial(Material materialToUpdate)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      
    }
  }
}
