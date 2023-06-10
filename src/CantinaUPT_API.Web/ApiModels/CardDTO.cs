namespace CantinaUPT_API.Web.ApiModels;

public class CardDTO
{
  public int? Id { get; set; } = null;
  public string Number { get; set; }
  public string Name { get; set; }
  public DateTime Expiry { get; set; }
  public string Cvc { get; set; }
}
