using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Infrastructure;

public class DataContext:DbContext
{
    protected DataContext()
    {
    }

    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Book>()
            .HasKey(x => x.Id);
        modelBuilder
            .Entity<Review>()
            .HasKey(x => x.Id);
        modelBuilder
            .Entity<Rating>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Rating>()
            .HasOne(x => x.Book)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.BookId);
        modelBuilder.Entity<Review>()
            .HasOne(x => x.Book)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.BookId);  
        base.OnModelCreating(modelBuilder);
    }
}
