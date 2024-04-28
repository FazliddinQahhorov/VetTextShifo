using Microsoft.EntityFrameworkCore;
using VetTextShifo.Domain.Entities;
using VetTextShifo.Domain.Entities.Attachments;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.NewsModel;
using VetTextShifo.Domain.Entities.ProductDetails.Products;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {
        Database.Migrate();
    }

    DbSet<AttachmentModel> AttachmentProducts { get; set; }
    DbSet<Category> Catigories { get; set; }
    DbSet<Location> Locations { get; set; }
    DbSet<NewsModelEng> NewsEng { get; set; }
    DbSet<NewsModelRus> NewsRus { get; set; }
    DbSet<NewsModelUzb> NewsUzb { get; set; }
    DbSet<ProductEng> ProductsEng { get; set; }
    DbSet<ProductRus> ProductsRus { get; set; }
    DbSet<ProductUzb> ProductsUzb { get; set; }
    DbSet<Admin> Admins { get; set; }
    DbSet<Customer> Customers { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<Likes> Likes { get; set; }
    DbSet<Comment> Comments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>()
            .HasIndex(u => u.email)
            .IsUnique();
        modelBuilder.Entity<ProductEng>()
            .HasIndex(u => u.ModelName)
            .IsUnique();
        modelBuilder.Entity<ProductRus>()
            .HasIndex(u => u.ModelName)
            .IsUnique();
        modelBuilder.Entity<ProductUzb>()
            .HasIndex(u => u.ModelName)
            .IsUnique();

    }
}
