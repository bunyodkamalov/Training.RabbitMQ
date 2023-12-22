using Training.RabbitMQ.Domain.Common.Entities;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Domain.Entities.User;

public class User  : Entity
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public int Age { get; set; }

    public string EmailAddress { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public bool IsEmailAddressVerified { get; set; }

    public RoleType Role { get; set; }

    public UserSettings? UserSettings { get; set; }
    
}