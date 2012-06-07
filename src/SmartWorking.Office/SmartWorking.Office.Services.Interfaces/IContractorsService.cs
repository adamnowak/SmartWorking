using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Services.Interfaces
{
  /// <summary>
  /// Service provides functionality to operate on Contractor and his Buildings.
  /// </summary>
  [ServiceContract]
  public interface IContractorsService : IDisposable
  {
    /// <summary>
    /// Gets the contractors filtered by <paramref name="contractorNameFilter"/>.
    /// </summary>
    /// <param name="contractorNameFilter">The contractor name filter.</param>
    /// <returns>List of contractors filtered by <paramref name="contractorNameFilter"/>. Result contains Buildings of Contractors.</returns>
    [OperationContract]
    List<Contractor> GetContractors(string contractorNameFilter);

    /// <summary>
    /// Updates the contractor.
    /// </summary>
    /// <param name="contractor">The contractor who will be updated.</param>
    /// <remarks>Only fields of Contractor object will be updated. Associated object e.g. Buildings have to be updated separately.</remarks>
    [OperationContract]
    void UpdateContractor(Contractor contractor);

    /// <summary>
    /// Deletes the contractor.
    /// </summary>
    /// <param name="contractor">The contractor who will be deleted.</param>
    /// <remarks>Only contractor who doesn't have Building which are used in <see cref="DeliveryNote"/></remarks>
    [OperationContract]
    void DeleteContractor(Contractor contractor);

    /// <summary>
    /// Adds the building to contractor.
    /// </summary>
    /// <param name="contractor">The contractor.</param>
    /// <param name="building">The building which will be added to <paramref name="contractor"/>.</param>
    [OperationContract]
    void AddBuildingToContractor(Contractor contractor, Building building);

    /// <summary>
    /// Updates the building.
    /// </summary>
    /// <param name="building">The building which will be updated.</param>
    /// <remarks>Only fields of Building will be updated. Associated object e.g. Contractor have to be updated separately.</remarks>
    [OperationContract]
    void UpdateBuilding(Building building);

    /// <summary>
    /// Deletes the building.
    /// </summary>
    /// <param name="building">The building which will be deleted.</param>
    [OperationContract]
    void DeleteBuilding(Building building);
  }
}