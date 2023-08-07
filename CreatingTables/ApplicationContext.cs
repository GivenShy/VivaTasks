using System;
using System.Reflection.Metadata;
using CreatingTables.Models;
using Microsoft.EntityFrameworkCore;

namespace CreatingTables
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<ProductDetails> ProductDetails { get; set; }

        public ApplicationContext()
        {
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;MultipleActiveResultSets=true;database=EntityFrameworkTestNew;User=sa;Password=your_password123;TrustServerCertificate=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CutomerId);

            modelBuilder.Entity<ProductDetails>()
                .HasOne(e => e.Product)
                .WithOne(p => p.ProductDetails)
                .HasForeignKey<ProductDetails>(e => e.ProductId)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .HasAlternateKey(c => c.Email);

            modelBuilder.Entity<Product>()
                .ToTable(t => t.HasCheckConstraint("StockQuantity",
                "StockQuantity>=0 AND StockQuantity<=20")
                .HasName("QuantityLimit"));
            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderDate);

            modelBuilder.Entity<Order>()
                .HasIndex(o => new { o.Status, o.CutomerId });


        }
    }
}

