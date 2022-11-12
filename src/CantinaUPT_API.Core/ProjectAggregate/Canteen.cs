using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel.Interfaces;
using CantinaUPT_API.SharedKernel;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class Canteen : EntityBase, IAggregateRoot
{
  public string Location { get; set; }
  public List<Meal> Meals { get; set; }
  public List<DailyMenu> Menus { get; set; }
}
