using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.SharedKernel.Interfaces;
using CantinaUPT_API.SharedKernel;
using System.ComponentModel;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class Meal : EntityBase, IAggregateRoot
{
   public string Name { get; set; }
  public string Description { get; set; }
  public double Price { get; set; }
  public string PictureURL { get; set; }
  public Portion Portion { get; set; }
  public Category Category { get; set; }
}
