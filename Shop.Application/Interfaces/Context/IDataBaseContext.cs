using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Cart;
using Shop.Domain.Entities.HomePage;
using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UserInRole { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<ProductImage> ProductImage { get; set; }
        DbSet<ProductFeature> ProductFeature { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<Carts> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
