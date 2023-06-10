using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class RegisterRequest
{
  public string Username { get; set; }
  public string Email { get; set; }
  public byte[] PasswordHash { get; set; }
  public byte[] PasswordSalt { get; set; }
  public int Role { get; set; }
  public Canteen? Canteen { get; set; }
}
