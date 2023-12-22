using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Persistence.EntityConfigurations;

public class UserInfoVerificationCodeConfiguration : IEntityTypeConfiguration<UserInfoVerificationCode>
{
    public void Configure(EntityTypeBuilder<UserInfoVerificationCode> builder)
    {
        builder.HasOne<User>().WithMany().HasForeignKey(code => code.UserId);
    }
}