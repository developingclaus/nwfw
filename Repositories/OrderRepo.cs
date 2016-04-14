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
  public class OrderRepo : IOrderRepo
  {
    private NwfwContext _context;
    private ILogger<OrderRepo> _logger;

    public OrderRepo(NwfwContext context, ILogger<OrderRepo> logger)
    {
      _context = context;
      _logger = logger;
    }

    public IEnumerable<Order> GetAllOrders()
    {
      try
      {
        return _context.Orders.OrderByDescending(o => o.OrderDate).ToList();        
      }
      catch (Exception ex)
      {
        _logger.LogError("Could not get Orders", ex);
        return null;
      }
    }

    public IEnumerable<Order> GetAllOrdersWithOrderItems()
    {
      try
      {
        return _context.Orders
        .Include(c => c.OrderItems)
        .OrderByDescending(c => c.OrderDate)
        .ToList();  
      }
      catch (Exception ex)
      {
        _logger.LogError("Could not get Orders and their OrderItems", ex);
        return null;
      }
    }
    
    public Order GetOrderById(int id)
    {
      try
      {
        return GetAllOrders().Where(c => c.Id == id).FirstOrDefault();        
      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Could not get Order with Id: {id}", ex);
        return null;
      }
    }

    public Order GetOrderWithOrderItemsById(int id)
    {
      try
      {
        return GetAllOrdersWithOrderItems()
          .Where(c => c.Id == id)
          .FirstOrDefault();        
      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Could not get Order with OrderItems with Id: {id}", ex);
        return null;
      }
    }

    public void PostOrder(Order newOrder)
    {
      try
      {
        _context.Orders.Add(newOrder);        
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not add Order", ex);
      }
    }

    public void PutOrder(Order updatedOrder)
    {
      try
      {
        _context.Orders.Update(updatedOrder);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not update Order with Id: {updatedOrder.Id}", ex);
      }      
    }

    public Order DeleteOrder(int id)
    {
      try
      {
        var orderToDelete = GetOrderById(id);
        _context.Orders.Remove(orderToDelete);
        return orderToDelete;
      }
      catch (Exception ex)
      {
        _logger.LogError($"Could not delete Order with Id: {id}", ex);
        return null;
      } 
    }

    public bool SaveAll()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
