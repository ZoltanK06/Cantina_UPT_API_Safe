using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class UserRoles: EntityBase, IAggregateRoot
{
  public string RoleName { get; set; }
}
