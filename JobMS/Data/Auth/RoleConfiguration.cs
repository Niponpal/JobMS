using JobMS.Auth_IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
namespace JobMS.Data.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = 1,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Description = "System Administrator"
            },
            new Role
            {
                Id = 2,
                Name = "EventManager",
                NormalizedName = "EVENTMANAGER",
                Description = "Manages events"
            },
            new Role
            {
                Id = 3,
                Name = "Student",
                NormalizedName = "STUDENT",
                Description = "Student user"
            }
        );
    }
}