using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence;

public class LegayPortalContext : DbContext
{
    public LegayPortalContext(DbContextOptions<LegayPortalContext> options) : base(options)
    {

    }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Application> Applications { get; set; }
}