using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1.Data;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options)
    :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Product>()
            .Property(x => x.Price)
            .HasPrecision(8, 2);
    }

    public DbSet<Product> Products { get; set; }
}