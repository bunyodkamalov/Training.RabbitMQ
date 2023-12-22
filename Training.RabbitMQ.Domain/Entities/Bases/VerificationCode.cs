using Training.RabbitMQ.Domain.Common.Entities;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Domain.Entities.Bases;

public abstract class VerificationCode : Entity
{
    public VerificationCodeType CodeType { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset ExpiryTime { get; set; }

    public bool IsActive { get; set; }

    public string Code { get; set; } = default!;

    public string VerificationLink { get; set; } = default!;
}