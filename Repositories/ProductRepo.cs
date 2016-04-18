using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;

namespace nwfw.Repositories
{
  public class ProductRepo : IProductRepo
  {
    private ILogger<ProductRepo> _logger;
    private NwfwContext _context;

    public ProductRepo(NwfwContext context, ILogger<ProductRepo> logger)
    {
      _logger = logger;
      _context = context;
    }
    // Get
    public IEnumerable<Product> GetAllProducts()
    {
      try
      {
        return _context.Products.OrderBy(p => p.ProductName).ToList();        
      }
      catch (Exception ex)
      {
        _logger.LogError("Could not get list of Products", ex);
        return null;
      }
    }

    // Get(id)
    public Product GetProductById(int id)
    {
      try
      {
        return GetAllProducts().Where(p => p.Id == id).FirstOrDefault();        
      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Could not get Product with Id: {id}", ex);
        return null;
      }
    }

    // Post
    public void PostProduct(Product newProduct)
    {
      try
      {
        _context.Products.Add(newProduct);        
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not add Product", ex);
      }
    }

    // Put(id)
    public void PutProduct(Product updatedProduct)
    {
      try
      {
        _context.Products.Update(updatedProduct);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not update Product with Id: {updatedProduct.Id}", ex);
      }      
    }
    
    // Delete(id)
    public Product DeleteProduct(int id)
    {
      try
      {
        var productToDelete = GetProductById(id);
        _context.Products.Remove(productToDelete);
        return productToDelete;
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not delete Product with Id: {id}", ex);
        return null;
      } 
    }

    public bool SaveAll()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
