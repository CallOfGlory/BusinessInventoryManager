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
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BusinessModel> Businesses { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<UserSettingsModel> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User relationships
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Products)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Businesses)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Settings)
                .WithOne(s => s.User)
                .HasForeignKey<UserSettingsModel>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Business relationships
            modelBuilder.Entity<BusinessModel>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Business)
                .HasForeignKey(p => p.BusinessId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<BusinessModel>()
                .HasMany(b => b.Transactions)
                .WithOne(t => t.Business)
                .HasForeignKey(t => t.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            // Transaction relationships
            modelBuilder.Entity<TransactionModel>()
                .HasOne(t => t.Product)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<ProductModel>()
                .HasIndex(p => new { p.UserId, p.BusinessId });

            modelBuilder.Entity<TransactionModel>()
                .HasIndex(t => t.TransactionDate);

            modelBuilder.Entity<TransactionModel>()
                .HasIndex(t => new { t.BusinessId, t.TransactionDate });

            modelBuilder.Entity<BusinessModel>()
                .HasIndex(b => new { b.UserId, b.IsActive });
        }
    }
}
