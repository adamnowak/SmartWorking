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
    public void CreateOrUpdateContractor(Contractor contractor)
    {
      using (SmartWorkingEntities context = new SmartWorkingEntities())
      {
        Contractor existingObject = context.Contractors.Where(x => x.Id == contractor.Id).FirstOrDefault();

        //no record of this item in the DB, item being passed in has a PK
        if (existingObject == null && contractor.Id > 0)
        {
          //log
          return;
        }
        //Item has no PK value, must be new
        else if (contractor.Id <= 0)
        {
          context.Contractors.AddObject(contractor);
        }
        //Item was retrieved, and the item passed has a valid ID, do an update
        else
        {
          context.Contractors.ApplyCurrentValues(contractor);
        }

        context.SaveChanges();
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
    /// Updates the building.
    /// </summary>
    /// <param name="building">The building which will be updated.</param>
    public void UpdateBuilding(Building building)
    {
      using (SmartWorkingEntities context = new SmartWorkingEntities())
      {
        Contractor existingObject =
          context.Contractors.Include("Buildings").Where(x => x.Id == building.Contractor_Id).FirstOrDefault();


        //no record of this item in the DB, item being passed in has a PK
        if (existingObject == null)
        {
          //log //TODO: contractor have to be in database before
          return;
        }
          //Item has no PK value, must be new
        else if (building.Id <= 0)
        {
          context.Buildings.AddObject(building);
        }
          //Item was retrieved, and the item passed has a valid ID, do an update
        else
        {
          context.Buildings.ApplyCurrentValues(building);
        }

        context.SaveChanges();
      }
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