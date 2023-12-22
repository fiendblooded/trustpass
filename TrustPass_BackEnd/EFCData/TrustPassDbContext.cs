using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCData;

public class TrustPassDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    
    public TrustPassDbContext(){}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // use postgresql
        optionsBuilder.UseNpgsql("Host=localhost;Database=trustpass;Username=postgres;Password=postgres");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //define primary key
        modelBuilder.Entity<User>().HasKey(u => u.id);
    }
}