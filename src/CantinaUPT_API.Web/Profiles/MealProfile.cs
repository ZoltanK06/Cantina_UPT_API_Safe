using AutoMapper;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;

namespace CantinaUPT_API.Web.Profiles;

public class MealProfile : Profile
{
  public MealProfile()
  {
    this.CreateMap<Meal, MealDTO>();
    this.CreateMap<MealDTO, Meal>();
  }
}
