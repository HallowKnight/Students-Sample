using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Infrastructure.EntityConfiguratios
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable("Users");
            userConfiguration.HasKey(u => u.Id);
            userConfiguration.Property(u => u.Id);

            userConfiguration
                .Property<string>("UserName")
                .IsRequired();


            userConfiguration
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User);

            userConfiguration.HasMany(u => u.UserLessons)
                .WithOne(ul => ul.User);

            userConfiguration
                .HasOne(u => u.Class)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.ClassId);
        }
    }
}