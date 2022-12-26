using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class Order : EntityBase, IAggregateRoot
{
  public int UserId { get; set; }
  public DateTime OrderDate { get; set; }
  public OrderStatus Status { get; set; }
  public double TotalPrice { get; set; }
  public List<CartItem> CartItems { get; set; }

}
