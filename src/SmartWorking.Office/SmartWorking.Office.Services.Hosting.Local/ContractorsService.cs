using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Interfaces;

namespace SmartWorking.Office.Services.Hosting.Local
{
  /// <summary>
  /// Implementation of <see cref="IContractorsService"/>.
  /// </summary>
  public class ContractorsService : IContractorsService
  {
    #region IContractorsService Members

    /// <summary>
    /// Gets the contractors filtered by <paramref name="contractorNameFilter"/>.
    /// </summary>
    /// <param name="contractorNameFilter">The contractor name filter.</param>
    /// <returns>
    /// List of contractors filtered by <paramref name="contractorNameFilter"/>. Result contains Buildings of Contractors.
    /// </returns>
    public List<Contractor> GetContractors(string contractorNameFilter)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Contractor> result =
          (string.IsNullOrWhiteSpace(contractorNameFilter))
            ? ctx.Contractors.Include("Buildings").ToList()
            : ctx.Contractors.Include("Buildings").Where(x => x.Name.StartsWith(contractorNameFilter)).ToList();
        return result;
      }
    }

    /// <summary>
    /// Updates the contractor.
    /// </summary>
    /// <param name="contractor">The contractor who will be updated.</param>
    public void UpdateContractor(Contractor contractor)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        ctx.Contractors.ApplyCurrentValues(contractor);
        ctx.SaveChanges();
      }
    }

    /// <summary>
    /// Deletes the contractor.
    /// </summary>
    /// <param name="contractor">The contractor who will be deleted.</param>
    public void DeleteContractor(Contractor contractor)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Adds the building to contractor.
    /// </summary>
    /// <param name="contractor">The contractor.</param>
    /// <param name="building">The building which will be added to <paramref name="contractor"/>.</param>
    public void AddBuildingToContractor(Contractor contractor, Building building)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the building.
    /// </summary>
    /// <param name="building">The building which will be updated.</param>
    public void UpdateBuilding(Building building)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes the building.
    /// </summary>
    /// <param name="building">The building which will be deleted.</param>
    public void DeleteBuilding(Building building)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
    }

    #endregion
  }
}