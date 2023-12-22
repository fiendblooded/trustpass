using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCData;

public class TrustPassDbContext : DbContext
{
    public DbSet<User>? Users { get; set; } = null;

    
    public TrustPassDbContext(DbContextOptions<TrustPassDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // use postgresql
        // optionsBuilder.UseNpgsql("Host=localhost;Database=trustpass;Username=postgres;Password=postgres");
        
        // use sqlite
        // optionsBuilder.UseSqlite("Data Source=trustpass.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(u => u.id).IsRequired();
    }
}