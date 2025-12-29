using Tasker.Domain.Entities.User;

namespace Tasker.Application.Abstraction.Email;

public interface IEmailService
{
    System.Threading.Tasks.Task SendEmailAsync(EmailAddress emailAddress, string subject, string body,
        CancellationToken cancellationToken = default);
}