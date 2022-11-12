using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel.Interfaces;
using CantinaUPT_API.SharedKernel;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class DailyMenu : EntityBase, IAggregateRoot
{
  public List<Meal> meals { get; set; }
  public DateTime date { get; set; }
  public bool IsActive { get; set; }
}
