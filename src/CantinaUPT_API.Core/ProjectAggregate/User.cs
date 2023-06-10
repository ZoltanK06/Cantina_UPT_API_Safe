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
  public byte[] PasswordHash { get; set; }
  public byte[] PasswordSalt { get; set; }
  public UserRoles Role { get; set; }
  public Canteen? Canteen { get; set; }
  public List<Card> Cards { get; set; } = new List<Card>();
}
