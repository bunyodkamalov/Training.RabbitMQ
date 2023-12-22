using System.Linq.Expressions;
using Training.RabbitMQ.Domain.Entities.Subs;

namespace Training.RabbitMQ.Persistence.Repositories.Interfaces;

public interface IEmailHistoryRepository
{
    IQueryable<EmailHistory> Get(Expression<Func<EmailHistory, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default);
}