using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel.Interfaces;
using CantinaUPT_API.SharedKernel;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class Disponibility : EntityBase, IAggregateRoot
{
  public int MealId { get; set; }
  public int CanteenId { get; set; }
  public bool Disposable { get; set; }
}
