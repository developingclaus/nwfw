using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using nwfw.Models;

namespace nwfw.Repositories.Interfaces
{
  public interface IVendorRepo
  {   
    IEnumerable<Vendor> GetAllVendors(); // Get
    Vendor GetVendorById(int id); // Get(id)
    void PostVendor(Vendor newVendor); // Post
    void PutVendor(Vendor updatedVendor); // Put(id)
    Vendor DeleteVendor(int id); // Delete(id)
    bool SaveAll();
  }
}
