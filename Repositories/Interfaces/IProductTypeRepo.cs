using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using nwfw.Models;

namespace nwfw.Repositories.Interfaces
{
  public interface IProductTypeRepo
  {   
    IEnumerable<ProductType> GetAllProductTypes(); // Get
    ProductType GetProductTypeById(int id); // Get(id)
    void PostProductType(ProductType newProductType); // Post
    void PutProductType(ProductType updatedProductType); // Put(id)
    ProductType DeleteProductType(int id); // Delete(id)
    bool SaveAll();
  }
}
