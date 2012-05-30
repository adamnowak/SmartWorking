using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMaterialsService" in both code and config file together.
  [ServiceContract]
  public interface IMaterialsService : IDisposable 
  {
    [OperationContract]
    List<Material> GetMaterials();

    [OperationContract]
    void UpdateMaterial(Material materialToUpdate);
  }
}
