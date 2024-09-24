using DailySchedule.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailySchedule.Infrastructure.Data.Configurations
{
    internal class UserConfiguration: IEntityTypeConfiguration<User>
    {
        private const int MAX_LOGIN_LENGTH = 50;
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Login)
                .HasMaxLength(MAX_LOGIN_LENGTH)
                .IsRequired();
            builder.Property(b => b.PasswordHash)
                .IsRequired();
        }
    }
}
