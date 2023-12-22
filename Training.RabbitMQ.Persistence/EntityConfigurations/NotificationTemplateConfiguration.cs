using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.RabbitMQ.Domain.Entities.Bases;
using Training.RabbitMQ.Domain.Entities.Subs;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Persistence.EntityConfigurations;

public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.Property(template => template.Content).HasMaxLength(129_536);

        builder.HasIndex(
                template => new
                {
                    template.Type,
                    template.TemplateType
                }
            )
            .IsUnique();

        builder.ToTable("NotificationTemplates")
            .HasDiscriminator(emailTemplate => emailTemplate.Type)
            .HasValue<EmailTemplate>(NotificationType.Email);
    }
}