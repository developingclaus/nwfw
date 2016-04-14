using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;

namespace nwfw.Repositories
{
  public class CustomerRepo : ICustomerRepo
  {
    private NwfwContext _context;
    private ILogger<CustomerRepo> _logger;

    public CustomerRepo(NwfwContext context, ILogger<CustomerRepo> logger)
    {
      _context = context;
      _logger = logger;
    }       

    public IEnumerable<Customer> GetAllCustomers()
    { 
      try
      {
        return _context.Customers.OrderBy(c => c.CustomerLastName).ToList();
      }
      catch (Exception ex)
      {
        _logger.LogError("Could not get Customers", ex);
        return null;
      }
    } 
    
    public IEnumerable<Customer> GetAllCustomersWithOrders()
    {
      try
      {
        return _context.Customers
        .Include(c => c.Orders)
        .OrderBy(c => c.CustomerLastName)
        .ToList();  
      }
      catch (Exception ex)
      {
        _logger.LogError("Could not get Customers and their Orders", ex);
        return null;
      }
          
    }
    
    public Customer GetCustomerById(int id)
    {
      try
      {
        return GetAllCustomers().Where(c => c.Id == id).FirstOrDefault();        
      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Could not get Customer with Id: {id}", ex);
        return null;
      }
    }
    
    public Customer GetCustomerWithOrdersById(int id)
    {
      try
      {
        return GetAllCustomersWithOrders()
          .Where(c => c.Id == id)
          .FirstOrDefault();        
      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Could not get Customer with Id: {id}", ex);
        return null;
      }
    }
    
    public void AddCustomer(Customer newCustomer)
    {
      _context.Customers.Add(newCustomer);
    }

    public bool SaveAll()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
