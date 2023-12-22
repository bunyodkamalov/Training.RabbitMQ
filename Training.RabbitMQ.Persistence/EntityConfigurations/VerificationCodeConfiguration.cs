using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.RabbitMQ.Domain.Entities.Bases;
using Training.RabbitMQ.Domain.Entities.User;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Persistence.EntityConfigurations;

public class VerificationCodeConfiguration : IEntityTypeConfiguration<VerificationCode>
{
    public void Configure(EntityTypeBuilder<VerificationCode> builder)
    {
        builder.HasDiscriminator(verificationCode => verificationCode.Type)
            .HasValue<UserInfoVerificationCode>(VerificationType.UserInfoVerificationCode);

        builder.Property(code => code.Code).IsRequired().HasMaxLength(64);
        builder.Property(code => code.VerificationLink).IsRequired().HasMaxLength(256);
    }
}