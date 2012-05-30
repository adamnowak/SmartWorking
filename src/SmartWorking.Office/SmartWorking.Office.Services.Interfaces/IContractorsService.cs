using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface IContractorsService : IDisposable
  {
    [OperationContract]
    List<Contractor> GetContractors();

    [OperationContract]
    void UpdateContractor(Contractor contractorToUpdate);


    // TODO: Add your service operations here
  }
}