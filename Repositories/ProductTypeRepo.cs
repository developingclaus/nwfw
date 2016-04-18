using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;

namespace nwfw.Repositories
{
  public class ProductTypeRepo : IProductTypeRepo
  {
    private ILogger<ProductTypeRepo> _logger;
    private NwfwContext _context;

    public ProductTypeRepo(NwfwContext context, ILogger<ProductTypeRepo> logger)
    {
      _logger = logger;
      _context = context;
    }
    // Get
    public IEnumerable<ProductType> GetAllProductTypes()
    {
      try
      {
        return _context.ProductTypes.OrderBy(p => p.ProductTypeName).ToList();        
      }
      catch (Exception ex)
      {
        _logger.LogError("Could not get list of ProductTypes", ex);
        return null;
      }
    }

    // Get(id)
    public ProductType GetProductTypeById(int id)
    {
      try
      {
        return GetAllProductTypes().Where(p => p.Id == id).FirstOrDefault();        
      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Could not get ProductType with Id: {id}", ex);
        return null;
      }
    }

    // Post
    public void PostProductType(ProductType newProductType)
    {
      try
      {
        _context.ProductTypes.Add(newProductType);        
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not add ProductType", ex);
      }
    }

    // Put(id)
    public void PutProductType(ProductType updatedProductType)
    {
      try
      {
        _context.ProductTypes.Update(updatedProductType);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not update ProductType with Id: {updatedProductType.Id}", ex);
      }      
    }
    
    // Delete(id)
    public ProductType DeleteProductType(int id)
    {
      try
      {
        var productTypeToDelete = GetProductTypeById(id);
        _context.ProductTypes.Remove(productTypeToDelete);
        return productTypeToDelete;
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not delete ProductType with Id: {id}", ex);
        return null;
      } 
    }

    public bool SaveAll()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
