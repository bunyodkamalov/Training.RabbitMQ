﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Persistence.EntityConfigurations;

public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
{
    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder.HasOne<User>().WithOne(user => user.UserSettings).HasForeignKey<UserSettings>(settings => settings.Id);
    }
}