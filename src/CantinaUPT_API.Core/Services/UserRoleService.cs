using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.Services;
public class UserRoleService: IUserRoleService
{
  public IReadRepository<UserRoles> _rolesRepo;

  public UserRoleService(IReadRepository<UserRoles> rolesRepo)
  {
    _rolesRepo = rolesRepo;
  }

  public async Task<UserRoles> GetRoleById(int roleId)
  {
    return await _rolesRepo.GetByIdAsync(roleId);
  }
}
