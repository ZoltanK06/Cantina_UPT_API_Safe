using AutoMapper;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;

namespace CantinaUPT_API.Web.Profiles;

public class CartProfile : Profile
{
  public CartProfile()
  {
    this.CreateMap<CartItemDTO, CartItem>();
    this.CreateMap<CartItem, CartItemDTO>();
  }
}
