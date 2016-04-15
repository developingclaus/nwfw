using System;
using System.Linq;

namespace nwfw.Models.DataSeed
{
  public class NwfwTestDataSeed
  {
    private NwfwContext _context;

    public NwfwTestDataSeed(NwfwContext context)
    {
      _context = context;
    }
    
    public void SeedFoSho()
    {
      if (!_context.Orders.Any())
      {
        // Insert data if none alredy
        var customer1 = new Customer()
        {
          CustomerFirstName = "Claus",
          CustomerLastName = "Søgaard Andersen", 
          CustomerCompanyName = "Regarding Claus"
        };
        
        var customer2 = new Customer()
        {
          CustomerFirstName = "Ariel",
          CustomerLastName = "Andersen"
        };
        
        var orderStatus1 = new OrderStatus(){OrderStatusName = "New"};
        var orderStatus2 = new OrderStatus(){OrderStatusName = "Processing"};
        var orderStatus3 = new OrderStatus(){OrderStatusName = "Charged"};
        var orderStatus4 = new OrderStatus(){OrderStatusName = "Shipped"};
        
        var orderType1 = new OrderType(){OrderTypeName = "Custom Stabilized Order"};
        var orderType2 = new OrderType(){OrderTypeName = "Custom Bowl Blanks Order"};
        
        var productType1 = new ProductType(){ProductTypeName = "Stabilized"};
        var productType2 = new ProductType(){ProductTypeName = "Burl"};
        var productType3 = new ProductType(){ProductTypeName = "Spalted"};
        
        var vendor1 = new Vendor()
        {
          VendorCompanyName = "North Woods Figured Wood"
        };
        
        var vendor2 = new Vendor(){
          VendorFirstName = "Tom",
          VendorLastName = "Stone"
        };
        
        var wood1 = new Wood(){WoodName = "Oak"};
        var wood2 = new Wood(){WoodName = "Elm"};
        var wood3 = new Wood(){WoodName = "Maple"};
        
        var prod1 = new Product()
        {
          ProductName = "Stablized Maple Blank 2x3x4"
        };
        
        // var product1 = new Product()
        // {
        //   ProductName = "Stabilized Oak 2x3x4",
        //   ProductBasePrice = 20,
        //   // Wood = wood1,
        //   // ProductType = productType1
        // };
        
        // var product2 = new Product()
        // {
        //   ProductName = "4x3x4",
        //   ProductBasePrice = 40,
        //   // Wood = wood1,
        //   // ProductType = productType1
        // };
        
        // var product3 = new Product()
        // {
        //   ProductName = "4x2x8",
        //   ProductBasePrice = 50,
        //   // Wood = wood3,
        //   // ProductType = productType2
        // };
        
        var order1 = new Order()
        {
          NwfwOrderId = "nwfwSta49382",
          OrderDate = new DateTime(2016, 4, 13), 
          FulfillDate = new DateTime(2016, 4, 20),
          // Customer = customer1, 
          Vendor = vendor1, 
          // OrderType = orderType1, 
          // OrderStatus = orderStatus1
        };
        
        // var order2 = new Order()
        // {
        //   NwfwOrderId = "nwfwSta937812",
        //   OrderDate = new DateTime(2016, 4, 7), 
        //   FulfillDate = new DateTime(2016, 6, 20),
        //   // Customer = customer2, 
        //   // Vendor = vendor2, 
        //   // OrderType = orderType2, 
        //   // OrderStatus = orderStatus2
        // };
        
        // var order3 = new Order()
        // {
        //   NwfwOrderId = "nwfwSta142937312",
        //   OrderDate = new DateTime(2016, 4, 11), 
        //   FulfillDate = new DateTime(2016, 6, 1),
        //   // Customer = customer1, 
        //   // Vendor = vendor2, 
        //   // OrderType = orderType1, 
        //   // OrderStatus = orderStatus4
        // };
        
        // var orderItem1 = new OrderItem()
        // {
        //   DiscountPercent = 10.0,
        //   Quantity = 3, 
        //   // Order = order1, 
        //   // Product = product1
        // };
        
        // var orderItem2 = new OrderItem()
        // {
        //   DiscountPercent = 0.0,
        //   Quantity = 2, 
        //   // Order = order1, 
        //   // Product = product2
        // };
        
        // var orderItem3 = new OrderItem()
        // {
        //   DiscountPercent = 0.0,
        //   Quantity = 4, 
        //   // Order = order1, 
        //   // Product = product3
        // };
        
        // var orderItem4 = new OrderItem()
        // {
        //   DiscountPercent = 5.0,
        //   Quantity = 4, 
        //   // Order = order2, 
        //   // Product = product3
        // };
        
        // var orderItem5 = new OrderItem()
        // {
        //   DiscountPercent = 0.0,
        //   Quantity = 1, 
        //   // Order = order3, 
        //   // Product = product1
        // };
        
        _context.Customers.Add(customer1);
        _context.Customers.Add(customer2);
        
        _context.OrderStatuses.Add(orderStatus1);
        _context.OrderStatuses.Add(orderStatus2);
        _context.OrderStatuses.Add(orderStatus3);
        _context.OrderStatuses.Add(orderStatus4);
        
        _context.OrderTypes.Add(orderType1);
        _context.OrderTypes.Add(orderType2);
        
        _context.ProductTypes.Add(productType1);
        _context.ProductTypes.Add(productType2);
        _context.ProductTypes.Add(productType3);
        
        _context.Vendors.Add(vendor1);
        _context.Vendors.Add(vendor2);
        
        _context.Wood.Add(wood1);
        _context.Wood.Add(wood2);
        _context.Wood.Add(wood3);
        
        // _context.Products.Add(product1);
        // _context.Products.Add(product2);
        // _context.Products.Add(product3);
        
        _context.Orders.Add(order1);
        // _context.Orders.Add(order2);
        // _context.Orders.Add(order3);
        
        // _context.OrderItems.Add(orderItem1);
        // _context.OrderItems.Add(orderItem2);
        // _context.OrderItems.Add(orderItem3);
        // _context.OrderItems.Add(orderItem4);
        // _context.OrderItems.Add(orderItem5);
        
        _context.SaveChanges();
      }
    }
  }
}
