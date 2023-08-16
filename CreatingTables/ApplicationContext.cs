using System;
using System.Reflection.Metadata;
using Azure;
using CreatingTables.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CreatingTables
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<NewCustomer> NewCustomers { get; set; }
        public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
        public DbSet<BestSellerProduct> BestSellerProducts { get; set; }
        public DbSet<CancelledOrder> CancelledOrders { get; set; }
        public DbSet<CallDetail> CallDetails { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationContext()
        {
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;MultipleActiveResultSets=true;database=EntityFrameworkTestNew;User=sa;Password=your_password123;TrustServerCertificate=true;");
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }


        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
         {
             builder.AddProvider(new MyLoggerProvider());
         });


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Employee>()
            .ToTable("Employees", t => t.IsTemporal());

            modelBuilder.Entity<CustomerOrder>(pc =>
            {
                pc.HasNoKey();
                pc.ToView("CutomerOrderView");
            });
            modelBuilder.Entity<MyOutput>().HasNoKey();
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<CallDetail>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.callDetails)
                .HasForeignKey(o => o.CustomerId);

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
                .HasIndex(o => new { o.Status, o.CustomerId });
            modelBuilder.Entity<NewCustomer>()
                .HasAlternateKey(c => c.Email);

            modelBuilder.Entity<Customer>().HasQueryFilter(c => !c.IsDeleted);
        }
    }
}

