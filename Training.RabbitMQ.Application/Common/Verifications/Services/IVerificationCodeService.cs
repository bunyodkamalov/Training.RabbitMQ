using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Application.Common.Verifications.Services;

public interface IVerificationCodeService
{
    ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default);
}