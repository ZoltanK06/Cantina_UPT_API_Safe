using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Web.ApiModels;

public class OrderDTO
{
  public int? Id { get; set; }
  public int CanteenId { get; set; }
  public int? OrderNumber { get; set; }
  public int UserId { get; set; }
  public DateTime OrderDate { get; set; }
  public int? StatusId { get; set; }
  public string? Status { get; set; }
  public double TotalPrice { get; set; }
  public int? PrepareTime { get; set; }
  public List<OrderItemDTO> OrderItemsDTO { get; set; }
}
