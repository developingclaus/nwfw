using System;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;
using nwfw.ViewModels;

namespace nwfw.Controllers
{
    [Route("api/[controller]")]
  public class CustomerController : Controller
  {
    private ILogger<CustomerController> _logger;
    private IMapper _mapper;
    private ICustomerRepo _repo;

    public CustomerController(ICustomerRepo repo, IMapper mapper, ILogger<CustomerController> logger)
    {
      _repo = repo;
      _mapper = mapper;
      _logger = logger;
    }
    // GET: api/customer
    [HttpGet]
    public JsonResult Get()
    {
      var customers = _repo.GetAllCustomersWithOrders();
      return Json(_mapper.Map<IEnumerable<CustomerViewModel>>(customers));
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
      var customer = _repo.GetCustomerWithOrdersById(id);
      return Json(_mapper.Map<CustomerViewModel>(customer));
    }
    
    // POST api/values
    [HttpPost]
    public JsonResult Post([FromBody]CustomerViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var newCustomer = _mapper.Map<Customer>(vm);
          
          _logger.LogInformation("Attempting to save a new Customer");
          _repo.AddCustomer(newCustomer);
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(_mapper.Map<CustomerViewModel>(newCustomer));            
          }
          
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to save new trip", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      
      return Json(new{message = "failed", ModelState = ModelState});
    }
    // POST api/values
    // [HttpPost]
    // public void Post([FromBody]Customer customer)
    // {
    //   var newCustomer = new Customer()
    //   {
    //     CustomerFirstName = customer.CustomerFirstName,
    //     CustomerLastName = customer.CustomerLastName,
    //     CustomerCompanyName = customer.CustomerCompanyName
    //   };
    //   _context.Customers.Add(newCustomer);
    //   _context.SaveChanges();
    // }

    // // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody]Customer customer)
    // {
    //   var customerToUpdate = Get(id);
      
    //   customerToUpdate.CustomerFirstName = customer.CustomerFirstName;
    //   customerToUpdate.CustomerLastName = customer.CustomerLastName;
    //   customerToUpdate.CustomerCompanyName = customer.CustomerCompanyName;
      
    //   _context.SaveChanges();       
    // }

    // // DELETE api/values/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    //   var customerToDelete = Get(id);
    //   _context.Customers.Remove(customerToDelete);
    //   _context.SaveChanges();
    // }
  }
}
