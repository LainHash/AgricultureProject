using Agriculture.Application.Models.Messages;

namespace Agriculture.Application.Services.Emails
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, EmailMessage message, CancellationToken cancellationToken = default);
    }
}
