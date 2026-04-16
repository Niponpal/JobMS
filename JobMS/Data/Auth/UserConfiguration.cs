using JobMS.Auth_IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMS.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.HasData(new User
        {
            Id = 1,
            Email = "admin@localhost.com",
            NormalizedEmail = "ADMIN@LOCALHOST.COM",
            UserName = "admin@localhost.com",
            NormalizedUserName = "ADMIN@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        }, new User
        {
            Id = 2,
            Email = "employer@localhost.com",
            NormalizedEmail = "EMPLOYER@LOCALHOST.COM",
            UserName = "employer@localhost.com",
            NormalizedUserName = "EMPLOYER@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        }, new User
        {
            Id = 3,
            Email = "candidate@localhost.com",
            NormalizedEmail = "CANDIDATE@LOCALHOST.COM",
            UserName = "candidate@localhost.com",
            NormalizedUserName = "CANDIDATE@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        });
    }
}

