using AutoMapper;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.VisualBasic;

namespace CantinaUPT_API.Web.Profiles;

public class MealProfile : Profile
{
  public MealProfile()
  {
    this.CreateMap<Meal, MealDTO>();
    this.CreateMap<MealDTO, Meal>();
    this.CreateMap<Meal, MealResponseDTO>().ForMember(meal => meal.Category, opt => opt.Ignore()).ForMember(meal => meal.Portion, opt => opt.Ignore());
    this.CreateMap<Meal, OrderedMealDTO>();
  }
}
