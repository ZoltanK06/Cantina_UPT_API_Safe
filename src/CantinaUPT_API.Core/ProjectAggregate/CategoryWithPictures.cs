using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantinaUPT_API.Core.ProjectAggregate;
public class CategoryWithPictures
{
  public int Id { get; set; }
  public string CategoryName { get; set; }
  public string PictureURL { get; set; }
}
