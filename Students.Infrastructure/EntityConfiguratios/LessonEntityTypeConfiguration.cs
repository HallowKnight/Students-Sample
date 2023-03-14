using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.LessonAggregate;

namespace Students.Infrastructure.EntityConfiguratios;

public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> lessonConfiguration)
    {
        lessonConfiguration.ToTable("Lessons");
        lessonConfiguration.HasKey(l => l.Id);
        lessonConfiguration.Property(l => l.Id);

        lessonConfiguration
            .Property<string>("LessonTitle")
            .IsRequired();

        lessonConfiguration
            .HasMany(l => l.UserLessons)
            .WithOne(ul => ul.Lesson);
    }
}