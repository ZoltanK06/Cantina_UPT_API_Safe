using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel.Interfaces;
using CantinaUPT_API.SharedKernel;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class User : EntityBase, IAggregateRoot
{
  public string Username { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
  public string Firstname { get; set; }
  public string Lastname { get; set; }
}
