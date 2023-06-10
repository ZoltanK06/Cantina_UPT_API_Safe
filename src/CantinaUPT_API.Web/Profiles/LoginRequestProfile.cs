using AutoMapper;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;

namespace CantinaUPT_API.Web.Profiles;

public class LoginRequestProfile: Profile
{
  public LoginRequestProfile()
  {
    this.CreateMap<LoginRequestDTO, LoginRequest>();
    this.CreateMap<LoginRequest, LoginRequestDTO>();
  }
}
