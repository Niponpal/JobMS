using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static JobMS.AuthIdentityModel.IdentityModel;

namespace JobMS.Data.Auth
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Description = "Default role assigned to all User."

            }, new Role
            {
                Id = 2,
                Name = "User",
                NormalizedName = "User",
                Description = "Default role assigned to all Users."
            });
        }
    }

    }
