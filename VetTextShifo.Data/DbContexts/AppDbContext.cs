using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
    DbSet<AttachmentForNew> attachmentForNews { get; set; }
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
        modelBuilder.Entity<Customer>()
            .HasIndex(u => u.CustomerIp)
            .IsUnique();

        modelBuilder.Entity<NewsModelEng>()
           .HasOne(n => n.Attachment)
           .WithOne(a => a.NewsModelEng)
           .HasForeignKey<AttachmentForNew>(a => a.NewsModelEngId);

        modelBuilder.Entity<NewsModelRus>()
            .HasOne(n => n.Attachment)
            .WithOne(a => a.NewsModelRus)
            .HasForeignKey<AttachmentForNew>(a => a.NewsModelRusId);

        modelBuilder.Entity<NewsModelUzb>()
            .HasOne(n => n.Attachment)
            .WithOne(a => a.NewsModelUzb)
            .HasForeignKey<AttachmentForNew>(a => a.NewsModelUzbId);

        modelBuilder.Entity<ProductEng>()
            .HasMany(p => p.attachments) // One ProductEng has many Attachments
            .WithOne(a => a.ProductEng) // Each Attachment belongs to one ProductEng
            .HasForeignKey(a => a.ProductEngId); // Foreign key property in AttachmentModel

        modelBuilder.Entity<ProductRus>()
            .HasMany(p => p.attachments) // One ProductRus has many Attachments
            .WithOne(a => a.ProductRus) // Each Attachment belongs to one ProductRus
            .HasForeignKey(a => a.ProductRusId); // Foreign key property in AttachmentModel

        modelBuilder.Entity<ProductUzb>()
            .HasMany(p => p.attachments) // One ProductUzb has many Attachments
            .WithOne(a => a.ProductUzb) // Each Attachment belongs to one ProductUzb
            .HasForeignKey(a => a.ProductUzbId);
    }
}
