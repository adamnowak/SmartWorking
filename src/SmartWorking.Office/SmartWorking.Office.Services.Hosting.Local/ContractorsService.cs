using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
    public List<ContractorPrimitive> GetContractors(string filter, ListItemsFilterValues listItemsFilterValue)
    {
      try
      {
        using (var ctx = new SmartWorkingEntities())
        {
          List<Contractor> result =
            (string.IsNullOrWhiteSpace(filter))
              ? (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Contractors.ToList()
                  : ctx.Contractors.Where(x => !x.Deleted.HasValue).ToList()                     
              : (listItemsFilterValue == ListItemsFilterValues.All)
                  ? ctx.Contractors.Where(x => x.Name.StartsWith(filter)).ToList()
                  : ctx.Contractors.Where(x => !x.Deleted.HasValue && x.Name.StartsWith(filter)).ToList();
          return result.Select(x => x.GetPrimitive()).ToList(); ;
        }
      }
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Updates the contractor.
    /// </summary>
    /// <param name="contractorPrimitive">The contractor primitive.</param>
    public void CreateOrUpdateContractor(ContractorPrimitive contractorPrimitive)
    {
      try
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
      catch (Exception e)
      {
        throw new FaultException<ExceptionDetail>(new ExceptionDetail(e), e.Message);
      }
    }

    /// <summary>
    /// Deletes the contractor.
    /// </summary>
    /// <param name="contractorPrimitive">The contractor primitive.</param>
    public void DeleteContractor(ContractorPrimitive contractorPrimitive)
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        //TODO: if is not used in any DeliveryNotes than delete.
        using (SmartWorkingEntities context = new SmartWorkingEntities())
        {
          Contractor contractor = context.Contractors.Where(x => x.Id == contractorPrimitive.Id).FirstOrDefault();
          if (contractor != null)
          {
            contractor.Deleted = DateTime.Now;
            context.SaveChanges();
          }
          else
          {
            throw new Exception("This car does not exist in db.");
          }
        }
      }
    }
    #endregion

    public void Dispose()
    {
      
    }
  }
}