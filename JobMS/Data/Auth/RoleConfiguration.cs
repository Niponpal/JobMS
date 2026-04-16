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
                Name = "Employer",
                NormalizedName = "EMPLOYER",
                Description = "Employer job postings"
            },
            new Role
            {
                Id = 3,
                Name = "Candidate",
                NormalizedName = "CANDIDATE",
                Description = "Candidate user"
            }
        );
    }
}