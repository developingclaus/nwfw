using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using nwfw.Models;

namespace nwfw.Repositories.Interfaces
{
  public interface ICustomerRepo
  {   
    IEnumerable<Customer> GetAllCustomers(); // Get
    IEnumerable<Customer> GetAllCustomersWithOrders(); // Get
    Customer GetCustomerById(int id); // Get(id)
    Customer GetCustomerWithOrdersById(int id); // Get(id)
    void PostCustomer(Customer newCustomer);
    void PutCustomer(Customer updatedCustomer);
    Customer DeleteCustomer(int id);
    bool SaveAll();
  }
}
