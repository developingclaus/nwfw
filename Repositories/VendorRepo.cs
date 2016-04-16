using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;

namespace nwfw.Repositories
{
  public class VendorRepo : IVendorRepo
  {
    private ILogger<VendorRepo> _logger;
    private NwfwContext _context;

    public VendorRepo(NwfwContext context, ILogger<VendorRepo> logger)
    {
      _logger = logger;
      _context = context;
    }
    // Get
    public IEnumerable<Vendor> GetAllVendors()
    {
      try
      {
        return _context.Vendors.Include(v => v.Orders).OrderBy(v => v.VendorLastName).ToList();        
      }
      catch (Exception ex)
      {
        _logger.LogError("Could not get list of Vendors", ex);
        return null;
      }
    }

    // Get(id)
    public Vendor GetVendorById(int id)
    {
      try
      {
        return GetAllVendors().Where(v => v.Id == id).FirstOrDefault();        
      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Could not get Vendor with Id: {id}", ex);
        return null;
      }
    }

    // Post
    public void PostVendor(Vendor newVendor)
    {
      try
      {
        _context.Vendors.Add(newVendor);        
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not add Vendor", ex);
      }
    }

    // Put(id)
    public void PutVendor(Vendor updatedVendor)
    {
      try
      {
        _context.Vendors.Update(updatedVendor);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not update Vendor with Id: {updatedVendor.Id}", ex);
      }      
    }
    
    // Delete(id)
    public Vendor DeleteVendor(int id)
    {
      try
      {
        var vendorToDelete = GetVendorById(id);
        _context.Vendors.Remove(vendorToDelete);
        return vendorToDelete;
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not delete Vendor with Id: {id}", ex);
        return null;
      } 
    }

    public bool SaveAll()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
