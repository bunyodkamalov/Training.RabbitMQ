using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Application.Common.Identity.Services;

public interface IAccountAggregatorService
{
    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}