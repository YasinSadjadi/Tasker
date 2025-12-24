using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasker.Domain.Entities.User;

namespace Tasker.DataAccess.Database.EntityConfigurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var converter = new ValueConverter<User.UserPassword, string>(
            v => v.PasswordHash,
            v => new User.UserPassword(v, true));

        builder.Property(u => u.Password)
            .HasConversion(converter);
    }
}
