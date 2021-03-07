using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Infrastructure.EntityConfiguratios
{
    public class RoleEntityTypeConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> roleConfigurations)
        {

            roleConfigurations.ToTable("Roles");
            roleConfigurations.HasKey(r => r._Id);
            roleConfigurations.Property(r => r._Id);
           
            roleConfigurations
                .Property<string>("RoleTitle")
                .IsRequired(true);

            roleConfigurations
                .HasMany<UserRoles>(r => r.UserRoles)
                .WithOne(ur => ur.Role);
        }
    }
}