using System.Linq.Expressions;
using Training.RabbitMQ.Domain.Entities.Subs;
using Training.RabbitMQ.Persistence.Caching.Brokers;
using Training.RabbitMQ.Persistence.DataContexts;
using Training.RabbitMQ.Persistence.Repositories.Interfaces;

namespace Training.RabbitMQ.Persistence.Repositories;

public class EmailTemplateRepository(NotificationDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<EmailTemplate, NotificationDbContext>(dbContext, cacheBroker), IEmailTemplateRepository
{
    public new IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        return base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }
}