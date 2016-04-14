using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nwfw.Models;

namespace nwfw.Repositories.Interfaces
{
  public interface IOrderItemRepo
  {
    IEnumerable<OrderItem> GetAllOrderItemsForOrder(int orderId); // Get
    OrderItem GetOrderItemById(int orderId, int id); // Get(id)
    void PostOrderItem(int orderId, OrderItem newOrderItem); // Post
    void PutOrderItem(OrderItem updatedOrderItem); // Put(id)
    OrderItem DeleteOrderItem(int id); // Delete(id)
    bool SaveAll();
  }
}
