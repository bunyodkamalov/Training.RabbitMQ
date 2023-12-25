using Training.RabbitMQ.Application.Common.Identity.Models;

namespace Training.RabbitMQ.Application.Common.Identity.Services;

public interface IAuthAggregationService
{
    ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default);
}