using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using nwfw.Models;
using nwfw.Repositories.Interfaces;

namespace nwfw.Repositories
{
  public class OrderItemRepo : IOrderItemRepo
  {
    private NwfwContext _context;
    private ILogger<OrderItemRepo> _logger;
    private IOrderRepo _orderRepo;

    public OrderItemRepo(NwfwContext context, ILogger<OrderItemRepo> logger, IOrderRepo orderRepo)
    {
      _context = context;
      _logger = logger;
      _orderRepo = orderRepo;
    }
    
    // Get
    public IEnumerable<OrderItem> GetAllOrderItemsForOrder(int orderId)
    {
      var order = _orderRepo.GetOrderWithOrderItemsById(orderId);
      return order.OrderItems.ToList();
    }
    
    // Get(id)
    public OrderItem GetOrderItemById(int orderId, int id)
    {
      try
      {
        var order = _orderRepo.GetOrderWithOrderItemsById(orderId);
        var orderItem = order.OrderItems.Where(o => o.Id == id).FirstOrDefault();
        
        if (orderItem != null)
        {
          return orderItem;
        }
        return null;
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could find OrderItem with Id: {id}", ex);
        return null;
      }
      
           
    }
    
    // Post
    public void PostOrderItem(int orderId, OrderItem newOrderItem)
    {
      var order = _orderRepo.GetOrderWithOrderItemsById(orderId);
      order.OrderItems.Add(newOrderItem);
      _context.OrderItems.Add(newOrderItem);
    }

    // Put(id)
    public void PutOrderItem(int orderId, OrderItem updatedOrderItem)
    {
      try
      {       
        var order = _orderRepo.GetOrderWithOrderItemsById(orderId);
        var orderItem = order.OrderItems.Where(o => o.Id == updatedOrderItem.Id).FirstOrDefault();
        order.OrderItems.Remove(orderItem);
        order.OrderItems.Add(updatedOrderItem);
        _context.OrderItems.Update(updatedOrderItem);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not update OrderItem with Id: {updatedOrderItem.Id}", ex);
      }      
    }

    public OrderItem DeleteOrderItem(int orderId, int id)
    {
      try
      {
        var orderItemToDelete = GetOrderItemById(orderId, id);
        _context.OrderItems.Remove(orderItemToDelete);
        return orderItemToDelete;
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not delete OrderItem with Id: {id}", ex);
        return null;
      } 
    }

    public bool SaveAll()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
