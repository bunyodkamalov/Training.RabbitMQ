using System.Linq.Expressions;
using Training.RabbitMQ.Domain.Entities.Subs;

namespace Training.RabbitMQ.Persistence.Repositories.Interfaces;

public interface IEmailTemplateRepository
{
    IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default);
}