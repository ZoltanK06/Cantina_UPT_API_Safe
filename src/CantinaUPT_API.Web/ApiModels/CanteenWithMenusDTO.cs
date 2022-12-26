using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Web.ApiModels;
public class CanteenWithMenusDTO
{
  public int Id { get; set; }
  public List<DailyMenu> menus { get; set; }

  public CanteenWithMenusDTO(int id, List<DailyMenu> menus)
  {
    Id = id;
    this.menus = menus;
  }
}
