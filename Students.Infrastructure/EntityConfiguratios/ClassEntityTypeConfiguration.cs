using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Infrastructure.EntityConfiguratios
{
    public class ClassEntityTypeConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> classConfigurations)
        {
            classConfigurations.ToTable("Classes");
            classConfigurations.HasKey(c => c._Id);
            classConfigurations.Property(c => c._Id)/*.UseSqlServerIdentityColumn()*/;
            
            classConfigurations
                .Property<string>("ClassTitle")
                .IsRequired(true);

            classConfigurations
                .HasOne(c => c.School)
                .WithMany(s => s.Classes)
                .HasForeignKey(c => c.SchoolId);

            classConfigurations
                .HasMany(c => c.Users)
                .WithOne(u => u.Class);
        }
    }
}