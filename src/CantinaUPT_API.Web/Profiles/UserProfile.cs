using AutoMapper;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;

namespace CantinaUPT_API.Web.Profiles;

public class UserProfile: Profile
{
  public UserProfile()
  {
    this.CreateMap<User, UserDTO>();
  }
}
