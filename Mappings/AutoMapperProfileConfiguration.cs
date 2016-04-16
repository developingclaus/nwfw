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
      CreateMap<Order, OrderViewModel>().ReverseMap();
      CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
      CreateMap<Wood, WoodViewModel>().ReverseMap();
      CreateMap<Vendor, VendorWithoutOrdersViewModel>().ReverseMap();
      CreateMap<Vendor, VendorViewModel>().ReverseMap();
    }
  }
}
