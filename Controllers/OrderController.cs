using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;
using nwfw.ViewModels;

namespace nwfw.Controllers
{
  [Route("api/[controller]")]
  public class OrderController : Controller
  {
    private ILogger<OrderController> _logger;
    private IOrderRepo _repo;
    private IMapper _mapper;

    public OrderController(IOrderRepo repo, IMapper mapper, ILogger<OrderController> logger)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }
    // GET: api/order
    [HttpGet]
    public JsonResult Get()
    {
      var orders = _repo.GetAllOrdersWithOrderItems();
      
      return Json(_mapper.Map<IEnumerable<OrderViewModel>>(orders));
    }

    // GET api/order/5
    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
      var order = _repo.GetOrderWithOrderItemsById(id);
      var orderVm = _mapper.Map<OrderViewModel>(order);
      return Json(orderVm);
    }

    // POST api/order
    [HttpPost]
    public JsonResult Post([FromBody]OrderViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var newOrder = _mapper.Map<Order>(vm);
          
          _logger.LogInformation("Attempting to save a new Order");
          _repo.PostOrder(newOrder);
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(_mapper.Map<OrderViewModel>(newOrder));            
          }
          
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to save new Order", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // PUT api/order/5
    [HttpPut("{id}")]
    public JsonResult Put(int id, [FromBody]OrderViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        { 
          if (vm.Id != id)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new {message = "Attempted to update different Order"});
          }
                    
          var order = _mapper.Map<Order>(vm);
          _logger.LogInformation("Attempting to save a new Order");
          _repo.PutOrder(order); 
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_mapper.Map<OrderViewModel>(order));            
          }
        }
        
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to update Order", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // DELETE api/order/5
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
      try
      {
        _logger.LogInformation("Attempting to delete a Order");
        var deletedOrder = _repo.DeleteOrder(id);
        
        if (_repo.SaveAll())
        {
          Response.StatusCode = (int)HttpStatusCode.OK;
          return Json(_mapper.Map<OrderViewModel>(deletedOrder));   
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to delete Order", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed"});
    }
  }
}
