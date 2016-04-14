using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nwfw.Models;

namespace nwfw.Repositories.Interfaces
{
  public interface IOrderRepo
  {
    IEnumerable<Order> GetAllOrders(); // Get
    IEnumerable<Order> GetAllOrdersWithOrderItems(); // Get
    Order GetOrderById(int id); // Get(id)
    Order GetOrderWithOrderItemsById(int id); // Get(id)
    void AddOrder(Order newOrder);
    bool SaveAll();
  }
}
