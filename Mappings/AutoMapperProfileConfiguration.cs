using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using nwfw.Models;
using nwfw.ViewModels;

namespace nwfw.Mappings
{
  public class AutoMapperProfileConfiguration : Profile
  {
    protected override void Configure()
    {
      CreateMap<Customer, CustomerViewModel>().ReverseMap();
      CreateMap<Customer, CustomerNavViewModel>().ReverseMap();
      CreateMap<Order, OrderViewModel>().ReverseMap();
      CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
      CreateMap<OrderStatus, OrderStatusNavViewModel>().ReverseMap();
      CreateMap<Product, ProductViewModel>().ReverseMap();
      CreateMap<Product, ProductNavViewModel>().ReverseMap();
      CreateMap<ProductType, ProductTypeViewModel>().ReverseMap();
      CreateMap<Vendor, VendorNavViewModel>().ReverseMap();
      CreateMap<Vendor, VendorViewModel>().ReverseMap();
      CreateMap<Wood, WoodViewModel>().ReverseMap();
    }
  }
}
