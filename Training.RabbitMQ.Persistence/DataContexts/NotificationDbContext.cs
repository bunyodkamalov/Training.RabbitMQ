using Microsoft.EntityFrameworkCore;
using Training.RabbitMQ.Domain.Entities.Subs;

namespace Training.RabbitMQ.Persistence.DataContexts;

public class NotificationDbContext : DbContext
{
    public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
    {
    }

    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();

    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDbContext).Assembly);
    }
}