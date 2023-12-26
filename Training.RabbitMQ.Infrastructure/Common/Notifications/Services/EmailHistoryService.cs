using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Training.RabbitMQ.Application.Common.Notifications.Services;
using Training.RabbitMQ.Domain.Common.Query;
using Training.RabbitMQ.Domain.Entities.Subs;
using Training.RabbitMQ.Domain.Enums;
using Training.RabbitMQ.Persistence.Extensions;
using Training.RabbitMQ.Persistence.Repositories.Interfaces;

namespace Training.RabbitMQ.Infrastructure.Common.Notifications.Services;

public class EmailHistoryService : IEmailHistoryService
{
    private readonly IEmailHistoryRepository _emailHistoryRepository;
    private readonly IValidator<EmailHistory> _emailHistoryValidator;

    public EmailHistoryService(IEmailHistoryRepository emailHistoryRepository, IValidator<EmailHistory> emailHistoryValidator)
    {
        _emailHistoryRepository = emailHistoryRepository;
        _emailHistoryValidator = emailHistoryValidator;
    }

    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        return await _emailHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);
    }

    public async ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = await _emailHistoryValidator.ValidateAsync(
            emailHistory,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken
        );
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await _emailHistoryRepository.CreateAsync(emailHistory, saveChanges, cancellationToken);
    }
}