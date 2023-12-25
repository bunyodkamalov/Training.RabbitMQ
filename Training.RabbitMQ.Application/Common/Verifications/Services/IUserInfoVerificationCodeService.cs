using Training.RabbitMQ.Domain.Entities.User;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Application.Common.Verifications.Services;

public interface IUserInfoVerificationCodeService : IVerificationCodeService
{
    IList<string> Generate();

    ValueTask<(UserInfoVerificationCode Code, bool isValid)> GetByCodeAsync(string code, CancellationToken cancellationToken);

    ValueTask<UserInfoVerificationCode> CreateAsync(VerificationCodeType codeType, Guid userId, CancellationToken cancellationToken = default);

    ValueTask DeactivateAsync(Guid codeId, bool saveChanges, CancellationToken cancellationToken = default);
}