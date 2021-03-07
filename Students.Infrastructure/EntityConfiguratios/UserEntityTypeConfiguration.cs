using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.SchoolAggregate;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Infrastructure.EntityConfiguratios
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable("Users");
            userConfiguration.HasKey(u=>u._Id);
            userConfiguration.Property(u => u._Id);

            userConfiguration
                .Property<string>("UserName")
                .IsRequired(true);



            userConfiguration
                .HasMany<UserRoles>(u => u.UserRoles)
                .WithOne(ur => ur.User);

            userConfiguration.HasMany<UserLessons>(u => u.UserLessons)
                .WithOne(ul => ul.User);
            
            userConfiguration
                .HasOne<Class>(u=>u.Class)
                .WithMany(c=>c.Users)
                .HasForeignKey(u=>u.ClassId);

            
        }
    }
}