using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AutoWorld.Models
{
    public partial class AutoWorlDbContext : DbContext
    {
        public AutoWorlDbContext()
            : base("name=Auto_World")
        {
        }

        
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Coupons> Coupons { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Motos> Motos { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Accounts)
                .HasForeignKey(e => e.AccountId);

            modelBuilder.Entity<Accounts>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Accounts)
                .HasForeignKey(e => e.AccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cars>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Cars>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Cars>()
                .Property(e => e.Fuel)
                .IsUnicode(false);

            modelBuilder.Entity<Cars>()
                .Property(e => e.Origin)
                .IsUnicode(false);

            modelBuilder.Entity<Cars>()
                .Property(e => e.Other)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .Property(e => e.DisplayText)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coupons>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Coupons)
                .HasForeignKey(e => e.CouponId);

            modelBuilder.Entity<Motos>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Motos>()
                .Property(e => e.Weight)
                .IsUnicode(false);

            modelBuilder.Entity<Motos>()
                .Property(e => e.PetrolTankCapacity)
                .IsUnicode(false);

            modelBuilder.Entity<Motos>()
                .Property(e => e.EngineType)
                .IsUnicode(false);

            modelBuilder.Entity<Motos>()
                .Property(e => e.MaximumPower)
                .IsUnicode(false);

            modelBuilder.Entity<Motos>()
                .Property(e => e.MaximumMoment)
                .IsUnicode(false);

            modelBuilder.Entity<Motos>()
                .Property(e => e.CylinderCapacity)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}
