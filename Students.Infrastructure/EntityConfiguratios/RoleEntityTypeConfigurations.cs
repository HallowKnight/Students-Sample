using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.RoleAggregate;

namespace Students.Infrastructure.EntityConfiguratios;

public class RoleEntityTypeConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> roleConfigurations)
    {
        roleConfigurations.ToTable("Roles");
        roleConfigurations.HasKey(r => r.Id);
        roleConfigurations.Property(r => r.Id);

        roleConfigurations
            .Property<string>("RoleTitle")
            .IsRequired();

        roleConfigurations
            .HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role);
    }
}