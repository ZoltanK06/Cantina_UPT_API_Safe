using AutoMapper;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;

namespace CantinaUPT_API.Web.Profiles;

public class CanteenProfile : Profile
{
  public CanteenProfile()
  {
    this.CreateMap<Canteen, CanteensDetailsDTO>();
    this.CreateMap<CanteensDetailsDTO, Canteen>();
  }
}
