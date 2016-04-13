using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using nwfw.Models;

namespace nwfw.Controllers
{
  [Route("api/[controller]")]
  public class CustomerController : Controller
  {
    private NwfwContext _context;

    public CustomerController(NwfwContext context)
    {
      _context = context;
    }
    // GET: api/customer
    [HttpGet]
    public Customer[] Get()
    {
      return _context.Customers.ToArray();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public Customer Get(int id)
    {
        return Get().Where(c => c.Id == id).FirstOrDefault();
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]Customer customer)
    {
      var newCustomer = new Customer()
      {
        CustomerFirstName = customer.CustomerFirstName,
        CustomerLastName = customer.CustomerLastName,
        CustomerCompanyName = customer.CustomerCompanyName
      };
      _context.Customers.Add(newCustomer);
      _context.SaveChanges();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]Customer customer)
    {
      var customerToUpdate = Get(id);
      
      customerToUpdate.CustomerFirstName = customer.CustomerFirstName;
      customerToUpdate.CustomerLastName = customer.CustomerLastName;
      customerToUpdate.CustomerCompanyName = customer.CustomerCompanyName;
      
      _context.SaveChanges();       
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var customerToDelete = Get(id);
      _context.Customers.Remove(customerToDelete);
      _context.SaveChanges();
    }
  }
}
