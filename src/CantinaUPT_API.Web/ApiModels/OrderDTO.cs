using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Web.ApiModels;

public class OrderDTO
{
  public int Id { get; set; }
  public DateTime OrderDate { get; set; }
  public OrderStatus Status { get; set; }
  public double TotalPrice { get; set; }
  public List<CartItem> CartItems { get; set; }
}
