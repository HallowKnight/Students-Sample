using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Infrastructure.EntityConfiguratios
{
    public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> lessonConfiguration)
        {

            lessonConfiguration.ToTable("Lessons");
            lessonConfiguration.HasKey(l => l.Id);
            lessonConfiguration.Property(l => l.Id)/*.UseSqlServerIdentityColumn()*/;
            lessonConfiguration
                .Property<string>("LessonTitle")
                .IsRequired(true);

            lessonConfiguration
                .HasMany<UserLessons>(l=>l.UserLessons)
                .WithOne(ul=>ul.Lesson)
                .HasForeignKey(ul=>ul.Id);
        }
    }
}