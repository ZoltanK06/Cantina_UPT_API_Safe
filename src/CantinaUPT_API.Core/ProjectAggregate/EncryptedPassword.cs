using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class EncryptedPassword
{
  public byte[] PasswordHash { get; set; }
  public byte[] PasswordSalt { get; set; }
}
