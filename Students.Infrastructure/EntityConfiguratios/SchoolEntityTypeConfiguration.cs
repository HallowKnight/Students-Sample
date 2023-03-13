using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Infrastructure.EntityConfiguratios
{
    public class SchoolEntityTypeConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> schoolConfigurations)
        {
            schoolConfigurations.ToTable("Schools");
            schoolConfigurations.HasKey(s => s.Id);
            schoolConfigurations.Property(s => s.Id);

            schoolConfigurations
                .Property<string>("SchoolTitle")
                .IsRequired();

            schoolConfigurations
                .HasMany(s => s.Classes)
                .WithOne(c => c.School);
        }
    }
}