using JobMS.Auth_IdentityModel;
using JobMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

public class ApplicationDbContext : IdentityDbContext<
    User,
    Role,
    long,
    UserClaim,
    UserRole,
    UserLogin,
    RoleClaim,
    UserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ========================
        // USER RELATION
        // ========================
        modelBuilder.Entity<Application>()
            .HasOne(a => a.User)
            .WithMany()   // (optional: later use User.Applications)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // ========================
        // JOB RELATION
        // ========================
        modelBuilder.Entity<Application>()
            .HasOne(a => a.Job)
            .WithMany(j => j.Applications)
            .HasForeignKey(a => a.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        // ========================
        // DECIMAL FIX (SAFE)
        // ========================
        modelBuilder.Entity<Application>()
            .Property(x => x.CGPA)
            .HasPrecision(3, 2);

        modelBuilder.Entity<Application>()
            .Property(x => x.PresentSalary)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Application>()
            .Property(x => x.ExpectionSalary)
            .HasPrecision(18, 2);

        // REMOVE unnecessary configs if not needed
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}


//using JobMS.Auth_IdentityModel;
//using JobMS.Data.Configuration;
//using JobMS.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using System.Reflection;

//public class ApplicationDbContext : IdentityDbContext<
//    User,
//    Role,
//    long,
//    UserClaim,
//    UserRole,
//    UserLogin,
//    RoleClaim,
//    UserToken>
//{
//    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//        : base(options)
//    {
//    }

//    public DbSet<Job> Jobs { get; set; }
//    public DbSet<Application> Applications { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        modelBuilder.Entity<Application>()
//        .HasOne(a => a.User)
//        .WithMany()
//        .HasForeignKey(a => a.UserId)
//        .OnDelete(DeleteBehavior.Restrict);

//        modelBuilder.Entity<Application>() 
//            .HasOne(a => a.Job)
//            .WithMany(j => j.Applications)
//            .HasForeignKey(a => a.JobId);

//        //// ✅ SEED CONFIGURATION APPLY
//        //modelBuilder.ApplyConfiguration(new RoleConfiguration());
//        //modelBuilder.ApplyConfiguration(new UserConfiguration());
//        //modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

//        // ✅ AUTOMATICALLY APPLY ALL CONFIGURATIONS IN THE ASSEMBLY

//        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
//    }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.ConfigureWarnings(warnings =>
//            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

//        optionsBuilder.LogTo(Console.WriteLine);
//    }
//}