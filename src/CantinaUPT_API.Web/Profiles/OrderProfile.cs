using AutoMapper;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;

namespace CantinaUPT_API.Web.Profiles;

public class OrderProfile : Profile
{
  public OrderProfile()
  {
    this.CreateMap<Order, OrderDTO>();
    this.CreateMap<OrderDTO, Order>();
  }
}
