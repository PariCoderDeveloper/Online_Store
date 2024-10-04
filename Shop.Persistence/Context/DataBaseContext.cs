using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using Shop.Application.Interfaces.Context;
using Shop.Ccommon.Purches;
using Shop.Ccommon.Roles;
using Shop.Domain.Entities.Cart;
using Shop.Domain.Entities.HomePage;
using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(i => i.Email).IsUnique();

            QueryFilter(modelBuilder);

            configureProductEntityMapping(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = nameof(UserRoles.Admin)
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = nameof(UserRoles.Operator)
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Name = nameof(UserRoles.Customer)
            });
        }

        private void QueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Products>().HasQueryFilter(p => p.Displayed & !p.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsRemoved & p.Display);
            modelBuilder.Entity<Carts>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p => !p.IsRemoved);
        }

        private void configureProductEntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>()
                .HasOne(p => p.Products)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductFeature>()
                .HasOne(p => p.Products)
                .WithMany(p => p.ProductFeatures)
                .HasForeignKey(p => p.ProductId);
        }

    }
}
