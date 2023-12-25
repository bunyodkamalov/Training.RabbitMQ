using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Application.Common.Identity.Services;

public interface IPasswordGeneratorService
{
    string GeneratePassword();

    string GetValidatedPassword(string password, User user);
}