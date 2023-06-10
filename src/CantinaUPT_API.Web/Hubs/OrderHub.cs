using Microsoft.AspNetCore.SignalR;

namespace CantinaUPT_API.Web.Hubs;

public class OrderHub: Hub
{
  public async Task SendOrder()
  {
    await Clients.All.SendAsync("RecieveOrder");
  }
}
