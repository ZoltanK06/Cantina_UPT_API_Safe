using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class Card: EntityBase, IAggregateRoot
{
  public string EncryptedNumber { get; set; }
  public string Name { get; set; }
  public DateTime Expiry { get; set; }
  public string EncryptedCvc { get; set; }
}
