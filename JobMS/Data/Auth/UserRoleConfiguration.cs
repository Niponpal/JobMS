using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static JobMS.AuthIdentityModel.IdentityModel;

namespace JobMS.Data.Auth
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(new UserRole
            {
                RoleId = 1,
                UserId = 1,
            });
        }
    }
}
