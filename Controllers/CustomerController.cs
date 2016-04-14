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

    // GET api/customer/5
    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
      var customer = _repo.GetCustomerWithOrdersById(id);
      return Json(_mapper.Map<CustomerViewModel>(customer));
    }
    
    // POST api/customer
    [HttpPost]
    public JsonResult Post([FromBody]CustomerViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var newCustomer = _mapper.Map<Customer>(vm);
          
          _logger.LogInformation("Attempting to save a new Customer");
          _repo.PostCustomer(newCustomer);
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(_mapper.Map<CustomerViewModel>(newCustomer));            
          }
          
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to save new Customer", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // PUT api/customer/5
    [HttpPut("{id}")]
    public JsonResult Put(int id, [FromBody]CustomerViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        { 
          if (vm.Id != id)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new {message = "Attempted to update different Customer"});
          }
          // if (Get(id) == null)
          // {
          //   Response.StatusCode = (int)HttpStatusCode.NotFound;
          //   return Json(new {message = "Attempted to update non-existing Customer"});
          // }
          
          var customer = _mapper.Map<Customer>(vm);
          _logger.LogInformation("Attempting to save a new Customer");
          _repo.PutCustomer(customer); 
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_mapper.Map<CustomerViewModel>(customer));            
          }
        }
        
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to update Customer", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed", ModelState = ModelState});
    }
    
    // DELETE api/customer/5
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
      try
      {
        _logger.LogInformation("Attempting to delete a Customer");
        var deletedCustomer = _repo.DeleteCustomer(id);
        
        if (_repo.SaveAll())
        {
          Response.StatusCode = (int)HttpStatusCode.OK;
          return Json(_mapper.Map<CustomerViewModel>(deletedCustomer));   
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete Customer", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed"});
    }
  }
}
