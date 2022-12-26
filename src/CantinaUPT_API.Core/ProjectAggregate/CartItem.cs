using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class CartItem : EntityBase, IAggregateRoot
{
  public int Id { get; set; }
  public Meal Meal { get; set; }
  public int Quantity   { get; set; }
  public int UserId { get; set; }
}
