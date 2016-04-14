using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using nwfw.Models;

namespace nwfw.Repositories.Interfaces
{
  public interface IWoodRepo
  {   
    IEnumerable<Wood> GetAllWood(); // Get
    Wood GetWoodById(int id); // Get(id)
    void PostWood(Wood newWood); // Post
    void PutWood(Wood updatedWood); // Put(id)
    Wood DeleteWood(int id); // Delete(id)
    bool SaveAll();
  }
}
