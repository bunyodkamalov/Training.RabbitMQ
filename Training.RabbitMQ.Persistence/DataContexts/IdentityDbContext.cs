using Microsoft.EntityFrameworkCore;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Persistence.DataContexts;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    public DbSet<UserSettings> UserSettings => Set<UserSettings>();

    public DbSet<UserInfoVerificationCode> UserInfoVerificationCodes => Set<UserInfoVerificationCode>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}