using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class LoginResponse
{
  public string Token { get; set; }
  public string Role { get; set; }
  public int? CanteenId { get; set; }
  public int UserId { get; set; }
  public string Error { get; set; }
}
