using System;
using System.Collections.Generic;
using System.Linq;
using SmartWorking.Office.Entities;
using SmartWorking.Office.PrimitiveEntities;
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
    public List<ContractorPrimitive> GetContractors(string contractorNameFilter)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Contractor> result =
          (string.IsNullOrWhiteSpace(contractorNameFilter))
            ? ctx.Contractors.ToList()
            : ctx.Contractors.Where(x => x.Name.StartsWith(contractorNameFilter)).ToList();
        return result.Select(x => x.GetPrimitive()).ToList();
      }
    }

    /// <summary>
    /// Gets the <see cref="ContractorAndBuildingsPackage"/> list filtered by <paramref name="filter"/>.
    /// </summary>
    /// <param name="filter">The contractor name filter.</param>
    /// <returns>
    /// List of contractors filtered by <paramref name="filter"/>.
    /// </returns>
    public List<ContractorAndBuildingsPackage> GetContractorAndBuildingsPackage(string filter)
    {
      using (var ctx = new SmartWorkingEntities())
      {
        List<Contractor> result =
          (string.IsNullOrWhiteSpace(filter))
            ? ctx.Contractors.Include("Buildings").ToList()
            : ctx.Contractors.Include("Buildings").Where(x => x.Name.StartsWith(filter)).ToList();
        return result.Select(x => x.GetContractorAndBuildingsPackage()).ToList();
      }
    }

    /// <summary>
    /// Updates the contractor.
    /// </summary>
    /// <param name="contractorPrimitive">The contractor primitive.</param>
    public void CreateOrUpdateContractor(ContractorPrimitive contractorPrimitive)
    {
      using (SmartWorkingEntities context = new SmartWorkingEntities())
      {
        Contractor contractor = contractorPrimitive.GetEntity();

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
    /// <param name="contractorPrimitive">The contractor primitive.</param>
    public void DeleteContractor(ContractorPrimitive contractorPrimitive)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the building.
    /// </summary>
    /// <param name="buildingPrimitive">The building primitive.</param>
    public void UpdateBuilding(BuildingPrimitive buildingPrimitive)
    {
      using (SmartWorkingEntities context = new SmartWorkingEntities())
      {
        Building building = buildingPrimitive.GetEntity();
        Building existingObject = context.Buildings.Where(x => x.Id == building.Id).FirstOrDefault();
        

        //no record of this item in the DB, item being passed in has a PK
        if (existingObject == null && building.Id > 0)
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
    public void DeleteBuilding(BuildingPrimitive buildingPrimitive)
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