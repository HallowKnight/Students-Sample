using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.UserAggregate;


namespace Students.Infrastructure.EntityConfiguratios
{
    public class UserLessonsEntityTypeConfigurations : IEntityTypeConfiguration<UserLessons>
    {
        public void Configure(EntityTypeBuilder<UserLessons> userLessonsConfigurations)
        {
            userLessonsConfigurations.ToTable("UserLessons");
            userLessonsConfigurations.HasKey(ul => ul.Id);
            userLessonsConfigurations.Property(ul => ul.Id)/*.UseSqlServerIdentityColumn()*/;

            userLessonsConfigurations
                .HasOne<User>(ul => ul.User)
                .WithMany(u => u.UserLessons)
                .HasForeignKey(ul=>ul.UserId);

            userLessonsConfigurations
                .HasOne<Lesson>(ul => ul.Lesson)
                .WithMany(l => l.UserLessons)
                .HasForeignKey(l=>l.LessonId);
        }
    }
}