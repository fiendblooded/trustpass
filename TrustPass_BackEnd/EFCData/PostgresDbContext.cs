using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCData;

public class PostgresDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Match>? Matches { get; set; }
    public DbSet<Ticket>? Tickets { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // use postgresql
        optionsBuilder.UseNpgsql("Host=localhost;Database=trustpass;Username=postgres;Password=postgres");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // many-to-many relationship modeling:
        // https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many
        
        //User:
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(u => u.ExternalId).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.IdentityHash).IsRequired();
        // ! specifying ValueGeneratedOnAdd on a DateTime property will have no effect
        // https://learn.microsoft.com/en-us/ef/core/modeling/generated-properties?tabs=fluent-api
        // modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("NOW()");
        // modelBuilder.Entity<User>().Property(u => u.UpdatedAt).HasDefaultValueSql("timestamp AT TIME ZONE 'UTC'");
        
        //Match:
        modelBuilder.Entity<Match>().HasKey(m => m.Id);
        modelBuilder.Entity<Match>().Property(m => m.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Match>().Property(m => m.HomeTeam).IsRequired();
        modelBuilder.Entity<Match>().Property(m => m.AwayTeam).IsRequired();
        
        //Ticket:
        modelBuilder.Entity<User>()
            .HasMany(e => e.Matches)
            .WithMany(e => e.Users)
            .UsingEntity<Ticket>();
    }
}