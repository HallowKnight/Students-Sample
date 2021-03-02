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
            schoolConfigurations.Property(s => s.Id)/*.UseSqlServerIdentityColumn()*/;
            
            schoolConfigurations
                .Property<string>("SchoolTitle")
                .IsRequired(true);

            schoolConfigurations
                .HasMany(s => s.Classes)
                .WithOne(c => c.School); 
        }
    }
}