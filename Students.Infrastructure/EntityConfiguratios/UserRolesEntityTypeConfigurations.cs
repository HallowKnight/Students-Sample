using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Infrastructure.EntityConfiguratios;

public class UserRolesEntityTypeConfigurations : IEntityTypeConfiguration<UserRoles>
{
    public void Configure(EntityTypeBuilder<UserRoles> userRolesConfigurations)
    {
        userRolesConfigurations.ToTable("UserRoles");
        userRolesConfigurations.HasKey(ur => ur.Id);
        userRolesConfigurations.Property(ur => ur.Id);

        // Relation to Users
        userRolesConfigurations
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);


        //Relation to Roles
        userRolesConfigurations
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }
}