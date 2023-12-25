using Training.RabbitMQ.Domain.Entities.Subs;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Application.Common.Identity.Services;

public interface IAccessTokenGeneratorService
{
    AccessToken GetToken(User user);

    Guid GetTokenId(string accessToken);
}