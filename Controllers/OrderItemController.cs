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
  [Route("api/order/{orderId}/[controller]")]
  public class OrderItemController : Controller
  {
    private IOrderItemRepo _repo;
    private ILogger<OrderItemController> _logger;
    private IMapper _mapper;

    public OrderItemController(IOrderItemRepo repo, IMapper mapper, ILogger<OrderItemController> logger)
    {
      _repo = repo;
      _logger = logger;
      _mapper = mapper;
    }
    // GET: api/order/5/orderitem
    [HttpGet]
    public JsonResult Get(int orderId)
    {
      try
      {
        var orderItems = _repo.GetAllOrderItemsForOrder(orderId);
        if (orderItems == null)
        {
          return Json(null);
        }
        
        return Json(_mapper.Map<IEnumerable<OrderItemViewModel>>(orderItems));
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to get all OrderItems for Order with id {orderId}", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
    }

    // GET api/order/5/orderitem/1
    [HttpGet("{id}")]
    public JsonResult Get(int orderId, int id)
    {
      var orderItem = _repo.GetOrderItemById(orderId, id);
      return Json(_mapper.Map<OrderItemViewModel>(orderItem));
    }

    // POST api/order/5/orderitem
    [HttpPost]
    public JsonResult Post(int orderId, [FromBody]OrderItemViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var newOrderItem = _mapper.Map<OrderItem>(vm);
          
          _logger.LogInformation("Attempting to save a new OrderItem");
          _repo.PostOrderItem(orderId, newOrderItem);
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(_mapper.Map<OrderItemViewModel>(newOrderItem));            
          }
          
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to save new OrderItem", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // PUT api/order/5/orderitem/1
    [HttpPut("{id}")]
    public JsonResult Put(int orderId, int id, [FromBody]OrderItemViewModel vm)
    {
      try
      {
        if (ModelState.IsValid)
        { 
          if (vm.Id != id)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new {message = "Attempted to update different OrderItem"});
          }
                    
          var orderItem = _mapper.Map<OrderItem>(vm);
          _logger.LogInformation("Attempting to save a new OrderItem");
          _repo.PutOrderItem(orderItem); 
          
          if (_repo.SaveAll())
          {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_mapper.Map<OrderItemViewModel>(orderItem));            
          }
        }
        
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to update OrderItem", ex);
        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new {message = ex.Message});
      }
      return Json(new{message = "failed", ModelState = ModelState});
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
