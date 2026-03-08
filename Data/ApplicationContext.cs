using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BusinessModel> Businesses { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User relationships
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Businesses)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Products)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Business relationships
            modelBuilder.Entity<BusinessModel>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Business)
                .HasForeignKey(p => p.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BusinessModel>()
                .HasMany(b => b.Transactions)
                .WithOne(t => t.Business)
                .HasForeignKey(t => t.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product relationships
            modelBuilder.Entity<ProductModel>()
                .HasMany(p => p.Transactions)
                .WithOne(t => t.Product)
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.SetNull);

            // Category relationships
            modelBuilder.Entity<CategoryModel>()
                .HasOne(c => c.Business)
                .WithMany()
                .HasForeignKey(c => c.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            // Supplier relationships
            modelBuilder.Entity<SupplierModel>()
                .HasOne(s => s.Business)
                .WithMany()
                .HasForeignKey(s => s.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            modelBuilder.Entity<ProductModel>()
                .HasIndex(p => p.SKU);

            modelBuilder.Entity<TransactionModel>()
                .HasIndex(t => t.TransactionDate);

            modelBuilder.Entity<TransactionModel>()
                .HasIndex(t => new { t.BusinessId, t.TransactionDate });
        }
    }
}
