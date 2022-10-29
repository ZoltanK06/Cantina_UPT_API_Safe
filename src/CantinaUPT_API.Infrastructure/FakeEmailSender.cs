using CantinaUPT_API.Core.Interfaces;

namespace CantinaUPT_API.Infrastructure;

public class FakeEmailSender : IEmailSender
{
  public Task SendEmailAsync(string to, string from, string subject, string body)
  {
    return Task.CompletedTask;
  }
}
