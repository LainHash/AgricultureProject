using Agriculture.Domain.Entites.Identity;

namespace Agriculture.Application.Services.Guest
{
    public interface IPlayerInitializationService
    {
        Task InitializeAsync(User user, CancellationToken cancellationToken);
    }
}
