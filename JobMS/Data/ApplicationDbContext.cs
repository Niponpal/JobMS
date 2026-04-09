using Microsoft.EntityFrameworkCore;
namespace JobMS.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Models.Application> Applications { get; set; }
    public DbSet<Models.Job> Jobs { get; set; }
}
