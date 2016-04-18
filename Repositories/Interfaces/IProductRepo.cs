using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using nwfw.Models;

namespace nwfw.Repositories.Interfaces
{
  public interface IProductRepo
  {   
    IEnumerable<Product> GetAllProducts(); // Get
    Product GetProductById(int id); // Get(id)
    void PostProduct(Product newProduct); // Post
    void PutProduct(Product updatedProduct); // Put(id)
    Product DeleteProduct(int id); // Delete(id)
    bool SaveAll();
  }
}
