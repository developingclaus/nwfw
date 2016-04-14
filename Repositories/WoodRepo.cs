using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;

namespace nwfw.Repositories
{
  public class WoodRepo : IWoodRepo
  {
    private ILogger<WoodRepo> _logger;
    private NwfwContext _context;

    public WoodRepo(NwfwContext context, ILogger<WoodRepo> logger)
    {
      _logger = logger;
      _context = context;
    }
    // Get
    public IEnumerable<Wood> GetAllWood()
    {
      try
      {
        return _context.Wood.OrderBy(w => w.WoodName).ToList();        
      }
      catch (Exception ex)
      {
        _logger.LogError("Could not get list of Wood", ex);
        return null;
      }
    }

    // Get(id)
    public Wood GetWoodById(int id)
    {
      try
      {
        return GetAllWood().Where(c => c.Id == id).FirstOrDefault();        
      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Could not get Wood with Id: {id}", ex);
        return null;
      }
    }

    // Post
    public void PostWood(Wood newWood)
    {
      try
      {
        _context.Wood.Add(newWood);        
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not add Wood", ex);
      }
    }

    // Put(id)
    public void PutWood(Wood updatedWood)
    {
      try
      {
        _context.Wood.Update(updatedWood);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not update Wood with Id: {updatedWood.Id}", ex);
      }      
    }
    
    // Delete(id)
    public Wood DeleteWood(int id)
    {
      try
      {
        var woodToDelete = GetWoodById(id);
        _context.Wood.Remove(woodToDelete);
        return woodToDelete;
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not delete Wood with Id: {id}", ex);
        return null;
      } 
    }

    public bool SaveAll()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
